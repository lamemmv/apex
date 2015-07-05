// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="">
//   Copyright © 2015 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Http;
using App.Apex.Web.App_Start;

namespace App.Apex.Web
{
    using System.Web;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class Application : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
