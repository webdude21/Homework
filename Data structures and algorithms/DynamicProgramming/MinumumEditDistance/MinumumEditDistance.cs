/* Write a program to calculate the "Minimum Edit Distance" (MED) between two words. MED(x, y) 
 * is the minimal sum of costs of edit operations used to transform x to y. Sample costs are given below:
cost (replace a letter) = 1
cost (delete a letter) = 0.9
cost (insert a letter) = 0.8
Example: x = "developer", y = "enveloped" > cost = 2.7 
delete ‘d’:  "developer" > "eveloper", cost = 0.9
insert ‘n’:  "eveloper" > "enveloper", cost = 0.8
replace ‘r’ > ‘d’:  "enveloper"  "enveloped", cost = 1
*/

using System;

namespace MinumumEditDistance
{
    class MinumumEditDistance
    {
        const decimal DeletionCost = 0.9m;
        const decimal InsertionCost = 0.8m;
        const decimal SubstitutionCost = 1m;

        static void Main()
        {
            const string firstWord = "developer";
            const string secondWord = "enveloped";

            Console.WriteLine("The minimum edit distance between the words '{0}' and '{1}' is {2}",
                firstWord, secondWord, GetMinimumEditDistance(firstWord, secondWord));
        }
        private static decimal GetMinimumEditDistance(string firstWord, string secondWord)
        {
            var medArray = new decimal[firstWord.Length + 1, secondWord.Length + 1];

            // Cover base cases for both words
            for (var row = 1; row < medArray.GetLength(0); row++)
                medArray[row, 0] = row * DeletionCost;

            for (var col = 1; col < medArray.GetLength(1); col++)
                medArray[0, col] = col * InsertionCost;

            // Fill table
            for (var row = 1; row < medArray.GetLength(0); row++)
            {
                for (var col = 1; col < medArray.GetLength(1); col++)
                {
                    /* if the letters are the same get previous result since
                     * we dont't need to add to the edit distance. If they're 
                     * not then look for the best possible way to get to this
                     * position */

                    if (firstWord[row - 1] == secondWord[col - 1])
                        medArray[row, col] = medArray[row - 1, col - 1];
                    else
                        medArray[row, col] = PickMinimumEditDistance(medArray, row, col);
                }
            }
            return medArray[firstWord.Length,secondWord.Length];
        }
        private static decimal PickMinimumEditDistance(decimal[,] medArray, int row, int col)
        {
            var deletion = medArray[row - 1, col] + DeletionCost;
            var insertion = medArray[row, col - 1] + InsertionCost;
            var substitution = medArray[row - 1, col - 1] + SubstitutionCost;

            var bestCase = deletion;

            if (bestCase > insertion)
                bestCase = insertion;

            if (bestCase > substitution)
                bestCase = substitution;

            return bestCase;
        }
    }
}
