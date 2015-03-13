using System.Net.Http.Headers;
using System.Web.Http;
using NSWTrainTracker.Models.Custom_Exception;

namespace NSWTrainTracker.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

           

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
