using System.Web.Optimization;

namespace ReportManager
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Commons/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/Commons/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/Commons/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/Commons/bootstrap.js",
                      "~/Scripts/Commons/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/site.css",
                      "~/Content/Shared/layout.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/index").Include(
                      "~/Scripts/Commons/knockout-3.4.1.js",
                      "~/Scripts/Commons/moment-with-locales.min.js",
                      "~/Scripts/Commons/bootstrap-datetimepicker.min.js",
                      "~/Scripts/Commons/knockout.mapping-latest.js",
                      "~/Scripts/Views/Home/index.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/report").Include(
                      "~/Scripts/Commons/knockout-3.4.1.js",
                      "~/Scripts/Views/Report/report.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/reportPartial").Include(
                      "~/Scripts/Views/Report/reportPartial.js"
                      ));
            bundles.Add(new StyleBundle("~/Content/reportPartial").Include(
                      "~/Content/Report/reportPartial.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/createReport").Include(
                      "~/Scripts/Commons/jquery.validate*",
                      "~/Scripts/Commons/knockout-3.4.1.js",
                      "~/Scripts/Views/Report/createReport.js"
                      ));
        }
    }
}
