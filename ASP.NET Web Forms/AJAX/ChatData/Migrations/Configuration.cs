namespace ChatData.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using ChatData.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ChatDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ChatDbContext context)
        {
            if (context.Messages.Any())
            {
                return;
            }

            context.Messages.Add(new Message { Author = "Pesho", Body = "������� 1" });
            context.Messages.Add(new Message { Author = "����", Body = "������� 2" });
            context.Messages.Add(new Message { Author = "����", Body = "������� 3" });
            context.Messages.Add(new Message { Author = "������", Body = "������� 4" });
            context.SaveChanges();
        }
    }
}