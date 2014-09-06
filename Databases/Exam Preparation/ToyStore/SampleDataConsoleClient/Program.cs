namespace ToyStore.SampleData
{
    using RandomDataGenerator;

    using SampleDataConsoleClient;

    using ToyStore.Data;

    internal class Program
    {
        private static void Main()
        {
            var random = RandomDataGenerator.Instance;
            var databaseContext = new ToyStoreEntities();
            var consoleLogger = new ConsoleLogger();

            var categoryGenerator = new CategoryGenerator(50, random, databaseContext, consoleLogger);
            var manufGenerator = new ManufacturerGenerator(50, random, databaseContext, consoleLogger);
            var categories = categoryGenerator.Generate();
        }
    }
}