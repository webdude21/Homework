namespace Data
{
    using System.Data.Entity;

    using Bookstore.Model;

    using Data.Contracts;
    using Data.Migrations;

    public class BookstoreDbContext : DbContext, IDbContext
    {
        public BookstoreDbContext() : base("BookstoreConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookstoreDbContext, Configuration>());
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Review> Reviews { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}