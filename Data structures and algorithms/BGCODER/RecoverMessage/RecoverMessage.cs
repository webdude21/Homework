namespace RecoverMessage
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    internal class RecoverMessage
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var uniqueChars = ReadInput();
            Array.Sort(uniqueChars);
            Console.WriteLine(uniqueChars);
        }

        private static char[] ReadInput()
        {
            var inputLinesCount = int.Parse(Console.ReadLine());
            var possibleChars = new HashSet<char>();

            for (var i = 0; i < inputLinesCount; i++)
            {
                var input = Console.ReadLine().ToCharArray();
                foreach (var chr in input)
                {
                    possibleChars.Add(chr);
                }
            }

            return possibleChars.ToArray();
        }
    }
}