namespace Application.WebServices.DataModels
{
    using System;
    using System.Linq.Expressions;

    using Application.Models;

    public class CommentModel
    {
        public static Expression<Func<Comment, CommentModel>> FromComment
        {
            get
            {
                return c => new CommentModel
                        {
                            Content = c.Content,
                            AuthorName = c.Author.UserName,
                            DateCreated = c.DateCreated,
                            Id = c.Id
                        };
            }
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string AuthorName { get; set; }
    }
}