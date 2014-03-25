using System;
using System.Linq;

namespace KnapsackProblem
{
    class Item
    {
        private static readonly string[] CostSplitString = { "cost=" };
        private static readonly string[] WeightSplitString = { "weight=", ", " };

        public string Name { get; private set; }
        public int Weight { get; private set; }
        public int Price { get; private set; }

        public Item(string stringInfo)
        {
            this.Name = GetNameFromString(stringInfo);
            this.Weight = GetWeightFromString(stringInfo);
            this.Price = GetpriceFromString(stringInfo);
        }

        private int GetpriceFromString(string stringInfo)
        {
            var stringSplit = stringInfo.Split(CostSplitString, StringSplitOptions.RemoveEmptyEntries);
            return int.Parse(stringSplit[1]);
        }

        private int GetWeightFromString(string stringInfo)
        {
            var stringSplit = stringInfo.Split(WeightSplitString, StringSplitOptions.RemoveEmptyEntries);
            return int.Parse(stringSplit[1]);
        }

        private static string GetNameFromString(string stringInfo)
        {
            return stringInfo.Split().FirstOrDefault();
        }

        public override string ToString()
        {
            return string.Format("{0} - weight={1}, cost={2}", this.Name, this.Weight, this.Price);
        }
    }
}