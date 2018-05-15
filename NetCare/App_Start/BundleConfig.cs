using System.Web;
using System.Web.Optimization;

namespace NetCare
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                      "~/fullcalendar/jquery-{version}.js",
                      // needed for drag/move events in fullcalendar
                      "~/fullcalendar/jquery-ui-{version}.js",
                      "~/fullcalendar/bootstrap.js",
                      "~/fullcalendar/bootstrap-modal.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                         "~/Scripts/jquery.unobtrusive*",
                         "~/Scripts/jquery.validate.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
             //"~/Scripts/lib/jquery.min.js",
             "~/Scripts/bootstrap.min.js",
               "~/Scripts/bootstrap-datepicker.js",
                   "~/Scripts/jquery.slimscroll.min.js",
                     "~/Scripts/adminlte.min.js",
                       "~/Scripts/demo.js"));

            bundles.Add(new ScriptBundle("~/bundles/grid").Include(
                "~/Scripts/grid-0.4.3.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/Admincss").Include(

               "~/Content/bootstrap.min.css",
               "~/Content/bootstrap-datepicker.css",
               "~/Content/font-awesome.min.css",
               "~/Content/ionicons.min.css",
               "~/Content/AdminLTE.min.css",
               "~/Content/datatables.min.css",
               "~/Content/_all-skins.css",
               "~/Content/_all-skins.min.css",
               "~/Content/blue.css"
               ));

            bundles.Add(new StyleBundle("~/Content/gridcss").Include(

            "~/Content/bootstrap.min.css",
            "~/Content/bootstrap-theme.min.css",
            "~/Content/grid-0.4.3.min.css"
            ));
        }
    }
}
