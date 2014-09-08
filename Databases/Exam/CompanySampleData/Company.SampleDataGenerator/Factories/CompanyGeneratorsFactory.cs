namespace Company.SampleDataGenerator.Factories
{
    using Company.Data;
    using Company.SampleDataGenerator.Contracts;
    using Company.SampleDataGenerator.Generators;

    using RandomDataGenerator.Contracts;

    public class CompanyGeneratorsFactory : ICompanyGeneratorFactory
    {

        private readonly IRandomDataGenerator random;

        private readonly ILogger logger;

        private readonly CompanyEntities databaseContext;

        private readonly int checkPointFrequency;

        public CompanyGeneratorsFactory(IRandomDataGenerator random, ILogger logger, CompanyEntities databaseContext, int checkPointFrequency = 1000)
        {
            this.random = random;
            this.logger = logger;
            this.databaseContext = databaseContext;
            this.checkPointFrequency = checkPointFrequency;
        }

        public DepartmentGenerator GetDepartmentGenerator(int objectCount)
        {
            return new DepartmentGenerator(objectCount, this.random, this.logger, this.databaseContext, this.checkPointFrequency);
        }

        public EmployeeGenerator GetEmployeeGenerator(int objectCount)
        {
            return new EmployeeGenerator(objectCount, this.random, this.logger, this.databaseContext, this.checkPointFrequency);
        }

        public ProjectGenerator GetProjectGenerator(int objectCount)
        {
            return new ProjectGenerator(objectCount, this.random, this.logger, this.databaseContext, this.checkPointFrequency);
        }

        public ReportGenerator GetReportGenerator(int objectCount)
        {
            return new ReportGenerator(objectCount, this.random, this.logger, this.databaseContext, this.checkPointFrequency);
        }
    }
}