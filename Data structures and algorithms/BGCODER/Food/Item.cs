namespace Food
{
    using System.Linq;

    internal class Item
    {
        public Item(string stringInfo)
        {
            this.Name = GetNameFromString(stringInfo);
            this.Weight = this.GetWeightFromString(stringInfo);
            this.Price = this.GetpriceFromString(stringInfo);
        }

        public string Name { get; private set; }

        public int Weight { get; private set; }

        public int Price { get; private set; }

        private int GetpriceFromString(string stringInfo)
        {
            var stringSplit = stringInfo.Split();
            return int.Parse(stringSplit[2]);
        }

        private int GetWeightFromString(string stringInfo)
        {
            var stringSplit = stringInfo.Split();
            return int.Parse(stringSplit[1]);
        }

        private static string GetNameFromString(string stringInfo)
        {
            return stringInfo.Split().FirstOrDefault();
        }

        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }
    }
}