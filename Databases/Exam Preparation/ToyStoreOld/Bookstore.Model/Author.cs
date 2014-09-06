namespace Bookstore.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Author
    {
        public Author()
        {
            this.Books = new HashSet<Book>();
            this.Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(250)]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}