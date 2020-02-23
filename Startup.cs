using Galytix.Data;
using Owin;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace Galytix
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "server/api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            RegisterUnityResolver(config);

            appBuilder.UseWebApi(config);
        }

        public static void RegisterUnityResolver(HttpConfiguration config)
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterInstance<ICountryGwpRepository>(new CsvCountryGwpRepository(@"Data\gwpByCountry.csv"), new ContainerControlledLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
