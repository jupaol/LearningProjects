using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace SportsStore.UI.RouteConstraints
{
    public class SkipPage1Constraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.ContainsKey(parameterName))
            {
                return false;
            }

            if (values[parameterName] == null)
            {
                return false;
            }

            var value = Convert.ToInt32(values[parameterName]);

            if (value <= 1)
            {
                return false;
            }

            return true;
        }
    }
}