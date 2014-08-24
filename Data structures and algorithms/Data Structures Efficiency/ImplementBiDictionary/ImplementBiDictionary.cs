namespace ImplementBiDictionary
{
    using System;

    internal class ImplementBiDictionary
    {
        private static void Main()
        {
            var dict = new BiDictionary<string, int, string>(true);

            dict.Add("pesho", 1, "JavaScript");
            dict.Add("gosho", 2, "Java");
            dict.Add("nakov", 3, "C#");
            dict.Add("nakov", 3, "C#");
            dict.Add("gosho", 3, "Coffee");
            dict.Add("nakov", 1, "Python");

            Console.WriteLine(string.Join(" ", dict.GetValueByFirstKey("nakov")));
            Console.WriteLine(string.Join(" ", dict.GetValueBySecondKey(3)));
            Console.WriteLine(string.Join(" ", dict.GetValueByBothKeys("nakov", 3)));
        }
    }
}