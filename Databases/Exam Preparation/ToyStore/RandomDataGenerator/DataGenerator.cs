namespace RandomDataGenerator
{
    using global::RandomDataGenerator.Contracts;

    public abstract class DataGenerator : IDataGenerator
    {
        private readonly int count;

        private readonly int checkPointFrequency;

        protected DataGenerator(int count, IRandomDataGenerator random, ILogger logger, int checkPointFrequency = 1000)
        {
            this.checkPointFrequency = checkPointFrequency;
            this.count = count;
            this.Logger = logger;
            this.Random = random;
        }

        protected IRandomDataGenerator Random { get; private set; }

        protected ILogger Logger { get; private set; }

        public virtual void Generate()
        {
            for (var index = 0; index < this.count; index++)
            {
                this.GenerateEntity();

                if (index % this.checkPointFrequency == 0)
                {
                    this.CheckPoint(index);
                }
            }
        }

        protected abstract void GenerateEntity();

        protected virtual void CheckPoint(int countSofar)
        {
            this.Logger.LogLine("============================");
            this.Logger.LogLine(string.Format("Generated {0} so far", countSofar));
        }
    }
}