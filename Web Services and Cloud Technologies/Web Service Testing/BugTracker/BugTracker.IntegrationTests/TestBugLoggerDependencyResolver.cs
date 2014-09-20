namespace BugTracker.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http.Dependencies;

    using BugTracker.Data.Contracts;
    using BugTracker.WebServices.Controllers;

    internal class TestBugsDependencyResolver<T> : IDependencyResolver
        where T : class
    {
        public IBugTrackerData BugTrackerData { get; set; }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            // add all controllers
            if (serviceType == typeof(BugsController))
            {
                return new BugsController(this.BugTrackerData);
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