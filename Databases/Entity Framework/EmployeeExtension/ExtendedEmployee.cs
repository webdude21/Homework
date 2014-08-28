namespace EmployeeExtension
{
    using System.Data.Linq;

    using NortwindModel;

    public class ExtendedEmployee : Employee
    {
        public EntitySet<Territory> Territory { get; set; }
    }
}