namespace MusicArtists.Services
{
    using System.Web.Http;
    using System.Web.OData.Extensions;

    using Newtonsoft.Json;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.EnableCors();
            config.AddODataQueryFilter();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling =
                PreserveReferencesHandling.None;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}