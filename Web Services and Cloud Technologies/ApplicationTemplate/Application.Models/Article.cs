namespace Application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Article
    {
        public Article()
        {
            this.Tags = new HashSet<Tag>();
            this.Likes = new HashSet<Like>();
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}