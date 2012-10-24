using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//using System.Web.Http.Controllers;
//using System.Web.Http.Filters;

namespace Msts.Mvc.CustomFilterProviders
{
    public class CrossSiteRequestForgeryFilter : IFilterProvider
    {
        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var method = controllerContext.HttpContext.Request.HttpMethod;

            if (method.Equals("post", StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new Filter(new ValidateAntiForgeryTokenAttribute(), FilterScope.Global, null);
            }
        }
    }
}