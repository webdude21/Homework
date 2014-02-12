// Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.

using System;

class AlphabeticalOrder
{
    static void Main()
    {
        Console.Write("Please input words delimited by spaces: ");
        string input = Console.ReadLine();
        string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Array.Sort(words);
        Console.WriteLine("This is the result:" );
        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
    }
}