namespace GenerateSampleData
{
    using System.Collections.Generic;

    using RandomDataGenerator;

    using ToyStore.Data;

    internal class ToyStoreSampleData
    {
        private static void Main()
        {
            GenerateSampleData();
        }

        private static void GenerateSampleData()
        {
            var random = RandomDataGenerator.Instance;
            var databaseContext = new ToyStoreEntities();
            var consoleLogger = new ConsoleLogger();
            databaseContext.Configuration.AutoDetectChangesEnabled = false;

            var toyFactory = new ToyGeneratorsFactory(random, consoleLogger, databaseContext);
            var generators = new List<DataGenerator>
                                 {
                                     toyFactory.GetAgeRangeGenerator(150),
                                     toyFactory.GetCategoriesGenerator(150),
                                     toyFactory.GetManufacturesGenerator(100),
                                     toyFactory.GetToyGenerator(20000)
                                 };

            foreach (var generator in generators)
            {
                generator.Generate();
                databaseContext.SaveChanges();
            }

            databaseContext.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}