namespace Crossword
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class Crossword
    {
        private static readonly StringBuilder StringBuilder = new StringBuilder();

        private static readonly SortedSet<string> VariationsFound = new SortedSet<string>();

        private static string[] wordsToChooseFrom;

        private static int wordsToPickCount;

        private static int wordToChooseFromCount;

        private static int[] currentVariationIndex;

        private static void Main()
        {
            ReadInput();
            GenerateVariationsWithRepetitions(0);
            Console.WriteLine(PrintResult() ?? "NO SOLUTION!");
        }

        private static string PrintResult()
        {
            StringBuilder.Clear();
            var firstVariation = VariationsFound.FirstOrDefault();

            if (firstVariation == null)
            {
                return null;
            }

            for (var i = 0; i < firstVariation.Length; i++)
            {
                StringBuilder.Append(firstVariation[i]);

                if (i % wordsToPickCount == wordsToPickCount - 1)
                {
                    StringBuilder.Append(Environment.NewLine);
                }
            }

            return StringBuilder.ToString().TrimEnd();
        }

        private static void ReadInput()
        {
            wordsToPickCount = int.Parse(Console.ReadLine());
            wordToChooseFromCount = wordsToPickCount * 2;
            wordsToChooseFrom = new string[wordToChooseFromCount];
            currentVariationIndex = new int[wordsToPickCount];

            for (var i = 0; i < wordToChooseFromCount; i++)
            {
                wordsToChooseFrom[i] = Console.ReadLine();
            }
        }

        private static void GenerateVariationsWithRepetitions(int index)
        {
            if (index >= wordsToPickCount)
            {
                AddVariationIfApplicable();
            }
            else
            {
                for (var i = 0; i < wordToChooseFromCount; i++)
                {
                    currentVariationIndex[index] = i;
                    GenerateVariationsWithRepetitions(index + 1);
                }
            }
        }

        private static void AddVariationIfApplicable()
        {
            if (CheckIfCombinationIsvalid())
            {
                StringBuilder.Clear();

                for (var i = 0; i < wordsToPickCount; i++)
                {
                    StringBuilder.Append(wordsToChooseFrom[currentVariationIndex[i]]);
                }

                VariationsFound.Add(StringBuilder.ToString());
            }
        }

        private static bool CheckIfCombinationIsvalid()
        {
            for (var i = 0; i < wordsToPickCount; i++)
            {
                StringBuilder.Clear();
                for (var j = 0; j < wordsToPickCount; j++)
                {
                    StringBuilder.Append(wordsToChooseFrom[currentVariationIndex[j]][i]);
                }

                var generatedWord = StringBuilder.ToString();

                if (!wordsToChooseFrom.Contains(generatedWord))
                {
                    return false;
                }
            }

            return true;
        }
    }
}