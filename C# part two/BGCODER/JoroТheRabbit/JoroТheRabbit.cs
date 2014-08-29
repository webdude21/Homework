namespace JoroТheRabbit
{
    using System;

    internal class JoroТheRabbit
    {
        private static void Main()
        {
            var input = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            var terrain = new int[input.Length];
            var maxVisited = int.MinValue;

            for (var i = 0; i < input.Length; i++)
            {
                terrain[i] = int.Parse(input[i]);
            }

            for (var steps = 1; steps < terrain.Length; steps++)
            {
                for (var startIndex = 0; startIndex < terrain.Length; startIndex++)
                {
                    var index = startIndex;
                    var lastStep = int.MinValue;
                    var currentMax = 0;
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
}