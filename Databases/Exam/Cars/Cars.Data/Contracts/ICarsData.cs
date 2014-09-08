namespace Cars.Data.Contracts
{
    using Cars.Model;

    internal interface ICarsData
    {
        GenericRepository<Car> Cars { get; }

        GenericRepository<Dealer> Dealers { get; }

        GenericRepository<City> Cities { get; }

        GenericRepository<Manufacturer> Manufacturers { get; }

        void SaveChanges();
    }
}