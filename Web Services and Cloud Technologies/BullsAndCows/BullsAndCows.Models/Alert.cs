namespace BullsAndCows.Models
{
    using System;

    public class Alert
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}