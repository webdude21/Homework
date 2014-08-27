namespace GetAllCategoriesAndTheirProducts
{
    using System;
    using System.Data.SqlClient;

    using GetAllCategoriesAndTheirProducts.Properties;

    internal class GetAllCategoriesAndTheirProductsProgram
    {
        private static void Main()
        {
            using (var sqlConnection = new SqlConnection(Settings.Default.DBNorthwindConectionString))
            {
                sqlConnection.Open();
                using (sqlConnection)
                {
                    var cmdAllCategoryesAndProducts =
                        new SqlCommand(
                            "SELECT c.CategoryName,p.ProductName FROM Categories c JOIN Products p ON"
                            + " c.CategoryID=p.CategoryID ORDER BY c.CategoryName", 
                            sqlConnection);
                    var reader = cmdAllCategoryesAndProducts.ExecuteReader();
                    var counter = 1;
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            var categorieName = (string)reader["CategoryName"];
                            var productName = (string)reader["ProductName"];
                            Console.WriteLine("{0}.{1} - {2}", counter, categorieName, productName);
                            counter++;
                        }
                    }
                }
            }
        }
    }
}