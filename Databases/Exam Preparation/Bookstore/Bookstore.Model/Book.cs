namespace Bookstore.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Book
    {
        private ICollection<Author> authors;

        private ICollection<Review> reviews;

        public Book()
        {
            this.authors = new HashSet<Author>();
            this.reviews = new HashSet<Review>();
        }

        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(250)]
        [Required]
        public string Title { get; set; }

        [StringLength(13)]
        [Index("ISBN", IsUnique = true)]

        // ReSharper disable once InconsistentNaming
        public string ISBN { get; set; }

        public virtual ICollection<Author> Authors
        {
            get
            {
                return this.authors;
            }

            set
            {
                this.authors = value;
            }
        }

        public virtual ICollection<Review> Reviews
        {
            get
            {
                return this.reviews;
            }
            set
            {
                this.reviews = value;
            }
        }

        [MinLength(5)]
        [MaxLength(260)]
        public string OfficialWebsite { get; set; }

        [Column(TypeName = "Money")]
        public decimal? Price { get; set; }

    }
}