namespace Data.Contracts
{
    using Bookstore.Model;

    internal interface IBookstoreData
    {
        GenericRepository<Book> Books { get; }

        GenericRepository<Author> Authors { get; }

        GenericRepository<Review> Reviews { get; }

        void SaveChanges();
    }
}