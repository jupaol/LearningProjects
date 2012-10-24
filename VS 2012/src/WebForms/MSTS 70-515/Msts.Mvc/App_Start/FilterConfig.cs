using Elmah.Contrib.Mvc;
using Msts.Mvc.CustomFilterProviders;
using System.Web;
using System.Web.Mvc;

namespace Msts.Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ElmahHandleErrorAttribute());
            filters.Add(new ValidateInputAttribute(true));
        }

        public static void RegisterGlobalProviders(FilterProviderCollection filterProviderCollection)
        {
            //filterProviderCollection.Add(new CrossSiteRequestForgeryFilter());
        }
    }
}