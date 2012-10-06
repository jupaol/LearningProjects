using Elmah.Contrib.Mvc;
using System.Web;
using System.Web.Mvc;

namespace Msts.Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ElmahHandleErrorAttribute());
        }
    }
}