// Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. 

using System;
using System.Text;


class PrintUnicodeLiterals
    {
        static void Main()
        {
            string input = "ABVGZ";
            Console.WriteLine(GetUnicodeLiterals(input));
        }

        static string GetUnicodeLiterals(string input)
        {
            StringBuilder result = new StringBuilder();
            foreach (char chr in input)
            {
                result.Append("\\u");
                result.Append(String.Format("{0:x4}", (int)chr));
            }
            return result.ToString();
        }
    }
