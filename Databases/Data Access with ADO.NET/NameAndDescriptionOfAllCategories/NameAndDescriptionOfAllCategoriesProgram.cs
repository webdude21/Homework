namespace NameAndDescriptionOfAllCategories
{
    using System;
    using System.Data.SqlClient;

    using NameAndDescriptionOfAllCategories.Properties;

    internal class NameAndDescriptionOfAllCategoriesProgram
    {
        private static void Main()
        {
            using (var sqlConnection = new SqlConnection(Settings.Default.DBNorthwindConectionString))
            {
                sqlConnection.Open();
                using (sqlConnection)
                {
                    var cmdGetAllNamesAndDescriptions = new SqlCommand(
                        "SELECT CategoryName,Description FROM Categories", 
                        sqlConnection);
                    var reader = cmdGetAllNamesAndDescriptions.ExecuteReader();
                    Console.WriteLine("The categories are:");
                    var counter = 1;
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            var categoryName = (string)reader["CategoryName"];
                            var categoryDescription = (string)reader["Description"];
                            Console.WriteLine("{0}.{1} - {2}", counter, categoryName, categoryDescription);
                            counter++;
                        }
                    }
                }
            }
        }
    }
}