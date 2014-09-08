namespace ToyStore.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using RandomDataGenerator;
    using RandomDataGenerator.Contracts;

    public class ToyGenerator : DataGenerator
    {
        private readonly ToyStoreEntities databaseContext;

        private IReadOnlyList<int> ageRangesIds;

        private IReadOnlyList<int> categoryIds;

        private IReadOnlyList<int> manufacturers;

        public ToyGenerator( int count, IRandomDataGenerator random,  ILogger logger, ToyStoreEntities databaseContext, int checkPointFrequency = 1000)
            : base(count, random, logger, checkPointFrequency)
        {
            this.databaseContext = databaseContext;
        }

        public override void Generate()
        {
            this.RetrieveDependencies();
            base.Generate();
        }

        protected override void GenerateEntity()
        {
            var toy = new Toy
                          {
                              Name = this.Random.GetString(5, 45), 
                              Type = this.Random.GetString(5, 45), 
                              Price = (decimal)(this.Random.GetDouble() * 100), 
                              Color = this.Random.GetChance(50) ? this.Random.GetString(5, 30) : null, 
                              ManufacturerId = this.manufacturers[this.Random.GetInt(0, this.manufacturers.Count - 1)], 
                              AgeRangesId = this.ageRangesIds[this.Random.GetInt(0, this.ageRangesIds.Count - 1)], 
                          };

            if (this.categoryIds.Count > 0)
            {
                var uniqueCategoriesId = new HashSet<int>();
                var categoriesInToy = this.Random.GetInt(1, Math.Min(10, this.categoryIds.Count - 1));

                while (uniqueCategoriesId.Count != categoriesInToy)
                {
                    uniqueCategoriesId.Add(this.categoryIds[this.Random.GetInt(0, this.categoryIds.Count - 1)]);
                }

                foreach (var categoryId in uniqueCategoriesId)
                {
                    toy.Categories.Add(this.databaseContext.Categories.Find(categoryId));
                }
            }

            this.databaseContext.Toys.Add(toy);
        }


        protected override void CheckPoint()
        {
            this.databaseContext.SaveChanges();
            base.CheckPoint();
        }

        private void RetrieveDependencies()
        {
            this.ageRangesIds = this.databaseContext.AgeRanges.Select(age => age.Id).ToArray();
            this.categoryIds = this.databaseContext.Categories.Select(cat => cat.Id).ToArray();
            this.manufacturers = this.databaseContext.Manufacturers.Select(man => man.Id).ToArray();
        }
    }
}