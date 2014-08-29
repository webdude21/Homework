namespace TheyAreGreen
{
    using System;

    internal class TheyAreGreen
    {
        private static int[] letters = new int[26];

        private static int[] output;

        private static int inputLenght;

        private static int wordCount;

        private static void Main()
        {
            ReadInput();
            if (OnlyUniqueLetters())
            {
                wordCount = FactCalc(inputLenght);
            }
            else
            {
                Permutate(0);
            }

            Console.WriteLine(wordCount);
        }

        private static int FactCalc(int n)
        {
            var currFact = 1;
            for (var i = 2; i <= n; i++)
            {
                currFact = currFact * i;
            }

            return currFact;
        }

        private static bool OnlyUniqueLetters()
        {
            for (var i = 0; i < letters.Length; i++)
            {
                if (letters[i] > 1)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsWord()
        {
            for (var i = 0; i < output.Length - 1; i++)
            {
                if (output[i] == output[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static void Permutate(int index)
        {
            if (index == inputLenght)
            {
                if (IsWord())
                {
                    wordCount++;
                }
            }
            else
            {
                for (var i = 0; i < letters.Length; i++)
                {
                    if (letters[i] > 0)
                    {
                        letters[i]--;
                        output[index] = i;
                        Permutate(index + 1);
                        letters[i]++;
                    }
                }
            }
        }

        private static void ReadInput()
        {
            inputLenght = int.Parse(Console.ReadLine());
            output = new int[inputLenght];
            for (var ch = 0; ch < inputLenght; ch++)
            {
                letters[char.Parse(Console.ReadLine()) - 97]++;
            }
        }
    }
}