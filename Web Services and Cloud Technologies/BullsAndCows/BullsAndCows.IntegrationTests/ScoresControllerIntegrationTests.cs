namespace BullsAndCows.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using BullsAndCows.Data.Contracts;
    using BullsAndCows.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Telerik.JustMock;

    [TestClass]
    public class ScoresControllerIntegrationTests
    {
        private const string InMemoryServerUrl = "http://localhost:12345";

        private const string ApiArticles = "/api/scores";

        private static readonly Random Rand = new Random();

        [TestMethod]
        public void GetAllWhenScoresInDbShouldReturnStatus200AndNonEmptyContent()
        {
            var unitOfwork = Mock.Create<IBullsAndCowsData>();
            var users = GenerateValidPlayer(13);

            Mock.Arrange(() => unitOfwork.Users.All()).Returns(users.AsQueryable);

            var server = new InMemoryHttpServer(InMemoryServerUrl, unitOfwork);

            var response = server.CreateGetRequest(ApiArticles);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
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
                };

                users[index] = user;
            }

            return users;
        }
    }
}