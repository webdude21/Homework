namespace SortStringsByLenght
{
    using System;
    using System.Collections.Generic;

    internal class SortStringsByLenght
    {
        private static void Main()
        {
            var stringList = GetUserInput();
            Array.Sort(stringList, (x, y) => x.Length.CompareTo(y.Length));
            PrintResult(stringList);
        }

        private static void PrintResult(IEnumerable<string> stringList)
        {
            Console.WriteLine("The sorted array looks like this:");
            foreach (var word in stringList)
            {
                Console.WriteLine(word);
            }
        }

        private static string[] GetUserInput()
        {
            Console.Write("How many strings will you input? ");
            var n = int.Parse(Console.ReadLine());
            var stringList = new string[n];

            for (var i = 0; i < n; i++)
            {
                Console.Write("Please input a string for element {0} of the array: ", i);
                stringList[i] = Console.ReadLine();
            }

            return stringList;
        }
    }
}