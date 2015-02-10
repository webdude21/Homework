// Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.
namespace AlphabeticalOrder
{
    using System;

    internal class AlphabeticalOrder
    {
        private static void Main()
        {
            Console.Write("Please input words delimited by spaces: ");
            var input = Console.ReadLine();
            var words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(words);
            Console.WriteLine("This is the result:");
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}