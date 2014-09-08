namespace Cars.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Cars.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<CarsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "Cars.Data.CarsDbContext";
        }

        protected override void Seed(CarsDbContext context)
        {
            if (context.Cars.Any())
            {
                return;
            }


            var vw = new Manufacturer { Name = "Volkswagen" };
            var unionTrade = new Dealer { Name = "Union Trade" };
            var city = new City { Name = "Sofia", Dealers = { unionTrade }, Manufacturers = { vw } };
            var golf = new Car
                           {
                               Manufacturer = vw,
                               Dealer = unionTrade,
                               Model = "Golf",
                               TransmisionType = TransmisionType.Manual,
                               Year = 2014,
                               Price = 30000
                           };

            context.Cities.Add(city);
            context.Cars.Add(golf);
            context.SaveChanges();
        }
    }
}