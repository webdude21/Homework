
namespace LaptopSystem.Web.Models
{
    using System.Linq.Expressions;

    using Antlr.Runtime.Misc;

    using LaptopSystem.Model;

    public class CommentViewModel
    {
        public static Expression<Func<Comment, CommentViewModel>> GetFromComment
        {
            get
            {
                return comment => new CommentViewModel { AuthorUserName = comment.Author.UserName, Content = comment.Content };
            }
        }

        public string Content { get; set; }

        public string AuthorUserName { get; set; }
    }
}