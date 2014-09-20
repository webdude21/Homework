namespace BugTracker.IntegrationTests
{
    using System;
    using System.Linq;
    using System.Net;

    using BugTracker.Data.Contracts;
    using BugTracker.Model;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Telerik.JustMock;

    [TestClass]
    public class BugsControllerIntegrationTests
    {
        private const string InMemoryServerUrl = "http://localhost:12345";

        private static readonly Random Rand = new Random();

        [TestMethod]
        public void GetAllWhenBugsInDbShouldReturnStatus200AndNonEmptyContent()
        {
            var mockUnitOfWork = Mock.Create<IBugTrackerData>();
            Bug[] bugs =
                {
                    new Bug { Id = 1, LogDate = DateTime.Today, Status = Status.Pending, Text = "SomeText" }, 
                    new Bug { Id = 2, LogDate = DateTime.Today, Status = Status.Pending, Text = "SomeText" }, 
                    new Bug { Id = 2, LogDate = DateTime.Today, Status = Status.Pending, Text = "SomeText" }
                };

            Mock.Arrange(() => mockUnitOfWork.Bugs).Returns((IRepository<Bug>)bugs.AsQueryable());

            var server = new InMemoryHttpServer<Bug>(InMemoryServerUrl, mockUnitOfWork);

            var response = server.CreateGetRequest("/api/Bugs/All");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void PostNewBugWhenTextIsValidShouldReturn201AndLocationHeader()
        {
            var mockUnitOfWork = Mock.Create<IBugTrackerData>();

            var bug = this.GetValidBug();

            Mock.Arrange(() => mockUnitOfWork.Bugs.Add(Arg.IsAny<Bug>())).Returns(() => bug);

            var server = new InMemoryHttpServer<Bug>(InMemoryServerUrl, mockUnitOfWork);

            var response = server.CreatePostRequest("/api/Bugs/Log", bug);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Headers.Location);
        }

        [TestMethod]
        public void PostNewBugWhenTextIsEmptyShouldReturn400()
        {
            var repo = Mock.Create<IBugTrackerData>();

            var bug = new Bug { Text = string.Empty };

            var server = new InMemoryHttpServer<Bug>(InMemoryServerUrl, repo);

            var response = server.CreatePostRequest("/api/Bugs/Log", bug);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void PostNewBugWhenTextIsNullShouldReturn400()
        {
            var repo = Mock.Create<IBugTrackerData>();

            var bug = new Bug { Text = null };

            var server = new InMemoryHttpServer<Bug>(InMemoryServerUrl, repo);

            var response = server.CreatePostRequest("/api/Bugs/Log", bug);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        private Bug GetValidBug()
        {
            return new Bug { Id = Rand.Next(1000, 2000), Text = "New Bug #" + Rand.Next(1000, 2000), LogDate = DateTime.Now, Status = Status.Pending };
        }
    }
}