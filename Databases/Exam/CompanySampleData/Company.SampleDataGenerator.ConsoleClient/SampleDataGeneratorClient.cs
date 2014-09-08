namespace Company.SampleDataGenerator.ConsoleClient
{
    using System.Collections.Generic;

    using Company.Data;
    using Company.SampleDataGenerator.Factories;

    using RandomDataGenerator;

    internal class SampleDataGeneratorClient
    {
        private static void Main()
        {
            var databaseContext = new CompanyEntities();
            databaseContext.Configuration.AutoDetectChangesEnabled = false;
            var generatorFacotry = new CompanyGeneratorsFactory(new RandomDataGenerator(), new ConsoleLogger(), databaseContext, 100);
            var generators = new List<DataGenerator>
                                 {
                                     generatorFacotry.GetDepartmentGenerator(100),
                                     generatorFacotry.GetEmployeeGenerator(5000),
                                     generatorFacotry.GetProjectGenerator(100),
                                     generatorFacotry.GetReportGenerator(250)
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