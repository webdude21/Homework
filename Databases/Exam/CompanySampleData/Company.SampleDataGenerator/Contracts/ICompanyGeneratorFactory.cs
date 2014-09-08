namespace Company.SampleDataGenerator.Contracts
{
    using Company.SampleDataGenerator;
    using Company.SampleDataGenerator.Generators;

    internal interface ICompanyGeneratorFactory
    {
        DepartmentGenerator GetDepartmentGenerator(int objectCount);

        EmployeeGenerator GetEmployeeGenerator(int objectCount);

        ProjectGenerator GetProjectGenerator(int objectCount);

        ReportGenerator GetReportGenerator(int objectCount);
    }
}