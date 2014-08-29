namespace MagicWords
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class MagicWords
    {
        private static void Main()
        {
            var wordCount = int.Parse(Console.ReadLine());
            var words = new List<string>();
            var longestWord = 0;

            for (var i = 0; i < wordCount; i++)
            {
                var currWord = Console.ReadLine();
                if (currWord.Length > longestWord)
                {
                    longestWord = currWord.Length;
                }

                words.Add(currWord);
            }

            for (var i = 0; i < wordCount; i++)
            {
                var temp = words[i];
                var newPosition = temp.Length % (wordCount + 1);
                words[i] = null;
                words.Insert(newPosition, temp);
                words.Remove(null);
            }

            var result = new StringBuilder();
            for (var chr = 0; chr < longestWord; chr++)
            {
                for (var i = 0; i < words.Count; i++)
                {
                    var temp = words[i];
                    if (temp.Length > chr)
                    {
                        result.Append(temp[chr]);
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}