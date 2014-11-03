namespace LaptopSystem.Data.Contracts
{
    using LaptopSystem.Model;

    public interface ILaptopSystemData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Laptop> Laptops { get; }

        IRepository<Manufacturer> Manufactures { get; }

        IRepository<Vote> Votes { get; }

        IRepository<Comment> Comments { get; }

        void SaveChanges();
    }
}