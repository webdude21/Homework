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

    [Authorize]
    public class GuessController : BaseController
    {
        private const string YouCannotMakeGuessesInAGameThatYouReNotPartOf = "You cannot make guesses in a game that you're not part of!";

        private const string ItsNotYourTurn = "It's not your turn";

        private const string ItsYourTurn = "It is your turn in game {0}";

        private const string YouHaveWon = "You beat {0} in game {1}";

        private const string YouLostTo = "{0} beat you in game {1}";

        private const string GameClosed = "You cannot take part in this game because it has finished!";

        public GuessController(IBullsAndCowsData bullsAndCowsData)
            : base(bullsAndCowsData)
        {
        }

        public GuessController()
        {
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult Create(int id, MakeGuessModel guess)
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
                return this.BadRequest(GameClosed);
            }

            if (game.GameState == GameState.WaitingForOpponent)
            {
                return this.BadRequest(YouCannotMakeGuessesInAGameThatYouReNotPartOf);
            }

            var userId = this.User.Identity.GetUserId();
            var user = this.BullsAndCowsData.Users.All().First(u => u.Id == userId);

            if (this.CheckIfAValidPlayer(game, user))
            {
                return this.BadRequest(YouCannotMakeGuessesInAGameThatYouReNotPartOf);
            }

            if (this.CheckTurn(game, user))
            {
                return this.BadRequest(ItsNotYourTurn);
            }

            var resultGuess = this.BuildGuess(guess, game, user);

            this.ChechForWinner(guess, game, user);

            return this.Ok(new GuessModel(resultGuess, user));
        }

        private void ChechForWinner(MakeGuessModel guess, Game game, ApplicationUser user)
        {
            if (user.Id == game.RedId && guess.Number == game.BlueNumber)
            {
                game.GameState = GameState.Finished;
                this.SendWinnerNotification(user, game);
            }

            if (user.Id == game.BlueId && guess.Number == game.RedNumber)
            {
                game.GameState = GameState.Finished;
                this.SendWinnerNotification(user, game);
            }
        }

        private void SendWinnerNotification(ApplicationUser user, Game game)
        {
            var otherUser = game.Red == user ? game.Blue : game.Red;

            var newnotification = new Notification
            {
                User = otherUser,
                Message = string.Format(YouLostTo, user.UserName, game.Name),
                State = NotificationState.Unread,
                DateCreated = DateTime.Now,
                Game = game,
                GameId = game.Id,
                Type = NotificationType.GameLost,
            };


            user.Notifications.Add(new Notification
                                       {
                                           User = user,
                                           Message =
                                               string.Format(YouHaveWon, otherUser.UserName, game.Name),
                                           State = NotificationState.Unread,
                                           DateCreated = DateTime.Now,
                                           Game = game,
                                           GameId = game.Id,
                                           Type = NotificationType.GameWon,
                                       });

            otherUser.Notifications.Add(newnotification);
            this.BullsAndCowsData.SaveChanges();
        }

        private Guess BuildGuess(MakeGuessModel guess, Game game, ApplicationUser user)
        {
            var bullCount = 0;
            var cowCount = 0;

            if (user == game.Red)
            {
                GameManager.CountBullsAndCows(guess.Number, game.BlueNumber, out bullCount, out cowCount);
            }

            if (user == game.Blue)
            {
                GameManager.CountBullsAndCows(guess.Number, game.RedNumber, out bullCount, out cowCount);
            }

            var newGuess = new Guess
            {
                DateMade = DateTime.Now,
                Number = guess.Number,
                BullsCount = bullCount,
                CowsCount = cowCount,
                User = user,
                Game = game,
            };


            if (user == game.Red)
            {
                this.BullsAndCowsData.Games.All().First().RedGuesses.Add(newGuess);
                game.GameState = GameState.BlueInTurn;

            }

            if (user == game.Blue)
            {
                this.BullsAndCowsData.Games.All().First().BlueGuesses.Add(newGuess);
                game.GameState = GameState.RedInTurn;
            }

            this.SendNotification(user, game);
            this.BullsAndCowsData.SaveChanges();
            return newGuess;
        }

        private void SendNotification(ApplicationUser user, Game game)
        {
            var otherUser = game.Red == user ? game.Blue : game.Red;

            var newnotification = new Notification
            {
                User = otherUser,
                Message =
                    string.Format(ItsYourTurn, game.Name),
                State = NotificationState.Unread,
                DateCreated = DateTime.Now,
                Game = game,
                GameId = game.Id,
                Type = NotificationType.YourTurn,
            };

            otherUser.Notifications.Add(newnotification);
            this.BullsAndCowsData.SaveChanges();
        }

        private bool CheckIfAValidPlayer(Game game, ApplicationUser user)
        {
            return game.RedId != user.Id && game.BlueId != user.Id;
        }

        private bool CheckTurn(Game game, ApplicationUser user)
        {
            return (game.Red == user && game.GameState == GameState.BlueInTurn) || (game.Blue == user && game.GameState == GameState.RedInTurn);
        }
    }
}