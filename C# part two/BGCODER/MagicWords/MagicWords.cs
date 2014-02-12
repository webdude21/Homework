using System;
using System.Collections.Generic;
using System.Text;

class MagicWords
{
    static void Main()
    {
        int wordCount = int.Parse(Console.ReadLine());
        List<string> words = new List<string>();
        int longestWord = 0;

        for (int i = 0; i < wordCount; i++)
        {
            string currWord = Console.ReadLine();
            if (currWord.Length > longestWord)
            {
                longestWord = currWord.Length;
            }
            words.Add(currWord);
        }

        for (int i = 0; i < wordCount; i++)
        {
            string temp = words[i];
            int newPosition = temp.Length % (wordCount + 1);
            words[i] = null;
            words.Insert(newPosition, temp);
            words.Remove(null);
        }

        StringBuilder result = new StringBuilder();
        for (int chr = 0; chr < longestWord; chr++)
        {
            for (int i = 0; i < words.Count; i++)
            {
                string temp = words[i];
                if (temp.Length > chr)
                {
                    result.Append(temp[chr]);
                }
            }
        }
        Console.WriteLine(result);
    }
}