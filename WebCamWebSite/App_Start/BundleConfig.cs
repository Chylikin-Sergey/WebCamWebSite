using System.Web;
using System.Web.Optimization;

namespace WebCamWebSite
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles (BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/umd/popper.js",
                        "~/Scripts/bootstrap.js"));
        

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/Index.css",
                      "~/Content/Contacts.css",
                      "~/Content/Ask_a_Questions.css"));
            bundles.Add(new ScriptBundle("~/bundles/unobtrusive-ajax").Include(
                    "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new StyleBundle("~/Content/Slick-css").Include(
               "~/Content/slick.css",
               "~/Content/slick-theme.css"));
            bundles.Add(new ScriptBundle("~/bundles/Slick").Include(
                "~/Scripts/slick.js"));

        }
    }
}
