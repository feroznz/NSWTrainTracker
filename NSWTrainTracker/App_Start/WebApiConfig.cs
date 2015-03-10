using System.Net.Http.Headers;
using System.Web.Http;
using Microsoft.Practices.Unity;
using NSWTrainTracker.Models.Custom_Exception;
using NSWTrainTracker.Models.DAL;
using NSWTrainTracker.Resolver;

namespace NSWTrainTracker.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var container = new UnityContainer();
            container.RegisterType<ITrackWorkRepository, TrackWorkRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // return json - jsonp.
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}/{format}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Filters.Add(new UnhandledExceptionFilter());
        }
    }
}
