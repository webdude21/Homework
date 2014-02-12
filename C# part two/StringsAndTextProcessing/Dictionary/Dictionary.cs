// A dictionary is stored as a sequence of text lines containing words and their explanations. 
// Write a program that enters a word and translates it by using the dictionary. Sample dictionary:

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Dictionary
{
    static void Main()
    {
        string[] term = { ".NET", "CLR", "namespace" };
        string[] definition = { "platform for applications from Microsoft",
                                 "managed execution environment for .NET",
                                 "hierarchical organization of classes" };
        string input = Console.ReadLine();
 
        for (int i = 0; i < term.Length; i++)
        {
            if (input.ToUpper() == term[i].ToUpper())
            {
                Console.WriteLine("{0} - {1}", term[i], definition[i]);
            }
        }
    }
}