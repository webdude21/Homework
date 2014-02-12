using System;

class GreedyDwarf
{
    static void Main()
    {
        int[] valley = GetIntArrayFromInput(Console.ReadLine()); 
        int maxCoin = int.MinValue;
        int numberOfPatterns = int.Parse(Console.ReadLine());
        for (int pattern = 0; pattern < numberOfPatterns; pattern++)
        {
            maxCoin = GetSumOfLine(valley, maxCoin);
        }

        Console.WriteLine(maxCoin);
    }

    static int GetSumOfLine(int[] valley, int maxCoin)
    {
        int[] currentPettern = GetIntArrayFromInput(Console.ReadLine());
        int currentSum = 0;
        int index = 0;
        int[] tilesVisited = new int[valley.Length];

        while (index < tilesVisited.Length && tilesVisited[index] == 0)
        {
            for (int i = 0; i < currentPettern.Length; i++)
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

    static int[] GetIntArrayFromInput(string input)
    {   // This is just a method to extract Int Arrays from the input
        string[] stringArray = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] intArray = new int[stringArray.Length];

        for (int i = 0; i < stringArray.Length; i++)
        {
            intArray[i] = int.Parse(stringArray[i]);
        }
        return intArray;
    }
}