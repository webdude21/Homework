namespace Application.Data.Contracts
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Application.Models;

    public interface IDbContext
    {
        IDbSet<Category> Categories { get; set; }

        IDbSet<Like> Likes { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Tag> Tags { get; set; }

        IDbSet<Article> Articles { get; set; }

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        IDbSet<T> Set<T>() where T : class;

        int SaveChanges();
    }
}