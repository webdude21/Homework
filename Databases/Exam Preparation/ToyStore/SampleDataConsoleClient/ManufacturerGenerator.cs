namespace SampleDataConsoleClient
{
    using System.Collections.Generic;

    using RandomDataGenerator;
    using RandomDataGenerator.Contracts;

    using ToyStore.Data;

    internal class ManufacturerGenerator : DataGenerator<Manufacturer>
    {
        public ManufacturerGenerator(int count, IRandomDataGenerator random, ToyStoreEntities databaseContext, ILogger logger, int saveFrequoncy = 1000)
            : base(count, random, databaseContext, logger, saveFrequoncy)
        {
            this.DatabaseContext = databaseContext;
        }

        protected new ToyStoreEntities DatabaseContext { get; set; }

        public override HashSet<Manufacturer> Generate()
        {
            this.Logger.LogLine("Generating Manufacturers");
            return base.Generate();
        }

        protected override Manufacturer GenerateEntity()
        {
           return this.DatabaseContext.Manufacturers.Add(
                  new Manufacturer { Country = this.Random.GetString(3, 40), Name = this.Random.GetString(3, 40) });
        }
    }
}