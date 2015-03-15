// Write a program to return the string with maximum length from an array of strings. Use LINQ.

namespace ArrayOfStrings
{
    using System;
    using System.Linq;

    internal class ArrayOfStrings
    {
        private static void Main()
        {
            string[] strArr = { "Pesho", "Alexander", "Ana", "Mimi" };

            var result = from str in strArr orderby str.Length descending select str;

            Console.WriteLine(result.First());
        }
    }
}