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
    public class GamesControllerIntegrationTests
    {
        private const string InMemoryServerUrl = "http://localhost:12345";

        private const string ApiArticles = "/api/scores";

        private static readonly Random Rand = new Random();

        [TestMethod]
        public void GetAllWhenGamesInDbShouldReturnStatus200AndNonEmptyContent()
        {
            var unitOfwork = Mock.Create<IBullsAndCowsData>();
            var games = GenerateValidGames(13);

            Mock.Arrange(() => unitOfwork.Games.All()).Returns(games.AsQueryable());

            var server = new InMemoryHttpServer(InMemoryServerUrl, unitOfwork);

            var response = server.CreateGetRequest(ApiArticles);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        private static IEnumerable<Game> GenerateValidGames(int count)
        {
            var games = new Game[count];
            for (var index = 0; index < count; index++)
            {
                var game = new Game
                {
                    Id = index,
                };

                games[index] = game;
            }

            return games;
        }
    }
}