namespace RandomDataGenerator
{
    using global::RandomDataGenerator.Contracts;

    public abstract class DataGenerator : IDataGenerator
    {

        protected DataGenerator(int count, IRandomDataGenerator random, ILogger logger, int checkPointFrequency = 1000)
        {
            this.CheckPointFrequency = checkPointFrequency;
            this.Count = count;
            this.Logger = logger;
            this.Random = random;
        }

        protected int Count { get; private set; }

        protected int CheckPointFrequency { get; private set; }

        protected IRandomDataGenerator Random { get; private set; }

        protected ILogger Logger { get; private set; }

        public virtual void Generate()
        {
            this.Logger.LogLine(string.Format("Generating entities"));

            for (var index = 0; index < this.Count; index++)
            {
                this.GenerateEntity();

                if (index % this.CheckPointFrequency == 0)
                {
                    this.CheckPoint();
                }
            }

            this.CheckPoint();
        }

        protected abstract void GenerateEntity();

        protected virtual void CheckPoint()
        {
            this.Logger.Log(".");
        }
    }
}