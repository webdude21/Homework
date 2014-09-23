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
    public class ArticlesControllerTest
    {
        [TestMethod]
        public void GetAllWhenArticlesInDbShouldReturnArticles()
        {
            var articles = GenerateValidTestArticles(1);

            var repository = Mock.Create<IRepository<Article>>();
            Mock.Arrange(() => repository.All()).Returns(articles.AsQueryable);

            var unitOfWork = Mock.Create<IApplicationData>();

            Mock.Arrange(() => unitOfWork.Articles).Returns(() => repository);

            var controller = new ArticlesController(unitOfWork);
            SetupController(controller);

            var actionResult = controller.All();

            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;

            var actual = response.Content.ReadAsAsync<IEnumerable<ArticleModel>>().Result.Select(a => a.Id).ToList();

            var expected = articles.AsQueryable().Select(a => a.Id).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void GetAllWhen16ArticlesInDbShouldReturn10Articles()
        {
            var articles = GenerateValidTestArticles(16);

            var repository = Mock.Create<IRepository<Article>>();
            Mock.Arrange(() => repository.All()).Returns(articles.AsQueryable);

            var unitOfWork = Mock.Create<IApplicationData>();

            Mock.Arrange(() => unitOfWork.Articles).Returns(() => repository);

            var controller = new ArticlesController(unitOfWork);
            SetupController(controller);

            var actionResult = controller.All();

            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;

            var actual = response.Content.ReadAsAsync<IEnumerable<ArticleModel>>().Result.Select(a => a.Id).ToList();

            var expected = articles.AsQueryable().OrderByDescending(a => a.DateCreated).Take(10).Select(a => a.Id).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void GetAllArticlesWithinACategoryShouldReturnCorrectResult()
        {
            const int ArticlesPerPage = 10;
            const string CategoryToLookFor = "Test Category";
            var articles = GenerateValidTestArticles(16);

            var repository = Mock.Create<IRepository<Article>>();
            Mock.Arrange(() => repository.All()).Returns(articles.AsQueryable);

            var unitOfWork = Mock.Create<IApplicationData>();

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
            var articles = GenerateValidTestArticles(300);

            const int ArticlesPerPage = 10;
            const int Page = 2;

            var repository = Mock.Create<IRepository<Article>>();
            Mock.Arrange(() => repository.All()).Returns(articles.AsQueryable);

            var unitOfWork = Mock.Create<IApplicationData>();

            Mock.Arrange(() => unitOfWork.Articles).Returns(() => repository);

            var controller = new ArticlesController(unitOfWork);
            SetupController(controller);

            var actionResult = controller.All(Page);

            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;

            var actual = response.Content.ReadAsAsync<IEnumerable<ArticleModel>>().Result.Select(a => a.Id).ToList();

            var expected = articles.AsQueryable().OrderByDescending(a => a.DateCreated).Skip(Page * ArticlesPerPage).Take(ArticlesPerPage).Select(a => a.Id).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        private static Article[] GenerateValidTestArticles(int count)
        {
            var articles = new Article[count];
            var category = new Category { Id = 1, Name = "Test Category" };

            var tags = new[] { new Tag { Id = 1, Name = "tag" } };

            for (var index = 0; index < count; index++)
            {
                var article = new Article
                                  {
                                      Id = index, 
                                      Title = " Title #" + index, 
                                      Content = "The Content #" + index, 
                                      Category = category, 
                                      DateCreated = DateTime.Now, 
                                      Tags = tags, 
                                      Author = new ApplicationUser()
                                  };

                articles[index] = article;
            }

            return articles;
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
                new HttpRouteValueDictionary { { "controller", "articles" } });
        }
    }
}