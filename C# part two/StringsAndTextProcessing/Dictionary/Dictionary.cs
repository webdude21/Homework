// A dictionary is stored as a sequence of text lines containing words and their explanations. 
// Write a program that enters a word and translates it by using the dictionary. Sample dictionary:
namespace Dictionary
{
    using System;

    internal class Dictionary
    {
        private static void Main()
        {
            string[] term = { ".NET", "CLR", "namespace" };
            string[] definition =
                {
                    "platform for applications from Microsoft", "managed execution environment for .NET", 
                    "hierarchical organization of classes"
                };
            var input = Console.ReadLine();

            for (var i = 0; i < term.Length; i++)
            {
                if (input.ToUpper() == term[i].ToUpper())
                {
                    Console.WriteLine("{0} - {1}", term[i], definition[i]);
                }
            }
        }
    }
}