namespace ToyStore.Data
{
    using RandomDataGenerator;
    using RandomDataGenerator.Contracts;

    public class ToyGeneratorsFactory
    {
        private readonly IRandomDataGenerator random;

        private readonly ILogger logger;

        private readonly ToyStoreEntities databaseContext;

        private readonly int checkPointFrequency;

        public ToyGeneratorsFactory(IRandomDataGenerator random, ILogger logger, ToyStoreEntities databaseContext, int checkPointFrequency = 1000)
        {
            this.random = random;
            this.logger = logger;
            this.databaseContext = databaseContext;
            this.checkPointFrequency = checkPointFrequency;
        }

        public ToyGeneratorsFactory()
            : this(RandomDataGenerator.Instance, new ConsoleLogger(), new ToyStoreEntities())
        {
        }

        public CategoriesGenerator GetCategoriesGenerator(int objectCount)
        {
            return new CategoriesGenerator(objectCount, this.random, this.logger, this.databaseContext, this.checkPointFrequency);
        }

        public ManufacturesGenerator GetManufacturesGenerator(int objectCount)
        {
            return new ManufacturesGenerator(objectCount, this.random, this.logger, this.databaseContext, this.checkPointFrequency);
        }

        public AgeRangeGenerator GetAgeRangeGenerator(int objectCount)
        {
            return new AgeRangeGenerator(objectCount, this.random, this.logger, this.databaseContext, this.checkPointFrequency);
        }

        public ToyGenerator GetToyGenerator(int objectCount)
        {
            return new ToyGenerator(objectCount, this.random, this.logger, this.databaseContext, this.checkPointFrequency);
        }
    }
}