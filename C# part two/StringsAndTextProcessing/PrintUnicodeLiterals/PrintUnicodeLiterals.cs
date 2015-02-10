// Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. 
namespace PrintUnicodeLiterals
{
    using System;
    using System.Text;

    internal class PrintUnicodeLiterals
    {
        private static void Main()
        {
            var input = "ABVGZ";
            Console.WriteLine(GetUnicodeLiterals(input));
        }

        private static string GetUnicodeLiterals(string input)
        {
            var result = new StringBuilder();
            foreach (var chr in input)
            {
                result.Append("\\u");
                result.Append(string.Format("{0:x4}", (int)chr));
            }

            return result.ToString();
        }
    }
}