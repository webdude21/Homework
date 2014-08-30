namespace GetImages
{
    using System.Data.SqlClient;
    using System.IO;

    internal class GetImagesProgram
    {
        private const string FileLocation = @"..\";

        private const string FileExtension = @".jpg";

        private static void Main()
        {
            ExtractImageFromDb();
        }

        private static void ExtractImageFromDb()
        {
            using (var sqlConnection = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true"))
            {
                sqlConnection.Open();

                using (sqlConnection)
                {
                    var cmd = new SqlCommand("SELECT PICTURE, CategoryID, CategoryName FROM Categories", sqlConnection);

                    var reader = cmd.ExecuteReader();

                    using (reader)
                    {
                        while (reader.Read())
                        {
                            var image = (byte[])reader["Picture"];
                            var categoryId = (int)reader["CategoryID"];
                            WriteBinaryFile(image, FileLocation + categoryId + FileExtension);
                        }
                    }
                }
            }
        }

        private static void WriteBinaryFile(byte[] fileContents, string fileLocation)
        {
            var stream = new FileStream(fileLocation, FileMode.Create);
            using (stream)
            {
                stream.Write(fileContents, 0, fileContents.Length);
            }
        }
    }
}