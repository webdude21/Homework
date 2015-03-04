namespace RelevanceIndex
{
    using System;
    using System.Collections.Generic;

    internal class RelevanceIndex
    {
        private static void Main()
        {
            var searchWord = Console.ReadLine();
            var punctuation = new[] { ",", ".", "(", ")", ";", "-", "!", "?", " "};
            var linesOfInput = int.Parse(Console.ReadLine());
            var relevenceIndexList = new SortedSet<Paragraph>();

            for (var i = 0; i < linesOfInput; i++)
            {
                ReadRelevenceIndex(searchWord, punctuation, relevenceIndexList);
            }

            foreach (var paragraph in relevenceIndexList)
            {
                Console.WriteLine(paragraph);
            }
        }

        private static void ReadRelevenceIndex(string searchWord, string[] punctuation, ICollection<Paragraph> relevenceIndexList)
        {
            var input = Console.ReadLine().Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
            var relevenceIndex = 0;

            for (var currentWord = 0; currentWord < input.Length; currentWord++)
            {
                if (input[currentWord].ToUpperInvariant() == searchWord.ToUpperInvariant())
                {
                    input[currentWord] = input[currentWord].ToUpperInvariant();
                    relevenceIndex++;
                }
            }
            relevenceIndexList.Add(new Paragraph(relevenceIndex, input));
        }

        public class Paragraph : IComparable<Paragraph>
        {
            public int RelevenceIndex { get; set; }

            public string[] WordsList { get; set; }

            public Paragraph(int relevenceIndex, string[] wordsList)
            {
                this.RelevenceIndex = relevenceIndex;
                this.WordsList = wordsList;
            }

            public int CompareTo(Paragraph other)
            {
                return -this.RelevenceIndex.CompareTo(other.RelevenceIndex);
            }

            public override string ToString()
            {
                return string.Join(" ", this.WordsList);
            }
        }
    }
}