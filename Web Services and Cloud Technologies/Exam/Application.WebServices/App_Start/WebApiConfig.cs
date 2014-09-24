namespace Application.WebServices
{
    using System.Web.Http;
    using System.Web.OData.Extensions;

    using Microsoft.Owin.Security.OAuth;

    using Newtonsoft.Json;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.AddODataQueryFilter();

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            config.Routes.MapHttpRoute(
               "GuessRoute",
               "api/Games/{id}/{controller}",
               new { controller = "Guess", id = RouteParameter.Optional });

            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling =
                PreserveReferencesHandling.None;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}