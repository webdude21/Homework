namespace Cars.Data
{
    using System.Data.Entity;

    using Cars.Data.Contracts;
    using Cars.Data.Migrations;
    using Cars.Model;

    public class CarsDbContext : DbContext, IDbContext
    {
        public CarsDbContext() : base("CarsConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDbContext, Configuration>());
        }

        public IDbSet<Car> Cars { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<Dealer> Dealers { get; set; }

        public IDbSet<City> Cities { get; set; }

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