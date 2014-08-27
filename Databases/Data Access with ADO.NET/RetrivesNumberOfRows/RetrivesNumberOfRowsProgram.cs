namespace RetrivesNumberOfRows
{
    using System;
    using System.Data.SqlClient;

    using RetrivesNumberOfRows.Properties;

    internal class RetrivesNumberOfRowsProgram
    {
        private static void Main()
        {
            using (var sqlConnection = new SqlConnection(Settings.Default.DBNorthwindConectionString))
            {
                sqlConnection.Open();
                using (sqlConnection)
                {
                    var cmdCountRows = new SqlCommand("SELECT COUNT(*) FROM Categories", sqlConnection);
                    var rowsCount = (int)cmdCountRows.ExecuteScalar();
                    Console.WriteLine("The number of rows in Categories table is " + rowsCount);
                }
            }
        }
    }
}