namespace Application.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http.Dependencies;

    using Application.Data.Contracts;
    using Application.WebServices.Controllers;

    internal class TestBugsDependencyResolver : IDependencyResolver
    {
        public IApplicationData UnitOfWork { get; set; }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            // add all controllers
            if (serviceType == typeof(ArticlesController))
            {
                return new ArticlesController(this.UnitOfWork);
            }

            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}