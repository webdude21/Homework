namespace Bookstore.XmlImport
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Xml.Linq;

    using Bookstore.Model;

    using Data;

    internal class XmlImport
    {
        private static void Main()
        {
            const string CatalogPath = "../../complex-books.xml";
            var bookstoreDbContext = new BookstoreData(new BookstoreDbContext());
            bookstoreDbContext.Reviews.Count();

            var document = XDocument.Load(CatalogPath);

            var books = document.Descendants("book");

            foreach (var book in books)
            {
                ParseBook(bookstoreDbContext, book);
                bookstoreDbContext.Authors.SaveChanges();
            }
        }

        private static void ParseBook(BookstoreData bookstoreDbContext, XElement book)
        {

            var titleElement = book.Element("title");

            if (titleElement == null)
            {
                throw new ArgumentNullException();
            }

            var authorsElement = book.Element("authors");
            var websiteElement = book.Element("web-site");
            var isbnElement = book.Element("isbn");
            var reviewsElement = book.Element("reviews");
            var priceElement = book.Element("price");
            decimal? price = null;

            if (priceElement != null)
            {
                price = decimal.Parse(priceElement.Value, CultureInfo.InvariantCulture);
            }

            var reviews = new HashSet<Review>();

            if (reviewsElement != null)
            {
                ExtractReviews(bookstoreDbContext, reviewsElement);
            }

            string isbn = null;

            if (isbnElement != null)
            {
                isbn = isbnElement.Value;
            }

            string website = null;

            if (websiteElement != null)
            {
                website = websiteElement.Value;
            }

            ICollection<Author> authors = new HashSet<Author>();

            if (authorsElement != null)
            {
                ExtractAuthors(bookstoreDbContext, authorsElement, authors);
            }

            bookstoreDbContext.Books.Add(
                new Book
                {
                    Title = titleElement.Value,
                    Authors = authors,
                    OfficialWebsite = website,
                    ISBN = isbn,
                    Reviews = reviews,
                    Price = price
                });
        }

        private static void ExtractAuthors(BookstoreData bookstoreDbContext, XElement authorsElement, ICollection<Author> authors)
        {
            var extractedAuthors = from auth in authorsElement.Descendants("author") where auth.Value != null select auth.Value;

            foreach (var authorName in extractedAuthors)
            {
                var authorToAdd = bookstoreDbContext.Authors.FirstOrDefault(auth => auth.Name == authorName) ??
                    bookstoreDbContext.Authors.Add(new Author { Name = authorName });

                authors.Add(authorToAdd);
            }
        }

        private static void ExtractReviews(BookstoreData bookstoreDbContext, XElement reviewsElement)
        {
            var extractedReviews = from review in reviewsElement.Descendants("review") where review.Value != null select review;

            foreach (var review in extractedReviews)
            {
                var authorAtrrib = review.Attribute("author");
                var dateAttrib = review.Attribute("date");
                var reviewDateTime = DateTime.Now;

                if (dateAttrib != null)
                {
                    var dateToparse = dateAttrib.Value;
                    reviewDateTime = DateTime.Parse(dateToparse);
                }

                Author author = null;

                if (authorAtrrib != null)
                {
                    author = bookstoreDbContext.Authors.FirstOrDefault(auth => auth.Name == authorAtrrib.Value);
                }

                bookstoreDbContext.Reviews.Add(new Review { Text = review.Value, Author = author, CreateDate = reviewDateTime });
            }
        }
    }
}