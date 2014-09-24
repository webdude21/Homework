namespace Application.WebServices.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using System.Web.Http.Routing;

    using Application.Data.Contracts;
    using Application.Models;
    using Application.WebServices.Controllers;
    using Application.WebServices.DataModels;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Telerik.JustMock;

    [TestClass]
    public class ScoresControllerTest
    {
        [TestMethod]
        public void GetAllWhen16ArticlesInDbShouldReturn10Articles()
        {
            var players = GenerateValidPlayer(16);

            var repository = Mock.Create<IRepository<ApplicationUser>>();
            Mock.Arrange(() => repository.All()).Returns(players.AsQueryable);

            var unitOfWork = Mock.Create<IBullsAndCowsData>();

            Mock.Arrange(() => unitOfWork.Users).Returns(() => repository);

            var controller = new ScoresController(unitOfWork);
            SetupController(controller);

            var actionResult = controller.All();

            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;

            var actual = response.Content.ReadAsAsync<IEnumerable<ApplicationUser>>().Result.Select(a => new ScoreModel(a)).ToList();

            var expected = players.OrderBy(u => u.Rank).ThenBy(u => u.Username).Skip(page * PageSize).Take(PageSize));

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void GetAllArticlesWithinACategoryShouldReturnCorrectResult()
        {
            const int ArticlesPerPage = 10;
            const string CategoryToLookFor = "Test Category";
            var articles = GenerateValidTestUser(16);

            var repository = Mock.Create<IRepository<Article>>();
            Mock.Arrange(() => repository.All()).Returns(articles.AsQueryable);

            var unitOfWork = Mock.Create<IBullsAndCowsData>();

            Mock.Arrange(() => unitOfWork.Articles).Returns(() => repository);

            var controller = new ArticlesController(unitOfWork);
            SetupController(controller);

            var actionResult = controller.All(CategoryToLookFor);

            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;

            var actual = response.Content.ReadAsAsync<IEnumerable<ArticleModel>>().Result.Select(a => a.Category == CategoryToLookFor).ToList();

            var expected = articles.AsQueryable().OrderByDescending(a => a.DateCreated).Take(ArticlesPerPage).Select(a => a.Category.Name == CategoryToLookFor).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void GetSecondPageWhen300ArticlesInDbShouldReturn10Articles()
        {
            var articles = GenerateValidTestUser(300);

            const int ArticlesPerPage = 10;
            const int Page = 2;

            var repository = Mock.Create<IRepository<Article>>();
            Mock.Arrange(() => repository.All()).Returns(articles.AsQueryable);

            var unitOfWork = Mock.Create<IBullsAndCowsData>();

            Mock.Arrange(() => unitOfWork.Articles).Returns(() => repository);

            var controller = new ArticlesController(unitOfWork);
            SetupController(controller);

            var actionResult = controller.All(Page);

            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;

            var actual = response.Content.ReadAsAsync<IEnumerable<ArticleModel>>().Result.Select(a => a.Id).ToList();

            var expected = articles.AsQueryable().OrderByDescending(a => a.DateCreated).Skip(Page * ArticlesPerPage).Take(ArticlesPerPage).Select(a => a.Id).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        private static IEnumerable<ApplicationUser> GenerateValidPlayer(int count)
        {
            var users = new ApplicationUser[count];
            for (var index = 0; index < count; index++)
            {
                var user = new ApplicationUser
                {
                    Id = "asfasfafas" + index,
                    UserName = "Testis" + index,
                    Email = "Testis@asfa.bg" + index,
                    UserLossesCount = index * 2 + 1,
                    UserWinsCount = index * 3,
                    Ra
                };

                users[index] = user;
            }

            return users;
        }

        private static void SetupController(ApiController controller)
        {
            const string ServerUrl = "http://test-url.com";

            // Setup the Request object of the controller
            var request = new HttpRequestMessage { RequestUri = new Uri(ServerUrl) };
            controller.Request = request;

            // Setup the configuration of the controller
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            controller.Configuration = config;

            // Apply the routes of the controller
            controller.RequestContext.RouteData = new HttpRouteData(
                new HttpRoute(),
                new HttpRouteValueDictionary { { "controller", "scores" } });
        }
    }
}