namespace Bookstore.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Review
    {
        private Author author;

        public Review()
        {
            this.author = new Author();
        }

        public int Id { get; set; }

        public virtual Book Book { get; set; }

        public string Text { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public virtual Author Author
        {
            get
            {
                return this.author;
            }

            set
            {
                this.author = value;
            }
        }
    }
}