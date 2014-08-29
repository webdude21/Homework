namespace ConsoleJustification
{
    using System;
    using System.Text;

    internal class ConsoleJustification
    {
        private static StringBuilder output = new StringBuilder();

        private static string input;

        private static string[] wordList;

        private static int usedLenght;

        private static int wordsOnThisLine;

        private static int firstWord;

        private static void Main()
        {
            var nLines = int.Parse(Console.ReadLine());
            var wordsPerLine = int.Parse(Console.ReadLine());
            input = ReadEntireInput(nLines);
            wordList = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (var currWord = 0; currWord < wordList.Length; currWord++)
            {
                if ((usedLenght + wordList[currWord].Length + wordsOnThisLine) <= wordsPerLine)
                {
                    usedLenght = usedLenght + wordList[currWord].Length;
                    wordsOnThisLine++;

                    if (currWord == wordList.Length - 1)
                    {
                        currWord++;
                        ArrangeLine(wordsPerLine, ref currWord);
                    }
                }
                else
                {
                    ArrangeLine(wordsPerLine, ref currWord);
                    firstWord = currWord + 1;
                    output.Append(Environment.NewLine);
                    usedLenght = 0;
                    wordsOnThisLine = 0;
                }
            }

            Console.WriteLine(output);
        }

        private static void ArrangeLine(int wordsPerLine, ref int lastWordOnLine)
        {
            lastWordOnLine--;
            var leftOverLenght = wordsPerLine - usedLenght;
            var whiteSpacesBetweenWords = 0;
            var whiteSpaceRemainder = 0;
            var wordsThatNeedSpace = wordsOnThisLine - 1;

            if (wordsThatNeedSpace > 0)
            {
                whiteSpacesBetweenWords = leftOverLenght / wordsThatNeedSpace;
                whiteSpaceRemainder = leftOverLenght - (whiteSpacesBetweenWords * wordsThatNeedSpace);
            }

            for (var word = firstWord; word <= lastWordOnLine; word++)
            {
                if (word < lastWordOnLine)
                {
                    // If it's not the last word, append a space after the word.
                    output.Append(wordList[word]);
                    if (whiteSpaceRemainder > 0)
                    {
                        output.Append(' ', whiteSpacesBetweenWords + 1);
                        whiteSpaceRemainder--;
                    }
                    else
                    {
                        output.Append(' ', whiteSpacesBetweenWords);
                    }
                }
                else
                {
                    output.Append(wordList[word]);
                }
            }
        }

        private static string ReadEntireInput(int nLines)
        {
            var input = new StringBuilder();
            for (var i = 0; i < nLines; i++)
            {
                input.Append(Console.ReadLine());
                input.Append(" ");
            }

            return input.ToString();
        }
    }
}