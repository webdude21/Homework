namespace ToyStore.Data
{
    using RandomDataGenerator;
    using RandomDataGenerator.Contracts;

    public class AgeRangeGenerator : DataGenerator
    {
        private readonly ToyStoreEntities databaseContext;

        public AgeRangeGenerator(int count, IRandomDataGenerator random, ILogger logger, ToyStoreEntities databaseContext, int checkPointFrequency = 1000)
            : base(count, random, logger, checkPointFrequency)
        {
            this.databaseContext = databaseContext;
        }

        protected override void GenerateEntity()
        {
            var upperBound = Random.GetInt(1, 12);
            var lowerBound = Random.GetInt(0, upperBound);
            this.databaseContext.AgeRanges.Add(new AgeRanx { MinAge = (byte)lowerBound, MaxAge = (byte)upperBound });
        }

        protected override void CheckPoint()
        {
            this.databaseContext.SaveChanges();
            base.CheckPoint();
        }
    }
}