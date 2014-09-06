namespace Bookstore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Bookstore.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<BookstoreDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BookstoreDbContext context)
        {
            if (context.Books.Any())
            {
                return;
            }


            var author = context.Authors.Add(new Author { Name = "Dimo Petrov" });
            var author2 = context.Authors.Add(new Author { Name = "Georgi Gankov" });

            var myNewBook = context.Books.Add(
                new Book
                {
                    Authors = { author, author2 },
                    ISBN = "1234567890123",
                    OfficialWebsite = "http://webdude.eu",
                    Title = "The easy way of coding"
                });

            context.Reviews.Add(new Review { Book = myNewBook, Author = author, CreateDate = DateTime.Now });

            context.SaveChanges();
        }
    }
}