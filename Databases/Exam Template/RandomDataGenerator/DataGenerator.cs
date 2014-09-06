namespace RandomDataGenerator
{
    using System.Data.Entity;

    using global::RandomDataGenerator.Contracts;

    public abstract class DataGenerator : IDataGenerator
    {
        private readonly int count;

        private readonly int saveFrequoncy;

        protected DataGenerator(int count, IRandomDataGenerator random, DbContext databaseContext,  ILogger logger, int saveFrequoncy = 1000)
        {
            this.DatabaseContext = databaseContext;
            this.saveFrequoncy = saveFrequoncy;
            this.count = count;
            this.Logger = logger;
            this.Random = random;
        }

        protected DbContext DatabaseContext { get; set; }

        protected IRandomDataGenerator Random { get; private set; }

        protected ILogger Logger { get; private set; }

        public virtual void Generate()
        {
            for (var index = 0; index < this.count; index++)
            {
                if (index % this.saveFrequoncy == 0)
                {
                    this.SaveCheckpoint(index);
                }
            }
        }

        protected abstract void GenerateEntity();

        protected virtual void SaveCheckpoint(int countSofar)
        {
            this.Logger.LogLine("============================");
            this.Logger.LogLine(string.Format("Generated {0} so far", countSofar));
            this.DatabaseContext.SaveChanges();
            this.Logger.LogLine("Saving Changes...");
        }
    }
}