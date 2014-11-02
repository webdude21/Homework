namespace LaptopSystem.Data.Contracts
{
    using LaptopSystem.Model;

    public interface ILaptopSystemData
    {

        IRepository<ApplicationUser> Users { get; }

        void SaveChanges();
    }
}