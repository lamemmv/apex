// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="">
//   Copyright © 2015 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Routing;
using Apex.Web.Routing;

namespace Apex.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Add("Default", new DefaultRoute());
        }
    }
}
