namespace Company.SampleDataGenerator.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Company.Data;

    using RandomDataGenerator;
    using RandomDataGenerator.Contracts;

    public class ReportGenerator : DataGenerator
    {
        private readonly CompanyEntities databaseContext;

        private IReadOnlyList<int> employeeIds;

        public ReportGenerator(int count, IRandomDataGenerator random, ILogger logger, CompanyEntities databaseContext, int checkPointFrequency = 1000)
            : base(count, random, logger, checkPointFrequency)
        {
            this.databaseContext = databaseContext;
        }

        public override void Generate()
        {
            this.RetrieveDependencies();
            this.Logger.LogLine("Generating Reports");
            base.Generate();
        }


        protected override void GenerateEntity()
        {
            var report = new Report();

            if (this.employeeIds.Count > 0)
            {
                     report.EmployeeId = this.Random.GetInt(0, this.employeeIds.Count - 1);
                     report.Time = DateTime.Now;
                this.databaseContext.Reports.Add(report);
            }
            else
            {
                throw new Exception("The are now employees in the database");
            }
        }

        private void RetrieveDependencies()
        {
            this.employeeIds = this.databaseContext.Employees.Select(emp => emp.Id).ToArray();
        }
    }
}