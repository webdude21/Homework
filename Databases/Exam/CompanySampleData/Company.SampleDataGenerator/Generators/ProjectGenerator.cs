namespace Company.SampleDataGenerator.Generators
{
    using System.Collections.Generic;
    using System.Linq;

    using Company.Data;

    using RandomDataGenerator;
    using RandomDataGenerator.Contracts;

    public class ProjectGenerator : DataGenerator
    {
        private readonly CompanyEntities databaseContext;

        private IReadOnlyList<int> employees;

        public ProjectGenerator(int count, IRandomDataGenerator random, ILogger logger, CompanyEntities databaseContext, int checkPointFrequency = 1000)
            : base(count, random, logger, checkPointFrequency)
        {
            this.databaseContext = databaseContext;
        }


        public override void Generate()
        {
            this.RetrieveDependencies();
            Logger.LogLine("Generating Projects");
            base.Generate();
        }

        protected override void GenerateEntity()
        {
            var project = new Project { Name = Random.GetString(5, 45)};

            var employeeCount = Random.GetInt(2, 20);
            var employeesForProject = new HashSet<int>();

            while (employeesForProject.Count < employeeCount)
            {
                employeesForProject.Add(this.employees[Random.GetInt(0, this.employees.Count - 1)]);
            }

            foreach (var employee in employeesForProject)
            {
                var startDate = Random.GeneraDateTime();
                var endDate = Random.GeneraDateTime();

                if (startDate > endDate)
                {
                    var switchDates = startDate;
                    startDate = endDate;
                    endDate = switchDates;
                }

                project.EmployeesProjects.Add(new EmployeesProject{ EmployeeId = employee, ProjectId = project.Id, EndingDate = endDate, StartingDate = startDate});
            }

            this.databaseContext.Projects.Add(project);
        }

        private void RetrieveDependencies()
        {
            this.employees = this.databaseContext.Employees.Select(man => man.Id).ToArray();
        }
    }
}