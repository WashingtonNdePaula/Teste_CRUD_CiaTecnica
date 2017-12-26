using System.Web.Optimization;

namespace Teste_CRUD_CiaTecnica.Presentation.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/CustomValidacoes.js"));

            bundles.Add(new ScriptBundle("~/bundles/Mascaras").Include(
                        "~/Scripts/Mascaras/jquery.mask.js",
                        "~/Scripts/Mascaras/Mascaras.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
            "~/Scripts/DataTables/jquery.dataTables.min.js",
            "~/Scripts/DataTables/dataTables.bootstrap.js"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.css",
                      "~/Content/site.css"));

        }
    }
}
