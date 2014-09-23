namespace Application.Data
{
    using System.Data.Entity;

    using Application.Data.Contracts;
    using Application.Data.Migrations;
    using Application.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class DbContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public DbContext() : base("DefaultConnection", false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DbContext, Configuration>());
        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Like> Likes { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<Alert> Alerts { get; set; } 

        public static DbContext Create()
        {
            return new DbContext();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}