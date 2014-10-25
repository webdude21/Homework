namespace Visitors.Data
{
    using System.Data.Entity;

    public class CounterContext : DbContext
    {
        public CounterContext()
            : base("CounterDb")
        {
        }

        public DbSet<Visitor> Visitors { get; set; }
    }
}