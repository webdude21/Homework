namespace BugTracker.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Bug
    {
        public int Id { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(200)]
        public string Text { get; set; }

        [Required]
        public DateTime LogDate { get; set; }
    }
}