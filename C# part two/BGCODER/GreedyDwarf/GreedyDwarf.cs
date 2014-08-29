namespace GreedyDwarf
{
    using System;

    internal class GreedyDwarf
    {
        private static void Main()
        {
            var valley = GetIntArrayFromInput(Console.ReadLine());
            var maxCoin = int.MinValue;
            var numberOfPatterns = int.Parse(Console.ReadLine());
            for (var pattern = 0; pattern < numberOfPatterns; pattern++)
            {
                maxCoin = GetSumOfLine(valley, maxCoin);
            }

            Console.WriteLine(maxCoin);
        }

        private static int GetSumOfLine(int[] valley, int maxCoin)
        {
            var currentPettern = GetIntArrayFromInput(Console.ReadLine());
            var currentSum = 0;
            var index = 0;
            var tilesVisited = new int[valley.Length];

            while (index < tilesVisited.Length && tilesVisited[index] == 0)
            {
                for (var i = 0; i < currentPettern.Length; i++)
                {
                    if (index >= tilesVisited.Length || tilesVisited[index] != 0)
                    {
                        break;
                    }

                    currentSum = currentSum + valley[index];
                    tilesVisited[index]++;
                    index = index + currentPettern[i];
                    if (index < 0)
                    {
                        if (currentSum > maxCoin)
                        {
                            maxCoin = currentSum;
                        }

                        return maxCoin;
                    }
                }
            }

            if (currentSum > maxCoin)
            {
                maxCoin = currentSum;
            }

            return maxCoin;
        }

        private static int[] GetIntArrayFromInput(string input)
        {
            // This is just a method to extract Int Arrays from the input
            var stringArray = input.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var intArray = new int[stringArray.Length];

            for (var i = 0; i < stringArray.Length; i++)
            {
                intArray[i] = int.Parse(stringArray[i]);
            }

            return intArray;
        }
    }
}