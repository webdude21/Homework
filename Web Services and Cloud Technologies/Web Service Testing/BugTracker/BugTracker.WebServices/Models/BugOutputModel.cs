namespace BugTracker.WebServices.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    using BugTracker.Model;

    public class BugOutputModel
    {
        public static Expression<Func<Bug, BugOutputModel>> FromBug
        {
            get
            {
                return b => new BugOutputModel
                        {
                            Id = b.Id,
                            Status = b.Status,
                            Text = b.Text,
                            LogDate = b.LogDate
                        };
            }
        }

        public int Id { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(200)]
        public string Text { get; set; }

        public DateTime LogDate { get; set; }
    }
}