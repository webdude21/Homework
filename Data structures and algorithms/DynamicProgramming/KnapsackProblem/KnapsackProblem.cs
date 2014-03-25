using System;
using System.Collections.Generic;
using System.IO;

namespace KnapsackProblem
{
    class KnapsackProblem
    {
        private const int MaxWeight = 10;
        static void Main()
        {
            var itemList = ReadInput();
            foreach (var item in itemList)
            {
                Console.WriteLine(item);
            }
        }

        private static IEnumerable<Item> ReadInput()
        {
            if (File.Exists(@"..\..\input.txt"))
            {
                Console.SetIn(new StreamReader(@"..\..\input.txt"));
            }
            var itemList = new List<Item>();
            var inputLine = Console.ReadLine();
            while (inputLine != null)
            {
                itemList.Add(new Item(inputLine));
                inputLine = Console.ReadLine();
            }
            return itemList.ToArray();
        }
    }
}