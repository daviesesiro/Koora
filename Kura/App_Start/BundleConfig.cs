using System.Web;
using System.Web.Optimization;

namespace Koora
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //For public
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/css/bootstrap/bootstrap.min.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome-4.7.0/css/font-awesome.min.css",
                      "~/Content/css/animate/animate.min.css",
                      "~/Content/css/owl-carousel/owl.carousel.min.css",
                      "~/Content/css/owl-carousel/owl.theme.default.min.css",
                      "~/Content/css/news.css",
                      "~/Content/css/team.css",
                      "~/Content/css/faq.css",
                      "~/Content/css/animation.css",
                      "~/Content/css/mobile.css"));

            //For public
            bundles.Add(new ScriptBundle("~/bundles/others").Include(                      
                      "~/Scripts/js/popper/popper.min.js",
                      "~/Scripts/js/jquery/jquery.min.js",
                      "~/Scripts/js/bootstrap/bootstrap.min.js",
                      "~/Scripts/bootbox.min.js",
                      "~/Scripts/js/wow/wow.min.js",
                      "~/Scripts/js/owl-carousel/owl.carousel.min.js",
                      "~/Scripts/js/jquery-easing/jquery.easing.min.js",
                      "~/Scripts/js/custom.js"));

            //For admin
            bundles.Add(new StyleBundle("~/Content/AdminCss").Include(
                        //"~/Content/bootstrap.min.css",
                        "~/Content/bootstrap-theme.css",
                        "~/Content/font-awesome-4.7.0/css/font-awesome.min.css",
                        "~/Content/datatables/css/datatables.bootstrap4.css",
                        "~/Content/toastr.css",
                        "~/Content/css/style.css"));
            //For admin
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/js/jquery/jquery.min.js",                      
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootbox.min.js",
                      "~/Scripts/datatables/jquery.datatables.js",
                      "~/Scripts/datatables/datatables.bootstrap4.js",
                      "~/Scripts/js/jquery-easing/jquery.easing.min.js",
                      "~/Scripts/toastr.js",
                      "~/Scripts/respond.js"));
        }

        
    }
}
