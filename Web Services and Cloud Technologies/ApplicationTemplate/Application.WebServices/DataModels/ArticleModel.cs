namespace Application.WebServices.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    using Application.Models;

    public class ArticleModel
    {
        public static Expression<Func<Article, ArticleModel>> FromArticle
        {
            get
            {
                return a => new ArticleModel
                        {
                            DateCreated = a.DateCreated,
                            Category = a.Category.Name,
                            Content = a.Content,
                            Title = a.Title,
                            Id = a.Id,
                            Tags = a.Tags.Select(t => t.Name)
                        };
            }
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string Category { get; set; }

        public IEnumerable<string> Tags { get; set; } 
    }
}