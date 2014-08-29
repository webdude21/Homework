namespace MovingLetters
{
    using System;
    using System.Text;

    internal class MovingLetters
    {
        private static void Main()
        {
            var input = Console.ReadLine();
            Console.WriteLine(MoveLetters(ExtractLetters(input)));
        }

        private static StringBuilder MoveLetters(StringBuilder letters)
        {
            var movements = 0;
            for (var letter = 0; letter < letters.Length; letter++)
            {
                movements = char.ToLower(letters[letter]) - 'a' + letter + 1;
                var temp = letters[letter];
                if (movements >= letters.Length)
                {
                    movements = movements % letters.Length;
                }

                letters.Remove(letter, 1);
                letters.Insert(movements, temp);
            }

            return letters;
        }

        private static StringBuilder ExtractLetters(string input)
        {
            var extractor = new StringBuilder();
            var words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var maxLenght = GetLargestWord(words);

            for (var index = 1; index <= maxLenght; index++)
            {
                for (var wrd = 0; wrd < words.Length; wrd++)
                {
                    if (words[wrd].Length - index >= 0)
                    {
                        extractor.Append(words[wrd][words[wrd].Length - index]);
                    }
                }
            }

            return extractor;
        }

        private static int GetLargestWord(string[] words)
        {
            var maxLenght = 0;
            foreach (var wrd in words)
            {
                if (wrd.Length > maxLenght)
                {
                    maxLenght = wrd.Length;
                }
            }

            return maxLenght;
        }
    }
}