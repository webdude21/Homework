namespace Bookstore.Data
{
    using System.Data.Entity;

    using Bookstore.Data.Migrations;
    using Bookstore.Model;

    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext()
            : base("BookstoreConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookstoreDbContext, Configuration>());
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Review> Reviews { get; set; }

        public IDbSet<Author> Authors { get; set; }

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