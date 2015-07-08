namespace App.Apex.Web
{
	using System.Web.Http;
	using SimpleInjector;
	using SimpleInjector.Integration.WebApi;

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
			//container.RegisterWebApiRequest<IUnitOfWork, UnitOfWork>();
		}
	}
}