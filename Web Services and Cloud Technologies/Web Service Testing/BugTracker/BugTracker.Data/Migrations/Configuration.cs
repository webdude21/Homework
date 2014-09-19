namespace BugTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using BugTracker.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<BugTrackerDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BugTrackerDbContext context)
        {
            if (context.Bugs.Any())
            {
                return;
            }

            var bug = new Bug
                          {
                              LogDate = DateTime.Now, 
                              Status = Status.Pending, 
                              Text = "Something went wrong with the thing"
                          };

            var secondBug = new Bug
                                {
                                    LogDate = new DateTime(2013, 12, 12), 
                                    Status = Status.Fixed, 
                                    Text = "Evil bug appeared!"
                                };

            context.Bugs.Add(bug);
            context.Bugs.Add(secondBug);

            context.SaveChanges();
        }
    }
}