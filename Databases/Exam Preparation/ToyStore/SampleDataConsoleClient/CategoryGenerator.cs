namespace ToyStore.SampleData
{
    using System.Collections.Generic;

    using RandomDataGenerator;
    using RandomDataGenerator.Contracts;

    using ToyStore.Data;

    internal class CategoryGenerator : DataGenerator<Category>
    {
        public CategoryGenerator(int count, IRandomDataGenerator random, ToyStoreEntities databaseContext, ILogger logger, int saveFrequoncy = 1000)
            : base(count, random, databaseContext, logger, saveFrequoncy)
        {
            this.DatabaseContext = databaseContext;
        }

        protected new ToyStoreEntities DatabaseContext { get; set; }

        public override HashSet<Category> Generate()
        {
            this.Logger.LogLine("Generating Categories");
            return base.Generate();
        }

        protected override Category GenerateEntity()
        {
           return this.DatabaseContext.Categories.Add(new Category { Name = this.Random.GetString(4, 12) });
        }
    }
}