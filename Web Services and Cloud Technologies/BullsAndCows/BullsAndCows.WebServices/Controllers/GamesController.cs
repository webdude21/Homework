namespace BullsAndCows.WebServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using BullsAndCows.Data.Contracts;
    using BullsAndCows.Logic;
    using BullsAndCows.Models;
    using BullsAndCows.WebServices.DataModels;

    using Microsoft.AspNet.Identity;

    public class GamesController : BaseController
    {
        private const int PageSize = 10;

        private const string ThisIsNotAOngoingGame = "This is not a ongoing game!";

        private const string YouCannotViewInformationAboutThisGameSinceYouReNotPartOfIt =
            "You cannot view information about this game since you're not part of it";

        private const string YouCannotJoinOngoingGame = "You cannot join an ongoing game";

        private const string YouCannotJoinTheSameGameTwice = "You cannot join the same game twice";

        private const string YouJoinedGame = "You joined game ";

        private const string FinishedGame = "You cannot join a finished game!";

        private const string GameJoinedBy = "{0} joined your game {1}";

        private const string ItsYourTurn = "It is your turn in game {0}";

        public GamesController(IBullsAndCowsData bullsAndCowsData)
            : base(bullsAndCowsData)
        {
        }

        public GamesController()
        {
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(CreateGameModel createGame)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var userId = this.User.Identity.GetUserId();
            var user = this.BullsAndCowsData.Users.All().FirstOrDefault(u => u.Id == userId);

            var newGame = new Game
                              {
                                  RedId = userId, 
                                  Red = user, 
                                  DateCreated = DateTime.Now, 
                                  Name = createGame.Name, 
                                  GameState = GameState.WaitingForOpponent, 
                                  RedNumber = createGame.Number
                              };

            this.BullsAndCowsData.Games.Add(newGame);
            this.BullsAndCowsData.SaveChanges();

            var createdGameModel = new GameModel(newGame);

            return this.CreatedAtRoute("DefaultApi", new { id = createdGameModel.Id }, createdGameModel);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetGameInfo(int id)
        {
            var game = this.BullsAndCowsData.Games.All().FirstOrDefault(g => g.Id == id);

            if (game == null)
            {
                return this.NotFound();
            }

            if (game.GameState == GameState.WaitingForOpponent)
            {
                return this.BadRequest(ThisIsNotAOngoingGame);
            }

            var userId = this.User.Identity.GetUserId();
            var user = this.BullsAndCowsData.Users.All().FirstOrDefault(u => u.Id == userId);

            if (game.Blue != user && game.Red != user)
            {
                return this.BadRequest(YouCannotViewInformationAboutThisGameSinceYouReNotPartOfIt);
            }

            var gameModel = new OnGoingGameDetailsModel(user, game);

            return this.Ok(gameModel);
        }

        [HttpPut]
        [Authorize]
        public IHttpActionResult JoinGame(int id, MakeGuessModel joiner)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var game = this.BullsAndCowsData.Games.All().FirstOrDefault(g => g.Id == id);

            if (game == null)
            {
                return this.NotFound();
            }

            if (game.GameState == GameState.Finished)
            {
                return this.BadRequest(FinishedGame);
            }

            if (game.GameState != GameState.WaitingForOpponent)
            {
                return this.BadRequest(YouCannotJoinOngoingGame);
            }

            var userId = this.User.Identity.GetUserId();
            var user = this.BullsAndCowsData.Users.All().FirstOrDefault(u => u.Id == userId);

            if (game.Red == user)
            {
                return this.BadRequest(YouCannotJoinTheSameGameTwice);
            }

            game.Blue = user;
            game.GameState = GameManager.GetPlayerInTurn();
            game.BlueNumber = joiner.Number;
            this.BullsAndCowsData.Games.Update(game);
            this.BullsAndCowsData.SaveChanges();
            var result = new { result = YouJoinedGame + game.Name };

            this.CreateNotificationForTurn(game);
            this.CreateNotification(user, game);

            return this.Ok(result);
        }

        private void CreateNotificationForTurn(Game game)
        {

            ApplicationUser user;

            if (game.GameState == GameState.BlueInTurn)
            {
                user = game.Blue;
            }
            else
            {
                user = game.Red;
            }

            var newnotification = new Notification
            {
                User = user,
                Message = string.Format(ItsYourTurn, game.Name),
                State = NotificationState.Unread,
                DateCreated = DateTime.Now,
                Game = game,
                GameId = game.Id,
                Type = NotificationType.YourTurn,
            };

            user.Notifications.Add(newnotification);
            this.BullsAndCowsData.SaveChanges();
        }

        private void CreateNotification(ApplicationUser user, Game game)
        {
            var otherUser = game.Red == user ? game.Blue : game.Red;

            var newnotification = new Notification
                                      {
                                          User = otherUser, 
                                          Message =
                                              string.Format(GameJoinedBy, otherUser.UserName, game.Name), 
                                          State = NotificationState.Unread, 
                                          DateCreated = DateTime.Now, 
                                          Game = game, 
                                          GameId = game.Id, 
                                          Type = NotificationType.GameJoined, 
                                      };

            otherUser.Notifications.Add(newnotification);
            this.BullsAndCowsData.SaveChanges();
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return this.All(0);
        }

        [HttpGet]
        public IHttpActionResult All(int page)
        {
            var result =
                this.BullsAndCowsData.Games.All()
                    .OrderBy(g => g.GameState.ToString())
                    .ThenBy(g => g.Name)
                    .ThenBy(g => g.DateCreated)
                    .ThenBy(g => g.Red.UserName)
                    .Skip(page * PageSize)
                    .Take(PageSize)
                    .Select(GameModel.FromGame);

            return this.Ok(result);
        }
    }
}