namespace ExecuteStoredProcedure
{
    using System;
    using System.Data.Entity.Core.Objects;

    using NortwindModel;

    internal class StoredProcedureProgram
    {
        private static decimal FindSupplierIncomesForPeriodOfTime(string name, DateTime startDate, DateTime endDate)
        {
            using (var northwindEntities = new NorthwindEntities())
            {
                var outputParameter = new ObjectParameter("result", typeof(decimal));
                northwindEntities.FindSupplierIncome(name, startDate, endDate, outputParameter);
                return decimal.Parse(outputParameter.Value.ToString());
            }
        }

        private static void CreateProcedureIfNeeded()
        {
            const string CreateProcedure = @"USE [Northwind]
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID('[dbo].[FindSupplierIncome]'))
BEGIN
    exec('CREATE PROCEDURE [dbo].[FindSupplierIncome](@name varchar(100), @startDate Date, @endDate Date, @result money OUTPUT)
AS
BEGIN
SELECT @result = SUM(det.UnitPrice * det.Quantity) FROM [Order Details] det
JOIN Products prd
ON prd.ProductID = det.ProductID
JOIN Suppliers spl 
ON spl.SupplierID = prd.SupplierID
JOIN Orders ord
ON ord.OrderID = det.OrderID
WHERE spl.CompanyName = @name AND ord.OrderDate > @startDate AND ord.OrderDate < @endDate
END
')
END";
            using (var northwindEntities = new NorthwindEntities())
            {
                northwindEntities.Database.ExecuteSqlCommand(CreateProcedure);
            }
        }

        private static void Main()
        {
            CreateProcedureIfNeeded();
            var incomes = FindSupplierIncomesForPeriodOfTime(
                "Leka Trading", 
                new DateTime(1996, 02, 01), 
                new DateTime(1998, 03, 01));
            Console.WriteLine(incomes);
        }
    }
}