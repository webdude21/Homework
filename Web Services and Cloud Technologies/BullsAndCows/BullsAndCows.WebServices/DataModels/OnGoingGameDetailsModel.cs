namespace BullsAndCows.WebServices.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BullsAndCows.Models;

    public class OnGoingGameDetailsModel
    {
        public OnGoingGameDetailsModel(ApplicationUser user, Game game)
        {
            this.Id = game.Id;
            this.Name = game.Name;
            this.DateCreated = game.DateCreated;
            this.Blue = game.Blue.UserName;
            this.Red = game.Red.UserName;

            if (user == game.Red)
            {
                this.YourNumber = game.RedNumber;
                this.YourGuesses = game.RedGuesses.AsQueryable().Select(GuessModel.FromGuess).ToArray();
            }

            if (user == game.Blue)
            {
                this.YourNumber = game.BlueNumber;
                this.YourGuesses = game.BlueGuesses.AsQueryable().Select(GuessModel.FromGuess).ToArray();
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Blue { get; set; }

        public string Red { get; set; }

        public DateTime DateCreated { get; set; }

        public string YourNumber { get; set; }

        public ICollection<GuessModel> YourGuesses { get; set; }
    }
}