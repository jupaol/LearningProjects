using System.Web;
using System.Web.Optimization;

namespace MvcApplication2
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle(@"~/bundles/angularjs")
    .Include(@"~/Scripts/angular.js")
    .Include(@"~/Scripts/angular-bootstrap.js")
    .Include(@"~/Scripts/angular-localStorage.js"));

            bundles.Add(new ScriptBundle(@"~/bundles/toastr")
                .Include(@"~/Scripts/toastr.js"));

            bundles.Add(new ScriptBundle(@"~/bundles/configurationsApp")
                .Include("~/configurationsApp/main.js")
                .IncludeDirectory("~/configurationsApp/services", "*.js", searchSubdirectories: true)
                .IncludeDirectory("~/configurationsApp/directives", "*.js", searchSubdirectories: true)
                .IncludeDirectory("~/configurationsApp/views", "*.js", searchSubdirectories: true));

            bundles.Add(new ScriptBundle(@"~/bundles/specs")
                .IncludeDirectory("~/configurationsApp/specs", "*spec.js", searchSubdirectories: true));

            bundles.Add(new ScriptBundle(@"~/bundles/nggrid")
                .Include(@"~/Scripts/ng-grid-{version}.js")
                .Include(@"~/Scripts/ng-grid-csv-export.js"));

            bundles.Add(new ScriptBundle(@"~/bundles/bootstrap")
    .Include(@"~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle(@"~/bundles/underscore")
                .Include(@"~/Scripts/underscore.js"));

            bundles.Add(new StyleBundle(@"~/bundles/css")
    .Include(@"~/Content/bootstrap.css")
    .Include(@"~/Content/font-awesome.css")
    .Include(@"~/Content/bootstrap-responsive.css")
    .Include(@"~/Content/ng-grid.css")
    .Include(@"~/Content/toastr.css")
    .Include(@"~/Content/application.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/signalr").Include(
                        "~/Scripts/jquery.signalR-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}