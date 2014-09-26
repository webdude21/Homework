namespace BullsAndCows.WebServices.DataModels
{
    using System;
    using System.Linq.Expressions;

    using BullsAndCows.Models;

    public class GameModel
    {
        private const string NoBluePlayerYet = "No blue player yet";

        public GameModel(Game newGame)
        {
            this.DateCreated = newGame.DateCreated;
            this.GameState = newGame.GameState.ToString();
            this.Id = newGame.Id;
            this.Name = newGame.Name;
            this.Red = newGame.Red.UserName;
            this.Blue = NoBluePlayerYet;
        }

        public GameModel()
        {
        }

        public static Expression<Func<Game, GameModel>> FromGame
        {
            get
            {
                return
                    game =>
                    new GameModel
                        {
                            DateCreated = game.DateCreated, 
                            Id = game.Id, 
                            Name = game.Name, 
                            GameState = game.GameState.ToString(), 
                            Blue = game.Blue.UserName ?? NoBluePlayerYet, 
                            Red = game.Red.UserName, 
                        };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Red { get; set; }

        public string Blue { get; set; }

        public string GameState { get; set; }

        public DateTime DateCreated { get; set; }
    }
}