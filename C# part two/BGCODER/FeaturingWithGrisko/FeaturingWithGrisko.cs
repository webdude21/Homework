namespace FeaturingWithGrisko
{
    using System;

    internal class FeaturingWithGrisko
    {
        private static int resultCount;

        private static int[] isUsed;

        private static void Main()
        {
            isUsed = new int[26];
            var inputString = Console.ReadLine();

            /* This actually uses the fact that chars are numbers
           Here the index of the array actually shows which is the letter
           and the value shows how many times it has been used.
           The task can be solved using a dictionary, but it's slower I think */
            for (var i = 0; i < inputString.Length; i++)
            {
                isUsed[inputString[i] - 'a']++;
            }

            if (!OnlyUniqueLetters())
            {
                var output = new char[inputString.Length];
                GetComb(output, 0);
                Console.WriteLine(resultCount);
            }
            else
            {
                /* This is an optimization, if there are only unique letters in the word 
             * there's no sense in actually generating the permutations and checking 
             * if they're valid words because, they'll always be valid. Instead, if 
             * the letters are unique you just need to calculate the factorial of the 
             * numbers of letters used. Permutations without repetition is n! 
             * (where n is the length of the word in this case)*/
                Console.WriteLine(FactCalc(inputString.Length));
            }
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
            for (var i = 0; i < isUsed.Length; i++)
            {
                if (isUsed[i] > 1)
                {
                    return false;
                }
            }

            return true;
        }

        private static void GetComb(char[] output, int index)
        {
            if (index == output.Length)
            {
                // this is the bottom of the recursion (when the array has been filled)
                if (IsValidWord(output))
                {
                    resultCount++;
                }

                return;
            }

            // The permutations are generated here
            for (var i = 0; i < isUsed.Length; i++)
            {
                if (isUsed[i] > 0)
                {
                    output[index] = (char)(i + 'a'); // convert back to char
                    isUsed[i]--;

                    // remove the current letter (once) from the isUsed array
                    GetComb(output, index + 1); /* recursive call to generate the 
                rest of the permutations the rest of the words */
                    isUsed[i]++;

                    // after the recursion return the letter so it can be again
                    // in the next permutation
                }
            }
        }

        private static bool IsValidWord(char[] input)
        {
            // IsValidWord checks if the word has two neighbouring letters are the same
            for (var i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}