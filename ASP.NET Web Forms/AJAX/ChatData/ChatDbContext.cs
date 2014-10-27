namespace ChatData
{
    using System.Data.Entity;

    using ChatData.Migrations;
    using ChatData.Models;

    public class ChatDbContext : DbContext
    {
        public ChatDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ChatDbContext, Configuration>());
        }

        public IDbSet<Message> Messages { get; set; }
    }
}