namespace Application.WebServices.DataModels
{
    using System;
    using System.Linq.Expressions;

    using Application.Models;

    public class LikeModel
    {
        public static Expression<Func<Like, LikeModel>> FromLike
        {
            get
            {
                return like => new LikeModel
                                {
                                    Id = like.Id, 
                                    DateCreated = like.DateCreated, 
                                    AuthorName = like.User.UserName
                                };
            }
        }

        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string AuthorName { get; set; }
    }
}