namespace Bookstore.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Book
    {
        public Book()
        {
            this.Authors = new HashSet<Author>();
            this.Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(250)]
        [Required]
        public string Title { get; set; }

        [StringLength(13)]
        //[Index("ISBN", 1, IsUnique = true)]
        public string ISBN { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

        public virtual ICollection<Review> Reviews { get; set; } 
        
        [MinLength(5)]
        [MaxLength(260)]
        public string OfficialWebsite { get; set; }

        [Column(TypeName = "Money")]
        public decimal? Price { get; set; }
    }
}