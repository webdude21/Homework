using System;
using System.Text;

class ConsoleJustification
{
    static StringBuilder output = new StringBuilder();
    static string input;
    static string[] wordList;
    static int usedLenght;
    static int wordsOnThisLine;
    static int firstWord;

    static void Main()
    {
        int nLines = int.Parse(Console.ReadLine());
        int wordsPerLine = int.Parse(Console.ReadLine());
        input = ReadEntireInput(nLines);
        wordList = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

        for (int currWord = 0; currWord < wordList.Length; currWord++)
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

    static void ArrangeLine(int wordsPerLine, ref int lastWordOnLine)
    {
        lastWordOnLine--;
        int leftOverLenght = wordsPerLine - usedLenght;
        int whiteSpacesBetweenWords = 0;
        int whiteSpaceRemainder = 0;
        int wordsThatNeedSpace = wordsOnThisLine - 1;

        if (wordsThatNeedSpace > 0)
        {
            whiteSpacesBetweenWords = leftOverLenght / wordsThatNeedSpace;
            whiteSpaceRemainder = leftOverLenght - (whiteSpacesBetweenWords * wordsThatNeedSpace);
        }

        for (int word = firstWord; word <= lastWordOnLine; word++)
        {
            if (word < lastWordOnLine)
            { // If it's not the last word, append a space after the word.
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
    static string ReadEntireInput(int nLines)
    {
        StringBuilder input = new StringBuilder();
        for (int i = 0; i < nLines; i++)
        {
            input.Append(Console.ReadLine());
            input.Append(" ");
        }
        return input.ToString();
    }
}