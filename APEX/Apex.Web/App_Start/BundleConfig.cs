// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="">
//   Copyright © 2015 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Globalization;
using System.Web.Optimization;

namespace Apex.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/content/css/app").Include(
                //"~/content/app.css", 
                "~/content/vendor.css",
                //"~/content/theme.css",
                //"~/content/theme-responsive.css",
                "~/content/font-awesome.min.css",
                "~/content/home.css",
                "~/content/framework/app.min.1.css",
                "~/content/framework/material-design-iconic-font.min.css"));

            bundles.Add(new ScriptBundle("~/js/vendor").Include(
                "~/scripts/vendor/jquery-2.1.1.min.js",
                "~/scripts/vendor/jquery.cookie.js",
                //"~/scripts/vendor/jquery.flot.crosshair.js",
                "~/scripts/vendor/jquery.flot.js",
                "~/scripts/vendor/jquery.flot.pie.js",
                "~/scripts/vendor/jquery.flot.resize.js",
                "~/scripts/vendor/jquery.flot.stack.js",
                "~/scripts/vendor/jquery.flot.tooltip.min.js",
                "~/scripts/vendor/jquery.slimscroll.min.js",
                "~/scripts/vendor/jquery.sparkline.min",
                "~/scripts/vendor/angular.min.js",
                "~/scripts/vendor/angular-ui-router.js",
                "~/scripts/vendor/bootstrap.min.js",
                "~/scripts/vendor/ui-bootstrap-tpls-0.11.0.min.js"));

            bundles.Add(new ScriptBundle("~/js/theme").Include(
                /*"~/scripts/theme.js",
                "~/scripts/flaty-demo-codes.js"*/));

            bundles.Add(new ScriptBundle("~/js/app").Include(
                "~/Backend/shared/filters.js",
                "~/Backend/shared/services.js",
                "~/Backend/shared/directives.js",
                "~/Backend/constants/apex.constants.js",
                "~/Backend/components/news/newsController.js",
                "~/Backend/components/home/homeController.js",
                "~/Backend/components/users/usersController.js",
                "~/Backend/components/users/loginController.js",
                "~/Backend/components/main/mainController.js",
                "~/Backend/components/dashboard/dashboardController.js",
                "~/Backend/components/dashboard/functions.js",
                "~/Backend/components/dashboard/jquery.nicescroll.min.js",
                "~/Backend/app.js",
                "~/Backend/app.config.js",
                "~/Backend/app.routes.js"));
            var culture = CultureInfo.CurrentCulture.Name.ToLower();
            bundles.Add(new ScriptBundle("~/js/localization").Include(
                string.Format("~/Scripts/translations/resources_{0}.js", culture)));
        }
    }
}
