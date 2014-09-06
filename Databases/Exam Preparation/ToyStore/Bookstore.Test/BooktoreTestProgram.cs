namespace Bookstore.Test
{
    using System;

    using Bookstore.Model;

    internal class BooktoreTestProgram
    {
        private static void Main()
        {
            var bookstoreDbContext = new BookstoreDbContext();

            foreach (var book in bookstoreDbContext.Books)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}