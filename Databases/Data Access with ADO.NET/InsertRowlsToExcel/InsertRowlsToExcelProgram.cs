namespace InsertRowlsToExcel
{
    using System.Data;
    using System.Data.OleDb;

    internal class InsertRowlsToExcelProgram
    {
        private static void Main()
        {
            using (var connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../../task.xlsx;Extended Properties=Excel 12.0;"))
            {
                const string InsertToTable = @"INSERT INTO [Sheet1$] (Name, Score) VALUES (@Name, @Score)";
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.CommandText = InsertToTable;
                    command.Parameters.AddWithValue("@Name", "Gosho");
                    command.Parameters.AddWithValue("@Score", 19);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}