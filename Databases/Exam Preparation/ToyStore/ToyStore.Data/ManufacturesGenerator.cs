namespace ToyStore.Data
{
    using RandomDataGenerator;
    using RandomDataGenerator.Contracts;

    public class ManufacturesGenerator : DataGenerator
    {
        private readonly ToyStoreEntities databaseContext;

        public ManufacturesGenerator(int count, IRandomDataGenerator random, ILogger logger, ToyStoreEntities databaseContext, int checkPointFrequency = 1000)
            : base(count, random, logger, checkPointFrequency)
        {
            this.databaseContext = databaseContext;
        }

        protected override void GenerateEntity()
        {
            this.databaseContext.Manufacturers.Add(new Manufacturer { Name = this.Random.GetString(5, 45), Country = this.Random.GetString(5, 45) });
        }

        protected override void CheckPoint()
        {
            this.databaseContext.SaveChanges();
            base.CheckPoint();
        }
    }
}