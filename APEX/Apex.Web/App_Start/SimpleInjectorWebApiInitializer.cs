using System.Web.Http;
using Apex.Framework.Data.Context;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace Apex.Web
{
    public static class SimpleInjectorWebApiInitializer
	{
		/// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
		public static void Initialize()
		{
			// Did you know the container can diagnose your configuration? 
			// Go to: https://simpleinjector.org/diagnostics
			var container = new Container();
			InitializeContainer(container);

			container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
			container.Verify();
			GlobalConfiguration.Configuration.DependencyResolver =
				new SimpleInjectorWebApiDependencyResolver(container);
		}

		private static void InitializeContainer(Container container)
		{
			container.RegisterWebApiRequest<IUnitOfWork, UnitOfWork>();
		}
	}
}