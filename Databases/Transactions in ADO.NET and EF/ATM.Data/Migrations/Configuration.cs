namespace ATM.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using ATM.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<AtmDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AtmDbContext context)
        {
            if (context.CardAccounts.Any())
            {
                return;
            }

            context.CardAccounts.Add(
                new CardAccount { CardCash = 2000.2m, CardNumber = "2133142112", CardPin = "1234" });
            context.CardAccounts.Add(
                new CardAccount { CardCash = 20m, CardNumber = "1232124124", CardPin = "2345" });
            context.CardAccounts.Add(
                new CardAccount { CardCash = 1503.5m, CardNumber = "7878898990", CardPin = "4567" });
            context.CardAccounts.Add(
                new CardAccount { CardCash = 245m, CardNumber = "5656565678", CardPin = "7890" });
        }
    }
}