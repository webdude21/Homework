namespace FurnitureManufacturer.Engine.Factories
{
    using FurnitureManufacturer.Interfaces;
    using FurnitureManufacturer.Interfaces.Engine;
    using FurnitureManufacturer.Models;

    public class CompanyFactory : ICompanyFactory
    {
        public ICompany CreateCompany(string name, string registrationNumber)
        {
            return new Company(name, registrationNumber);
        }
    }
}