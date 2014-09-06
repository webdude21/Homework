namespace ToyStore.GenerateSampleData
{
    using System;
    using System.Collections.Generic;

    using ToyStore.Data;

    internal class GenerateSampleData
    {
        private static readonly ToyStoreEntities ToyStoreDbContext = new ToyStoreEntities();

        private static readonly RandomDataGenerator Random = new RandomDataGenerator();

        private static List<Manufacturer> randomManufacturers;

        private static List<Category> randomCategories;

        private static List<AgeRanx> randomAges;

        private static void Main()
        {
            Console.WriteLine("Generating Manufacturers ...");
            randomManufacturers = GenerateRandomManufacturers(100);
            Console.WriteLine("Generating Categories ...");
            randomCategories = GenerateRandomCategories(200);
            Console.WriteLine("Generating AgeRanges ...");
            randomAges = GenerateRandomAgeRanges(200);
            Console.WriteLine("Generating Toys ...");
            GenerateRandomToys(20000, ToyStoreDbContext);
            ToyStoreDbContext.SaveChanges();
            Console.WriteLine("Finished");
        }

        private static void ToyGenerationCheckPoint(int count)
        {
            Console.WriteLine("Generated {0} toys so far", count);
            Console.WriteLine("SavingChanges...");
            ToyStoreDbContext.SaveChanges();
            Console.WriteLine("============================");
        }

        private static Manufacturer GetRandomManufacturer()
        {
            return randomManufacturers[Random.GetInt(0, randomManufacturers.Count - 1)];
        }

        private static Category GetRandomCategory()
        {
            return randomCategories[Random.GetInt(0, randomCategories.Count - 1)];
        }

        private static AgeRanx GetRandomAgeRange()
        {
            return randomAges[Random.GetInt(0, randomAges.Count - 1)];
        }

        private static void GenerateRandomToys(int count, ToyStoreEntities toyStoreDbContext)
        {
            for (var i = 0; i < count; i++)
            {
                if (i % 1000 == 0)
                {
                    ToyGenerationCheckPoint(i);
                }

                toyStoreDbContext.Toys.Add(GetRandomToy());
            }
        }

        private static Toy GetRandomToy()
        {
            return new Toy
            {
                AgeRanx = GetRandomAgeRange(),
                Category = GetRandomCategory(),
                Color = Random.GetString(3, 30),
                Name = Random.GetString(2, 45),
                Price = (decimal)Random.GetDouble() * Random.GetInt(1, 400),
                Type = Random.GetString(2, 45),
                Manufacturer = GetRandomManufacturer()
            };
        }

        private static List<AgeRanx> GenerateRandomAgeRanges(int count)
        {
            var generatedStuff = new List<AgeRanx>();
            for (var i = 0; i < count; i++)
            {
                var upperBound = Random.GetInt(1, 12);
                var lowerBound = Random.GetInt(0, upperBound);

                generatedStuff.Add(ToyStoreDbContext.AgeRanges.Add(new AgeRanx { MinAge = (byte)lowerBound, MaxAge = (byte)upperBound }));
            }

            return generatedStuff;
        }

        private static List<Manufacturer> GenerateRandomManufacturers(int count)
        {
            var generatedStuff = new List<Manufacturer>();
            for (var i = 0; i < count; i++)
            {
                generatedStuff.Add(
                    ToyStoreDbContext.Manufacturers.Add(
                        new Manufacturer { Country = Random.GetString(3, 45), Name = Random.GetString(3, 45) }));
            }

            return generatedStuff;
        }

        private static List<Category> GenerateRandomCategories(int count)
        {
            var generatedStuff = new List<Category>();

            for (var i = 0; i < count; i++)
            {
                generatedStuff.Add(ToyStoreDbContext.Categories.Add(new Category { Name = Random.GetString(3, 45) }));
            }

            return generatedStuff;
        }
    }
}