namespace Bookstore.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Review
    {
        public int Id { get; set; }

        public virtual Book Book { get; set; }

        public string Text { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public virtual Author Author { get; set; }
    }
}