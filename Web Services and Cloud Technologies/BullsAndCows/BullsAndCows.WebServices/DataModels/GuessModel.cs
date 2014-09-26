namespace BullsAndCows.WebServices.DataModels
{
    using System;
    using System.Linq.Expressions;

    using BullsAndCows.Models;

    public class GuessModel
    {
        public GuessModel(Guess resultGuess, ApplicationUser user)
        {
            this.Id = resultGuess.Id;
            this.UserId = user.Id;
            this.Username = user.UserName;
            this.GameId = resultGuess.GameId;
            this.Number = resultGuess.Number;
            this.DateMade = resultGuess.DateMade;
            this.BullsCount = resultGuess.BullsCount;
            this.CowsCount = resultGuess.CowsCount;
        }

        public GuessModel()
        {
            
        }

        public static Expression<Func<Guess, GuessModel>> FromGuess
        {
            get
            {
                return g => new GuessModel
                        {
                            Id = g.Id,
                            BullsCount = g.BullsCount,
                            CowsCount = g.CowsCount,
                            DateMade = g.DateMade,
                            GameId = g.GameId,
                            Number = g.Number,
                            UserId = g.UserId,
                            Username = g.User.UserName
                        };
            }
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }

        public int GameId { get; set; }

        public string Number { get; set; }

        public DateTime DateMade { get; set; }

        public int CowsCount { get; set; }

        public int BullsCount { get; set; }
    }
}