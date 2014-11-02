namespace LaptopSystem.Data
{
    using System.Data.Entity;

    using LaptopSystem.Data.Contracts;
    using LaptopSystem.Data.Migrations;
    using LaptopSystem.Model;

    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class LaptopSystemDbContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public LaptopSystemDbContext()
            : base("DefaultConnection", false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LaptopSystemDbContext, Configuration>());
        }


        public static LaptopSystemDbContext Create()
        {
            return new LaptopSystemDbContext();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}