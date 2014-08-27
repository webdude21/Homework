namespace ReadFromExcel
{
    using System;
    using System.Data;
    using System.Data.OleDb;

    internal class ReadFromExcel
    {
        private static void Main()
        {
            var dataTable = new DataTable("newtable");

            using (var connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../../task.xlsx;Extended Properties=Excel 12.0;"))
            {
                connection.Open();
                const string SelectSql = @"SELECT * FROM [Sheet1$]";
                using (var adapter = new OleDbDataAdapter(SelectSql, connection))
                {
                    adapter.FillSchema(dataTable, SchemaType.Source);
                    adapter.Fill(dataTable);
                }

                connection.Close();
            }

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row.ItemArray[0] + " - " + row.ItemArray[1]);
            }
        }
    }
}