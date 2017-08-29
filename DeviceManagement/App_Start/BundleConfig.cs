using System.Web;
using System.Web.Optimization;

namespace DeviceManagement
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/AppV2").Include(
                  "~/Scripts/app.V2.js"));
            #endregion

            #region Styles
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/bootstrap.css"));
            bundles.Add(new StyleBundle("~/Content/Dashboard").Include("~/Content/Dashboard.css"));
            bundles.Add(new StyleBundle("~/Content/AppV2").Include("~/Content/app.V2.css"));
            bundles.Add(new StyleBundle("~/Content/AndriodTabs").Include("~/Content/AndriodTabs.css"));
            bundles.Add(new StyleBundle("~/Content/fonts").Include("~/Content/Fonts/font-awesome/css/font-awesome.css"));
            #endregion




        }
    }
}
