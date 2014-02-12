using System;

class TheyAreGreen
{
    static int[] letters = new int[26];
    static int[] output;
    static int inputLenght = 0;
    static int wordCount = 0;

    static void Main()
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

    static int FactCalc(int n)
    {
        int currFact = 1;
        for (int i = 2; i <= n; i++)
        {
            currFact = currFact * i;
        }
        return currFact;
    }
    static bool OnlyUniqueLetters()
    {
        for (int i = 0; i < letters.Length; i++)
        {
            if (letters[i] > 1)
            {
                return false;
            }
        }
        return true;
    }

    static bool IsWord()
    {
        for (int i = 0; i < output.Length - 1; i++)
        {
            if (output[i] == output[i + 1])
            {
                return false;
            }
        }
        return true;
    }

    static void Permutate(int index)
    {
        if (index == inputLenght)
        {
            if (IsWord())
            {
                wordCount++;
            }
            return;
        }
        else
        {
            for (int i = 0; i < letters.Length; i++)
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

    static void ReadInput()
    {
        inputLenght = int.Parse(Console.ReadLine());
        output = new int[inputLenght];
        for (int ch = 0; ch < inputLenght; ch++)
        {
            letters[char.Parse(Console.ReadLine()) - 97]++;
        }
    }
}
