using System;
using System.Text;

class MovingLetters
{
    static void Main()
    {
        string input = Console.ReadLine();
        Console.WriteLine(MoveLetters(ExtractLetters(input)));
    }

    static StringBuilder MoveLetters(StringBuilder letters)
    {
        int movements = 0;
        for (int letter = 0; letter < letters.Length; letter++)
        {
            movements = char.ToLower(letters[letter]) - 'a' + letter + 1;
            char temp = letters[letter];
            if (movements >= letters.Length)
            {
                movements = (movements % letters.Length);
            }
            letters.Remove(letter, 1);
            letters.Insert(movements, temp);
        }
        return letters;
    }

    static StringBuilder ExtractLetters(string input)
    {
        StringBuilder extractor = new StringBuilder();
        string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int maxLenght = GetLargestWord(words);

        for (int index = 1; index <= maxLenght; index++)
        {
            for (int wrd = 0; wrd < words.Length; wrd++)
            {
                if (words[wrd].Length - index >= 0)
                {
                    extractor.Append(words[wrd][words[wrd].Length - index]);
                }
            }
        }
        return extractor;
    }

    static int GetLargestWord(string[] words)
    {
        int maxLenght = 0;
        foreach (string wrd in words)
        {
            if (wrd.Length > maxLenght)
            {
                maxLenght = wrd.Length;
            }
        }
        return maxLenght;
    }
}