namespace Application.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Application.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DbContext context)
        {
            if (context.Articles.Any())
            {
                return;
            }

            var article = new Article
                              {
                                  Title = "Some Random Title",
                                  Content =
                                      "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum",
                                  Category = new Category { Name = "Testing" },
                                  DateCreated = DateTime.Now
                              };

            context.Articles.Add(article);
            context.SaveChanges();
        }
    }
}