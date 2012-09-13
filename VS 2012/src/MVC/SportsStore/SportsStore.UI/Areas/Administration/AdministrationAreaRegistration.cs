using System.Web.Mvc;

namespace SportsStore.UI.Areas.Administration
{
    public class AdministrationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Administration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            //context.MapRoute(
            //    null,
            //    string.Empty,
            //    MVC.Administration.Admin.List(1),
            //    new { page = @"\d+" });

            context.MapRoute(
                null,
                "Administration/Products/page{page}",
                MVC.Administration.Admin.List(1),
                new { page = @"\d+" });

            context.MapRoute(
                "Administration_default",
                "Administration/{controller}/{action}/{id}",
                new { action = "List", id = UrlParameter.Optional }
            );
        }
    }
}
