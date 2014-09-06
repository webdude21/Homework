namespace RandomDataGenerator.Generic
{
    using System.Collections.Generic;
    using System.Data.Entity;

    using global::RandomDataGenerator.Generic.Contracts;

    public abstract class DataGenerator<T> : IDataGenerator<T>
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

        public virtual HashSet<T> Generate()
        {
            var hashTable = new HashSet<T>();

            for (var index = 0; index < this.count; index++)
            {
                hashTable.Add(this.GenerateEntity());
                if (index % this.saveFrequoncy == 0)
                {
                    this.SaveCheckpoint(index);
                }
            }

            return hashTable;
        }

        protected abstract T GenerateEntity();

        protected virtual void SaveCheckpoint(int countSofar)
        {
            this.Logger.LogLine("============================");
            this.Logger.LogLine(string.Format("Generated {0} so far", countSofar));
            this.DatabaseContext.SaveChanges();
            this.Logger.LogLine("Saving Changes...");
        }
    }
}