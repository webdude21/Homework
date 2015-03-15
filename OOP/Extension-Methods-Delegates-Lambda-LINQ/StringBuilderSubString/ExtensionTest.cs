namespace StringBuilderSubString
{
    using System;
    using System.Text;

    internal class ExtensionTest
    {
        private static void Main()
        {
            // Test the extension method
            var testSb = new StringBuilder();
            testSb.Append("Pesho and Gosho are the best of friends!");
            Console.WriteLine(testSb.SubString(10, 5)); // Gosho
            Console.WriteLine(testSb.SubString(0, 5)); // Pesho
        }
    }
}