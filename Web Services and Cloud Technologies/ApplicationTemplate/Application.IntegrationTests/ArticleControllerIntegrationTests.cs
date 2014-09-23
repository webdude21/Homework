namespace Application.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using Application.Data.Contracts;
    using Application.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Telerik.JustMock;

    [TestClass]
    public class ArticleControllerIntegrationTests
    {
        private const string InMemoryServerUrl = "http://localhost:12345";

        private const string ApiArticles = "/api/articles";

        private static readonly Random Rand = new Random();

        [TestMethod]
        public void GetAllWhenArticlesInDbShouldReturnStatus200AndNonEmptyContent()
        {
            var unitOfwork = Mock.Create<IApplicationData>();
            var articles = GenerateValidTestArticles(13);

            Mock.Arrange(() => unitOfwork.Articles.All()).Returns(articles.AsQueryable);

            var server = new InMemoryHttpServer(InMemoryServerUrl, unitOfwork);

            var response = server.CreateGetRequest(ApiArticles);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void PostNewValidArticleIsValidShouldReturn201AndLocationHeader()
        {
            var unitOfwork = Mock.Create<IApplicationData>();

            var article = new Article
                              {
                                  Title = "Some title",
                                  Content = "Some Content",
                              };

            Mock.Arrange(() => unitOfwork.Articles.Add(Arg.IsAny<Article>())).Returns(() => article);

            var server = new InMemoryHttpServer(InMemoryServerUrl, unitOfwork);

            var response = server.CreatePostRequest(ApiArticles, article);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Headers.Location);
        }

        [TestMethod]
        public void PostNewArticleWhenTextIsEmptyShouldReturn400()
        {
            var unitOfwork = Mock.Create<IApplicationData>();

            var article = new Article { Content = string.Empty };

            var server = new InMemoryHttpServer(InMemoryServerUrl, unitOfwork);

            var response = server.CreatePostRequest(ApiArticles, article);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void PostNewArticleWhenTextIsNullShouldReturn400()
        {
            var unitOfwork = Mock.Create<IApplicationData>();

            var bug = new Article { Content = null };

            var server = new InMemoryHttpServer(InMemoryServerUrl, unitOfwork);

            var response = server.CreatePostRequest(ApiArticles, bug);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        private static IEnumerable<Article> GenerateValidTestArticles(int count)
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
    }
}