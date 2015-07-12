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
            bundles.Add(new StyleBundle("~/content/css/app").Include("~/content/app.css", "~/content/vendor.css"));

            bundles.Add(new ScriptBundle("~/js/jquery").Include("~/scripts/vendor/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/js/app").Include(
                //"~/scripts/vendor/angular.js",
                "~/scripts/vendor/angular-ui-router.js",
                "~/Backend/shared/filters.js",
                "~/Backend/shared/services.js",
                "~/Backend/shared/directives.js",
                "~/Backend/constants/apex.constants.js",
                "~/Backend/components/news/newsController.js",
                "~/Backend/components/home/homeController.js",
                "~/Backend/components/users/usersController.js",
                "~/Backend/app.js",
                "~/Backend/app.config.js",
                "~/Backend/app.routes.js"));
            var culture = CultureInfo.CurrentCulture.Name.ToLower();
            bundles.Add(new ScriptBundle("~/js/localization").Include(
                string.Format("~/Scripts/translations/resources_{0}.js", culture)));
        }
    }
}
