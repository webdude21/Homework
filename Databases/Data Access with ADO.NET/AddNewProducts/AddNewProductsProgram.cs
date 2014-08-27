namespace AddNewProducts
{
    using System.Data.SqlClient;

    using AddNewProducts.Properties;

    internal class AddNewProductsProgram
    {
        private static void InsertProduct(
            SqlConnection sqlConnection, 
            string productName, 
            int supplierId, 
            int categoryId, 
            string quantityPerUnit, 
            decimal unitPrice, 
            int unitsInStock, 
            int unitsOnOrder, 
            int reorderLevel, 
            bool discontinued)
        {
            using (sqlConnection)
            {
                var cmdInsertProduct =
                    new SqlCommand(
                        "INSERT INTO Products(ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,"
                        + "UnitsOnOrder,ReorderLevel,Discontinued)"
                        + " VALUES(@ProductName,@SupplierID,@CategoryID,@QuantityPerUnit,"
                        + "@UnitPrice,@UnitsInStock,@UnitsOnOrder,@ReorderLevel,@Discontinued)", 
                        sqlConnection);

                cmdInsertProduct.Parameters.AddWithValue("@ProductName", productName);
                cmdInsertProduct.Parameters.AddWithValue("@SupplierID", supplierId);
                cmdInsertProduct.Parameters.AddWithValue("@CategoryID", categoryId);
                cmdInsertProduct.Parameters.AddWithValue("@QuantityPerUnit", quantityPerUnit);
                cmdInsertProduct.Parameters.AddWithValue("@UnitPrice", unitPrice);
                cmdInsertProduct.Parameters.AddWithValue("@UnitsInStock", unitsInStock);
                cmdInsertProduct.Parameters.AddWithValue("@UnitsOnOrder", unitsOnOrder);
                cmdInsertProduct.Parameters.AddWithValue("@ReorderLevel", reorderLevel);
                cmdInsertProduct.Parameters.AddWithValue("@Discontinued", discontinued);

                cmdInsertProduct.ExecuteNonQuery();
            }
        }

        private static void Main()
        {
            using (var sqlConnection = new SqlConnection(Settings.Default.DBNorthwindConectionString))
            {
                sqlConnection.Open();
                using (sqlConnection)
                {
                    InsertProduct(sqlConnection, "TestProduct2", 1, 1, "1", 50M, 1, 1, 1, true);
                }
            }
        }
    }
}