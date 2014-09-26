namespace BullsAndCows.Models
{
    using System;
    using System.Collections.Generic;

    public class Game
    {
        private ICollection<Guess> redGuesses;

        private ICollection<Guess> blueGuesses;

        public Game()
        {
            this.redGuesses = new HashSet<Guess>();
            this.blueGuesses = new HashSet<Guess>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ApplicationUser Blue { get; set; }

        public virtual ApplicationUser Red { get; set; }

        public string RedId { get; set; }

        public string BlueId { get; set; }

        public string RedNumber { get; set; }

        public string BlueNumber { get; set; }

        public GameState GameState { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<Guess> RedGuesses
        {
            get
            {
                return this.redGuesses;
            }

            set
            {
                this.redGuesses = value;
            }
        }

        public virtual ICollection<Guess> BlueGuesses
        {
            get
            {
                return this.blueGuesses;
            }

            set
            {
                this.blueGuesses = value;
            }
        }
    }
}