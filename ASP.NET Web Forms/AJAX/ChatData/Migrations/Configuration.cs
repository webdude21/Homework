namespace ChatData.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using ChatData.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ChatDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ChatDbContext context)
        {
            if (context.Messages.Any())
            {
                return;
            }

            context.Messages.Add(new Message { Author = "Pesho", "Ебасиму 1" });
            context.Messages.Add(new Message { Author = "Гошо", "Ебасиму 2" });
            context.Messages.Add(new Message { Author = "Иван", "Ебасиму 3" });
            context.Messages.Add(new Message { Author = "Мариан", "Ебасиму 4" });
            context.SaveChanges();
        }
    }
}