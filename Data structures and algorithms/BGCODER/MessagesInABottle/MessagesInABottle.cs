namespace MessagesInABottle
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class MessagesInABottle
    {
        private static readonly Dictionary<string, char> CipherBook = new Dictionary<string, char>();

        private static readonly SortedSet<string> ResultSet = new SortedSet<string>();

        private static readonly StringBuilder StringBuilder = new StringBuilder();

        private static string secretMessage;

        private static void Main()
        {
            ReadInput();
            Solve(0);
            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine(ResultSet.Count);
            Console.WriteLine(string.Join(Environment.NewLine, ResultSet));
        }

        private static void Solve(int index)
        {
            if (index == secretMessage.Length)
            {
                ResultSet.Add(StringBuilder.ToString());
                return;
            }

            for (var length = 0; index + length <= secretMessage.Length; length++)
            {
                if (CipherBook.ContainsKey(secretMessage.Substring(index, length)))
                {
                    StringBuilder.Append(CipherBook[secretMessage.Substring(index, length)]);
                    Solve(index + length);
                    StringBuilder.Remove(StringBuilder.Length - 1, 1);
                }
            }
        }

        private static void ReadInput()
        {
            secretMessage = Console.ReadLine();
            var cipher = Console.ReadLine();
            var lastCharacter = cipher[0];

            foreach (var symbol in cipher)
            {
                if (char.IsLetter(symbol))
                {
                    if (StringBuilder.Length > 0)
                    {
                        CipherBook.Add(StringBuilder.ToString(), lastCharacter);
                        StringBuilder.Clear();
                        lastCharacter = symbol;
                    }
                }
                else
                {
                    StringBuilder.Append(symbol);
                }
            }

            CipherBook.Add(StringBuilder.ToString(), lastCharacter);
            StringBuilder.Clear();
        }
    }
}