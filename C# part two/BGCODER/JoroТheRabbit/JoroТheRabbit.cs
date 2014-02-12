using System;

class JoroТheRabbit
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        int[] terrain = new int[input.Length];
        int maxVisited = int.MinValue;

        for (int i = 0; i < input.Length; i++)
        {
            terrain[i] = int.Parse(input[i]);
        }

        for (int steps = 1; steps < terrain.Length; steps++)
        {
            for (int startIndex = 0; startIndex < terrain.Length; startIndex++)
            {
                int index = startIndex;
                int lastStep = int.MinValue;
                int currentMax = 0;
                while (terrain[index] > lastStep)
                {
                    lastStep = terrain[index];
                    currentMax++;

                    if (index + steps >= terrain.Length)
                    {
                        index = index + steps - terrain.Length;
                    }
                    else
                    {
                        index = index + steps;
                    }
                }

                if (currentMax > maxVisited)
                {
                    maxVisited = currentMax;
                }
            }
        }
        Console.WriteLine(maxVisited);
    }
}