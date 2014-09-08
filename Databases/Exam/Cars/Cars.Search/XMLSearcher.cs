namespace Cars.Search
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    using Cars.Data;
    using Cars.Import.JSON.Helpers;
    using Cars.Model;

    public class XmlSearcher
    {
        private readonly CarsDbContext databaseContext;

        private readonly ILogger logger;

        public XmlSearcher(CarsDbContext databaseContext, ILogger logger)
        {
            this.databaseContext = databaseContext;
            this.logger = logger;
        }

        public void Search(string filePath, string outputPath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("There's no such file");
            }

            var searchDocument = XDocument.Load(filePath);

            var queries = searchDocument.Descendants("Query");

            foreach (var query in queries)
            {
                this.ParseQuery(query, outputPath);
            }

        }

        public void ParseQuery(XElement queryElement, string outputPath)
        {
            var filename = queryElement.Attribute("OutputFileName");
            var fileSavePath = outputPath + filename;
            var orderBy = queryElement.Attribute("OrderBy");
            var whereCluses = queryElement.Descendants("WhereClauses");
            var whereQueries = new List<IQueryable<Car>>();

            foreach (var whereClause in whereCluses)
            {
                whereQueries.Add(this.ParseWhereClause(whereClause, this.databaseContext.Cars.AsQueryable()));
            }

            if (orderBy != null)
            {
                this.GetQueryProperty(orderBy.Value, this.databaseContext.Cars.AsQueryable());
            }
        }

        private IQueryable<Car> ParseWhereClause(XElement whereClause, IQueryable<Car> carQuery)
        {
            var propertyName = whereClause.Attribute("PropertyName").Value;
            var compareType = whereClause.Attribute("Type").Value;

            switch (propertyName)
            {
                case "Id":
                    return this.WhereById(carQuery, compareType, whereClause.Value);
                case "Year":
                    return this.WhereByYear(carQuery, compareType, whereClause.Value);
                case "Price":
                    return this.WhereByPrice(carQuery, compareType, whereClause.Value);
                case "Model":
                    return this.WhereByModel(carQuery, compareType, whereClause.Value);
                default:
                    return this.WhereById(carQuery, compareType, whereClause.Value);
            }
        }

        private IQueryable<Car> WhereByModel(IQueryable<Car> carQuery, string compareType, string value)
        {
            switch (compareType)
            {
                case "Equals":
                    return carQuery.Where(car => car.Model.Equals(value));
                case "Contains":
                    return carQuery.Where(car => car.Model.Contains(value));
                default:
                    return carQuery.Where(car => car.Model.Equals(value)); 
            }
        }

        private IQueryable<Car> WhereByPrice(IQueryable<Car> carQuery, string compareType, string value)
        {
            switch (compareType)
            {
                case "Equals":
                    return carQuery.Where(car => car.Price.Equals(decimal.Parse(value)));
                case "GreaterThan":
                    return carQuery.Where(car => car.Price > decimal.Parse(value));
                case "LessThan":
                    return carQuery.Where(car => car.Price < decimal.Parse(value));
                default:
                    return carQuery.Where(car => car.Price.Equals(decimal.Parse(value)));
            }
        }

        private IQueryable<Car> WhereByYear(IQueryable<Car> carQuery, string compareType, string value)
        {
            switch (compareType)
            {
                case "Equals":
                    return carQuery.Where(car => car.Year.Equals(int.Parse(value)));
                case "GreaterThan":
                    return carQuery.Where(car => car.Year > int.Parse(value));
                case "LessThan":
                    return carQuery.Where(car => car.Year < int.Parse(value));
                default:
                    return carQuery.Where(car => car.Year.Equals(int.Parse(value)));
            }
        }

        private IQueryable<Car> WhereById(IQueryable<Car> carQuery, string compareType, string value)
        {
            switch (compareType)
            {
                case "Equals":
                    return carQuery.Where(car => car.Id.Equals(int.Parse(value)));
                case "GreaterThan":
                    return carQuery.Where(car => car.Id > int.Parse(value));
                case "LessThan":
                    return carQuery.Where(car => car.Id < int.Parse(value));
                default:
                    return carQuery.Where(car => car.Id.Equals(int.Parse(value)));
            }
        }

        private IOrderedQueryable<Car> GetQueryProperty(string value, IQueryable<Car> carQuery)
        {
            switch (value)
            {
                case "Id":
                    return carQuery.OrderBy(car => car.Id);
                case "Year":
                    return carQuery.OrderBy(car => car.Year);
                case "Model":
                    return carQuery.OrderBy(car => car.Model);
                case "Price":
                    return carQuery.OrderBy(car => car.Price);
                case "Manufacturer":
                    return carQuery.OrderBy(car => car.Manufacturer.Name);
                case "Dealer":
                    return carQuery.OrderBy(car => car.Dealer.Name);
                default:
                    return carQuery.OrderBy(car => car.Id);
            }
        }
    }
}