namespace Application.Data.Contracts
{
    using Application.Models;

    public interface IApplicationData
    {
        IRepository<Article> Articles { get; }

        IRepository<Tag> Tags { get; }

        IRepository<Like> Likes { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Category> Categories { get; }

        void SaveChanges();
    }
}