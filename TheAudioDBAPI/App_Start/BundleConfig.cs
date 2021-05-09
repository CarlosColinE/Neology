using System.Web;
using System.Web.Optimization;

namespace TheAudioDBAPI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            /*--CSS FontAwesome Style --*/
            bundles.Add(new StyleBundle("~/Content/fontawesomecss").Include(
                ("~/Content/font-awesome.css")));

            /*--JS Bootstrap Table Plugins Script --*/
            bundles.Add(new ScriptBundle("~/bundles/bootstrapTablePlugins").Include(
                "~/Scripts/bootstrap-table/bootstrap-table-contextmenu",
                "~/Scripts/bootstrap-table/bootstrap-table-mobile.js"));

            /*-- CSS Boostrap Table Style --*/
            bundles.Add(new StyleBundle("~/Content/bootstraptablecss").Include(
                "~/Content/bootstrap-table.css"));

            /*--CSS Login--*/
            bundles.Add(new StyleBundle("~/bundles/LoginCSS").Include(
                "~/Content/login.css"));

            /*--CSS Definition --*/
            /*-- CSS Main Style --*/
            bundles.Add(new StyleBundle("~/Content/Main/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-table.css",
                "~/Content/style.css"
                ));

        }
    }
}
