namespace MessagesInABottle
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class MessagesInABottle
    {
        private static string secretMessage;

        private static string cipher;

        private static Dictionary<string, char> cipherBook = new Dictionary<string, char>();

        private static SortedSet<string> result = new SortedSet<string>();

        private static StringBuilder sb = new StringBuilder();

        private static void Main()
        {
            GetInput();
            GenerateMessage(0);

            Console.WriteLine(result.Count);
            foreach (var message in result)
            {
                Console.WriteLine(message);
            }
        }

        private static void GenerateMessage(int index)
        {
            if (index == secretMessage.Length)
            {
                result.Add(sb.ToString());
                return;
            }

            for (var i = 0; i + index <= secretMessage.Length; i++)
            {
                if (cipherBook.ContainsKey(secretMessage.Substring(index, i)))
                {
                    sb.Append(cipherBook[secretMessage.Substring(index, i)]);
                    GenerateMessage(index + i);
                    sb.Remove(sb.Length - 1, 1);
                }
            }
        }

        private static void GetInput()
        {
            secretMessage = Console.ReadLine();
            cipher = Console.ReadLine();
            var index = 0;

            while (index < cipher.Length)
            {
                if (char.IsLetter(cipher[index]))
                {
                    var value = cipher[index];
                    index++;
                    while (index < cipher.Length && char.IsDigit(cipher[index]))
                    {
                        sb.Append(cipher[index]);
                        index++;
                    }

                    if (!cipherBook.ContainsValue(value))
                    {
                        cipherBook.Add(sb.ToString(), value);
                    }

                    sb.Clear();
                }
            }
        }
    }
}