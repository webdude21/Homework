namespace BugTracker.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Web.Http;

    using BugTracker.Data.Contracts;

    using Newtonsoft.Json;

    public class InMemoryHttpServer<T> where T : class
    {
        private readonly HttpClient client;

        private readonly string baseUrl;

        public InMemoryHttpServer(string baseUrl, IBugTrackerData bugTrackerData)
        {
            this.baseUrl = baseUrl;
            var config = new HttpConfiguration();
            this.AddHttpRoutes(config.Routes);
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            var resolver = new TestBugsDependencyResolver<T> { BugTrackerData = bugTrackerData };
            config.DependencyResolver = resolver;

            var server = new HttpServer(config);
            this.client = new HttpClient(server);
        }

        public HttpResponseMessage CreateGetRequest(string requestUrl, string mediaType = "application/json")
        {
            var url = requestUrl;
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(this.baseUrl + url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            request.Method = HttpMethod.Get;

            var response = this.client.SendAsync(request).Result;
            return response;
        }

        public Task<HttpResponseMessage> CreateGetRequestAsync(string requestUrl, string mediaType = "application/json")
        {
            var url = requestUrl;
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(this.baseUrl + url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            request.Method = HttpMethod.Get;

            var response = this.client.SendAsync(request);
            return response;
        }

        public HttpResponseMessage CreatePostRequest(
            string requestUrl, 
            object data, 
            string mediaType = "application/json")
        {
            var url = requestUrl;
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(this.baseUrl + url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            request.Method = HttpMethod.Post;
            request.Content = new StringContent(JsonConvert.SerializeObject(data));
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);

            var response = this.client.SendAsync(request).Result;
            return response;
        }

        public HttpRequestMessage CreatePutRequest(string requestUrl, object data)
        {
            throw new NotImplementedException();
        }

        public HttpRequestMessage CreateDeleteRequest(string requestUrl)
        {
            throw new NotImplementedException();
        }

        private void AddHttpRoutes(HttpRouteCollection routeCollection)
        {
            var routes = this.GetRoutes();
            routes.ForEach(route => routeCollection.MapHttpRoute(route.Name, route.Template, route.Defaults));
        }

        private List<Route> GetRoutes()
        {
            return new List<Route>
                       {
                           new Route(
                               "DefaultApi", 
                               "api/{controller}/{action}/{id}", 
                               new { id = RouteParameter.Optional })
                       };
        }

        private class Route
        {
            public Route(string name, string template, object defaults)
            {
                this.Name = name;
                this.Template = template;
                this.Defaults = defaults;
            }

            public object Defaults { get; private set; }

            public string Name { get; private set; }

            public string Template { get; private set; }
        }
    }
}