namespace MySQQLBooks
{
    using System;

    using MySql.Data.MySqlClient;

    internal class MySqlConn
    {
        private const string ConnectionString = "Server=.; Port=3306; Database=bookStores; Uid=root; Pwd=1234; pooling=true";

        private static void Main()
        {
            ReadBooksInfo();
            SearchForBook("pe");
            AddBook("My Dat", new DateTime(2012, 5, 2), 226344556, "Petar Petrov");
        }

        private static void AddBook(string bookName, DateTime datePublish, long isbn, string author)
        {
            using (var mySqlConnection = new MySqlConnection(ConnectionString))
            {
                mySqlConnection.Open();
                using (mySqlConnection)
                {
                    var bookStr = "INSERT INTO books " + "(titleBook, publishDate, ISBN) VALUES " + "(@title, @date, @isbn)";
                    var addBook = new MySqlCommand(bookStr, mySqlConnection);
                    addBook.Parameters.AddWithValue("@title", bookName);
                    addBook.Parameters.AddWithValue("@date", datePublish);
                    addBook.Parameters.AddWithValue("@isbn", isbn);
                    addBook.ExecuteNonQuery();

                    var cmdSelectIdentity = new MySqlCommand("SELECT @@Identity", mySqlConnection);
                    var insertedRecordId = (ulong)cmdSelectIdentity.ExecuteScalar();

                    var authorStr = "INSERT INTO authors " + "(Books_idBooks, AuthorName) VALUES " + "(@bookId, @name)";
                    var addAuthor = new MySqlCommand(authorStr, mySqlConnection);
                    addAuthor.Parameters.AddWithValue("@bookId", (int)insertedRecordId);
                    addAuthor.Parameters.AddWithValue("@name", author);
                    addAuthor.ExecuteNonQuery();
                }
            }
        }

        private static void SearchForBook(string input)
        {
            using (var mySqlConnection = new MySqlConnection(ConnectionString))
            {
                mySqlConnection.Open();
                using (mySqlConnection)
                {
                    const string SqlStr = "USE `bookStores` ; SELECT AuthorName, titleBook, publishDate, ISBN  FROM books "
                                          + "JOIN authors " + "ON authors.Books_idBooks = books.idBooks "
                                          + "WHERE titleBook LIKE @input";
                    var cmdParam = new MySqlParameter("@input", "%" + input + "%");
                    var cmd = new MySqlCommand(SqlStr, mySqlConnection);
                    cmd.Parameters.Add(cmdParam);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var author = (string)reader["AuthorName"];
                        var title = (string)reader["titleBook"];
                        var date = (DateTime)reader["publishDate"];
                        var isbn = (long)reader["ISBN"];
                        Console.WriteLine("{0}: {1} {2} {3}", author, title, date, isbn);
                    }
                }
            }
        }

        private static void ReadBooksInfo()
        {
            using (var mySqlConnection = new MySqlConnection(ConnectionString))
            {
                mySqlConnection.Open();
                using (mySqlConnection)
                {
                    var sqlStr = "USE `bookStores` ; SELECT AuthorName, titleBook, publishDate, ISBN  FROM books "
                                 + "JOIN authors " + "ON authors.Books_idBooks = books.idBooks";
                    var cmd = new MySqlCommand(sqlStr, mySqlConnection);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var author = (string)reader["AuthorName"];
                        var title = (string)reader["titleBook"];
                        var date = (DateTime)reader["publishDate"];
                        var isbn = (long)reader["ISBN"];
                        Console.WriteLine("{0}: {1} {2} {3}", author, title, date, isbn);
                    }
                }
            }
        }
    }
}