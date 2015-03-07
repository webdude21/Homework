namespace BracketsAgain
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    internal class Program
    {
        private static StringBuilder resultBuilder = new StringBuilder();
        private static List<string> currentMethodList = null;
        private static Dictionary<string, List<string>> methodListDictionary = new Dictionary<string, List<string>>();
        private const string StaticKeyword = "static";

        private static void Main()
        {
            if (File.Exists(@"..\..\input.txt"))
            {
                Console.SetIn(new StreamReader(@"..\..\input.txt"));
            }

            var linesOfInput = int.Parse(Console.ReadLine());

            for (var i = 0; i <= linesOfInput; i++)
            {
                ParseLine(Console.ReadLine());
            }

            foreach (var item in methodListDictionary)
            {
                if (item.Value.Count > 0)
                {
                    Console.WriteLine("{0} -> {1}", item.Key, string.Join(", ", item.Value));
                }
                else
                {
                    Console.WriteLine("{0} -> None", item.Key);
                }

            }
        }

        private static void ParseLine(string readLine)
        {
            if (readLine == null)
            {
                return;
            }

            if (readLine.Contains(StaticKeyword) && !readLine.Contains("class") && readLine.Contains(")") && readLine.Contains("("))
            {
                var splitString = readLine.Split('(')[0].Split(' ');
                var methodName = splitString[splitString.Length - 1];
                currentMethodList = AddMethod(methodName);
                return;
            }

            if (currentMethodList != null)
            {
                var indexOfDot = readLine.IndexOf('.');
                var leftOverString = readLine;

                foreach (var item in methodListDictionary)
                {
                    if (readLine.Contains(item.Key))
                    {
                        currentMethodList.Add(item.Key);
                    }
                }

                while (indexOfDot >= 0)
                {
                    leftOverString = leftOverString.Substring(indexOfDot + 1);
                    if (leftOverString.Contains("("))
                    {
                        currentMethodList.Add(leftOverString.Split('(')[0]);
                    }
                    indexOfDot = leftOverString.IndexOf('.');
                }
            }
        }

        private static List<string> AddMethod(string methodName)
        {
            if (!methodListDictionary.ContainsKey(methodName))
            {
                methodListDictionary.Add(methodName, new List<string>());
            }

            return methodListDictionary[methodName];
        }
    }
}