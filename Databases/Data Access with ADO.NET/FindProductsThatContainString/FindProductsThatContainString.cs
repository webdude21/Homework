namespace FindProductsThatContainString
{
    using System;
    using System.Data.SqlClient;
    using System.Text.RegularExpressions;

    using global::FindProductsThatContainString.Properties;

    internal class FindProductsThatContainString
    {
        private static void Main(string[] args)
        {
            var containingStr = Console.ReadLine();
            var dbCon = new SqlConnection(Settings.Default.DBNorthwindConectionString);
            containingStr = Regex.Replace(containingStr, "([#_%'\"\\\\])", "#$1");
            dbCon.Open();
            using (dbCon)
            {
                var cmdGetProducts =
                    new SqlCommand(
                        "SELECT ProductName AS Names FROM Products WHERE ProductName LIKE '%" + containingStr
                        + "%' ESCAPE '#'", 
                        dbCon);
                var reader = cmdGetProducts.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        var name = (string)reader["Names"];
                        Console.WriteLine(name);
                    }
                }
            }
        }
    }
}