namespace BugTracker.WebServices
{
    using System.Web.Http;
    using System.Web.OData.Extensions;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.EnableCors();
            config.AddODataQueryFilter();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{action}/{id}", new { id = RouteParameter.Optional });
        }
    }
}