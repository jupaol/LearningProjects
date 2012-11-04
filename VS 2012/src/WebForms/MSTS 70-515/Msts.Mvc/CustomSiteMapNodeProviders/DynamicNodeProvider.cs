using Msts.Mvc.Controllers;
using MvcSiteMapProvider.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Msts.Mvc.CustomSiteMapNodeProviders
{
    public class DynamicNodeProvider : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection()
        {
            var dynamicNodes = new List<DynamicNode>();
            var controllersWithoutArea = this.GetControllers("Msts.Mvc.Controllers");
            var controllersWithArea = this.GetControllers("Msts.Mvc.Areas");
            var areas = this.GetAreas();

            HttpContext.Current.Trace.Warn("Dynamic Node Provider called");

            dynamicNodes.AddRange(this.GetDynamicNodes(controllersWithoutArea));
            dynamicNodes.AddRange(this.GetDynamicNodes(controllersWithArea, "Areas", areas.ToArray()));

            return dynamicNodes;
        }

        private IEnumerable<string> GetAreas()
        {
            var assembly = this.GetType().Assembly;
            var areas = assembly.GetTypes().Where(x =>
                typeof(AreaRegistration).IsAssignableFrom(x) &&
                !x.IsAbstract &&
                !x.IsGenericType &&
                !x.IsGenericTypeDefinition);


            return areas.Select(x =>
                {
                    var instance = ((AreaRegistration)Activator.CreateInstance(x));

                    return instance.AreaName;
                });
        }

        private IEnumerable<DynamicNode> GetDynamicNodes(IEnumerable<Type> controllers, string parentNodeTitle = null, params string[] areas)
        {
            var dynamicNodes = new List<DynamicNode>();
            var parentNodeKey = string.Empty;

            if (!string.IsNullOrWhiteSpace(parentNodeTitle))
            {
                parentNodeKey = Guid.NewGuid().ToString();

                var parentNode = new DynamicNode(parentNodeKey, parentNodeTitle);

                parentNode.Attributes["clickable"] = bool.FalseString;

                dynamicNodes.Add(parentNode);
            }

            foreach (var type in controllers)
            {
                var areaName = string.Empty;

                foreach (var area in areas)
                {
                    var areaNamespace = string.Format(
                        "{0}.{1}",
                        "Msts.Mvc.Areas",
                        area);

                    if (type.Namespace.StartsWith(areaNamespace))
                    {
                        areaName = area;
                        break;
                    }
                }

                var dynamicControllerNode = new DynamicNode(type.FullName, type.Name)
                {
                    Action = "Index",
                    Controller = type.Name.Replace("Controller", string.Empty),
                    Area = areaName,
                    ParentKey = parentNodeKey
                };

                var actions = this.GetActions(controller: type);

                if (!actions.Any(x => x.Name.Equals("Index", StringComparison.InvariantCulture)))
                {
                    dynamicControllerNode.Attributes["clickable"] = bool.FalseString;
                }

                dynamicNodes.Add(dynamicControllerNode);

                foreach (var action in actions)
                {
                    var dynamicActionNode = new DynamicNode(string.Format("{0}.{1}", type.FullName, action.Name), action.Name)
                    {
                        Action = action.Name,
                        Controller = type.Name.Replace("Controller", string.Empty),
                        Area = areaName,
                        ParentKey = type.FullName
                    };

                    dynamicNodes.Add(dynamicActionNode);
                }
            }

            return dynamicNodes;
        }

        private IEnumerable<MethodInfo> GetActions(Type controller)
        {
            var actions = controller.GetMethods(
                BindingFlags.Public | 
                BindingFlags.Instance |
                BindingFlags.DeclaredOnly | 
                BindingFlags.InvokeMethod
                ).AsEnumerable();

            actions = actions
                .Where(x => 
                    !x.GetCustomAttributes<NonActionAttribute>().Any() &&
                    !x.GetCustomAttributes<ChildActionOnlyAttribute>().Any() &&
                    x.ReturnType != typeof(void)
            );
            actions = actions.Where(x =>
                x.GetCustomAttributes<ActionMethodSelectorAttribute>().Any() ? 
                    x.GetCustomAttributes<HttpGetAttribute>().Any() :
                    true);
            actions = actions.Where(x => !x.ContainsGenericParameters && x.GetParameters().Count() == 0);

            return actions.OrderBy(x => x.Name);
        }

        private IEnumerable<Type> GetAllControllers()
        {
            var mvcProjectAssembly = this.GetType().Assembly;
            var controllers = mvcProjectAssembly.GetTypes()
                    .Where(x =>
                        !x.IsGenericType && 
                        !x.IsGenericTypeDefinition && 
                        x != typeof(Controller) &&
                        !x.IsAbstract &&
                        typeof(Controller).IsAssignableFrom(x)
                        //x != typeof(AccountController)
                    );

            return controllers;
        }

        private IEnumerable<Type> GetControllers(string @namespace)
        {
            var controllers = this.GetAllControllers()
                .Where(x => x.Namespace.StartsWith(@namespace));

            return controllers.OrderBy(x => x.Name);
        }
    }
}