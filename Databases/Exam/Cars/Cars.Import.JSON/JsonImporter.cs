namespace Cars.Import.JSON
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Cars.Data;
    using Cars.Import.JSON.Helpers;
    using Cars.Import.JSON.Model;
    using Cars.Model;

    using Newtonsoft.Json;

    public class JsonImporter
    {
        private readonly CarsDbContext databaseContext;

        private readonly ILogger logger;

        public JsonImporter(CarsDbContext databaseContext, ILogger logger)
        {
            this.databaseContext = databaseContext;
            this.logger = logger;
        }

        public void ImportAll(string folderPath)
        {
            var fileEntries = Directory.GetFiles(folderPath);

            foreach (var fileEntry in fileEntries.Where(fileEntry => fileEntry.Contains("data") && fileEntry.Contains("json")))
            {
                this.Import(fileEntry);
                this.databaseContext.SaveChanges();
            }
        }

        public void Import(string jsonImportFilePath)
        {
            var jsonText = this.CheckIfFileExsists(jsonImportFilePath);
            var convertedColection = JsonConvert.DeserializeObject<List<JsonCar>>(jsonText);
            var saveFrequency = 100;
            var objectCount = 0;

            foreach (var car in convertedColection)
            {
                var carToAddToDatabes = new Car
                                            {
                                                Model = car.Model, 
                                                Year = car.Year, 
                                                Manufacturer = this.AddManufacturer(car), 
                                                Dealer = this.AddDealer(car),
                                                TransmisionType = (TransmisionType)car.TransmisionType, 
                                                Price = car.Price
                                            };

                this.databaseContext.Cars.Add(carToAddToDatabes);
                this.logger.Log(".");

                objectCount += 1;

                if (objectCount % saveFrequency == 0)
                {
                    this.databaseContext.SaveChanges();
                }
            }
        }

        private string CheckIfFileExsists(string jsonImportFilePath)
        {
            string jsonText;

            if (File.Exists(jsonImportFilePath))
            {
                var jsonReader = new StreamReader(jsonImportFilePath);
                jsonText = jsonReader.ReadToEnd();
                this.logger.LogLine(string.Format("Importing {0}", jsonImportFilePath));
            }
            else
            {
                throw new FileNotFoundException("{0} was not found!", jsonImportFilePath);
            }
            return jsonText;
        }

        private Dealer AddDealer(JsonCar car)
        {
            var cityToAdd = this.databaseContext.Cities.FirstOrDefault(city => city.Name.Equals(car.Dealer.City))
                            ?? new City { Name = car.Dealer.City };

            return new Dealer { Name = car.Dealer.Name, City = cityToAdd };
        }

        private Manufacturer AddManufacturer(JsonCar car)
        {
            return this.databaseContext.Manufacturers.FirstOrDefault(man => man.Name.Equals(car.ManufacturerName))
                   ?? new Manufacturer { Name = car.ManufacturerName };
        }
    }
}