using System.Web.Http;
using FSP.HBSIS.Infra.CrossCutting.IoC;
using FSP.HBSIS.Services.REST.ClienteAPI.App_Start;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using WebActivator;

[assembly: PostApplicationStartMethod(typeof (SimpleInjectorWebApiInitializer), "Initialize")]

namespace FSP.HBSIS.Services.REST.ClienteAPI.App_Start
{
    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            BootStrapper.RegisterServices(container);
        }
    }
}