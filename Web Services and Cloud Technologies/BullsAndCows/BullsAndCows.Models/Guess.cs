namespace BullsAndCows.Models
{
    using System;

    public class Guess
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public string Number { get; set; }

        public virtual Game Game { get; set; }

        public int GameId { get; set; }

        public DateTime DateMade { get; set; }

        public int CowsCount { get; set; }

        public int BullsCount { get; set; }
    }
}