namespace Garden
{
    using System;
    using System.Collections.Generic;

    internal class Garden
    {
        private static void Main()
        {
            var vegitables = ReadInput();
            PrintResult(vegitables);
        }

        private static void PrintResult(IReadOnlyList<Vegitable> vegitables)
        {
            var totalArea = 250m;
            var totalCost = 0m;

            for (var i = 0; i < 5; i++)
            {
                totalArea -= vegitables[i].Area;
                totalCost += vegitables[i].TotalPrice;
            }


            totalCost += vegitables[5].TotalPrice;
            Console.WriteLine("Total costs: {0:F2}", totalCost);

            if (totalArea == 0m)
            {
                Console.WriteLine("No area for beans");
            }
            else if (totalArea < 0m)
            {
                Console.WriteLine("Insufficient area");
            }
            else
            {
                Console.WriteLine("Beans area: {0}", totalArea);
            }
        }

        private static List<Vegitable> ReadInput()
        {
            var vegies = new List<Vegitable>
                             {
                                 new Vegitable(0.5m), 
                                 new Vegitable(0.4m), 
                                 new Vegitable(0.25m), 
                                 new Vegitable(0.6m), 
                                 new Vegitable(0.3m), 
                                 new Vegitable(0.4m)
                             };

            for (var i = 0; i < 5; i++)
            {
                vegies[i].SeedAmount = int.Parse(Console.ReadLine());
                vegies[i].Area = decimal.Parse(Console.ReadLine());
            }

            vegies[5].SeedAmount = int.Parse(Console.ReadLine());

            return vegies;
        }
    }

    public class Vegitable
    {
        public Vegitable(decimal pricePerSeed, int seedAmount = 0, decimal area = 0m)
        {
            this.PricePerSeed = pricePerSeed;
            this.SeedAmount = seedAmount;
            this.Area = area;
        }

        public decimal PricePerSeed { get; set; }

        public int SeedAmount { get; set; }

        public decimal Area { get; set; }

        public decimal TotalPrice
        {
            get
            {
                return this.PricePerSeed * this.SeedAmount;
            }
        }
    }
}