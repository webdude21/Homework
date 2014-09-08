namespace Company.SampleDataGenerator.Generators
{
    using Company.Data;

    using RandomDataGenerator;
    using RandomDataGenerator.Contracts;

    public class DepartmentGenerator : DataGenerator
    {
        private readonly CompanyEntities databaseContext;

        public DepartmentGenerator(int count, IRandomDataGenerator random, ILogger logger, CompanyEntities databaseContext, int checkPointFrequency = 1000)
            : base(count, random, logger, checkPointFrequency)
        {
            this.databaseContext = databaseContext;
        }

        public override void Generate()
        {
            this.Logger.LogLine("Generating Departments");
            base.Generate();
        }

        protected override void GenerateEntity()
        {
            this.databaseContext.Departments.Add(new Department { Name = this.Random.GetString(10, 50) });
        }
    }
}