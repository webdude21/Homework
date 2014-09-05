namespace ATM.Data
{
    using System.Data.Entity;

    using ATM.Data.Migrations;
    using ATM.Model;

    public class AtmDbContext : DbContext
    {
        public AtmDbContext()
            : base("АТМConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AtmDbContext, Configuration>());
        }

        public IDbSet<CardAccount> CardAccounts { get; set; }

        public IDbSet<TransactionsHistory> TransactionsHistories { get; set; }

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