// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="">
//   Copyright © 2015 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Apex.Web
{
    using System.Web;
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/content/css/app").Include("~/content/app.css"));

            bundles.Add(new ScriptBundle("~/js/jquery").Include("~/scripts/vendor/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/js/app").Include(
                //"~/scripts/vendor/angular.js",
                "~/scripts/vendor/angular-ui-router.js",
                "~/scripts/vendor/angular-translate.js",
                "~/Backend/translate.js",
                "~/Backend/shared/filters.js",
                "~/Backend/shared/services.js",
                "~/Backend/shared/directives.js",
                "~/Backend/components/news/controllers.js",
                "~/Backend/app.js"));
        }
    }
}
