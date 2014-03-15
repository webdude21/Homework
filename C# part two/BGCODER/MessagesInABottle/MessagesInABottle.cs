using System;
using System.Collections.Generic;
using System.Text;

class MessagesInABottle
{
    static string secretMessage;
    static string cipher;
    static Dictionary<string, char> cipherBook = new Dictionary<string, char>();
    static SortedSet<string> result = new SortedSet<string>();
    static StringBuilder sb = new StringBuilder();

    static void Main()
    {
        GetInput();
        GenerateMessage(0);
        
        Console.WriteLine(result.Count);
        foreach (string message in result)
        {
            Console.WriteLine(message);
        }
    }

    static void GenerateMessage(int index)
    {
        if (index == secretMessage.Length)
        {
            result.Add(sb.ToString());
            return;
        }

        for (int i = 0; i + index <= secretMessage.Length; i++)
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
        int index = 0;

        while (index < cipher.Length)
        {
            if (char.IsLetter(cipher[index]))
            {
                char value = cipher[index];
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
