namespace Cars.Search.ConsoleClient
{
    using Cars.Data;
    using Cars.Import.JSON.Helpers;

    internal class ConsoleClient
    {
        private static void Main()
        {
            // This particular project is of really low quality, but here i really didn't have time :)
            var xmlSearcher = new XmlSearcher(new CarsDbContext(), new ConsoleLogger());
        }
    }
}