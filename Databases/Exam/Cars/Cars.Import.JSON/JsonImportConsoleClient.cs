namespace Cars.Import.JSON
{
    using System.Linq;

    using Cars.Data;
    using Cars.Import.JSON.Helpers;

    internal class JsonImportConsoleClient
    {
        private static void Main()
        {
            var databaseContext = new CarsDbContext();
            databaseContext.Cars.Count();
            databaseContext.Configuration.AutoDetectChangesEnabled = false;
            const string JsonImportFilePath = @"..\..\input\";
            var jsonImporter = new JsonImporter(databaseContext, new ConsoleLogger());
            jsonImporter.ImportAll(JsonImportFilePath);
            databaseContext.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}