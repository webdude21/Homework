namespace DogeCoin
{
    using System;
    using System.Linq;

    internal class DogeCoin
    {
        private static void Main()
        {
            ulong[,] labyrinth;
            var input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            labyrinth = new ulong[input[0] + 1, input[1] + 1];
            var enemyCount = int.Parse(Console.ReadLine());
            for (var i = 0; i < enemyCount; i++)
            {
                var coordinates = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                labyrinth[coordinates[0] + 1, coordinates[1] + 1]++;
            }

            for (var x = 1; x <= input[0]; x++)
            {
                for (var y = 1; y <= input[1]; y++)
                {
                    labyrinth[x, y] = labyrinth[x - 1, y] > labyrinth[x, y - 1]
                                          ? labyrinth[x, y] + labyrinth[x - 1, y]
                                          : labyrinth[x, y] + labyrinth[x, y - 1];
                }
            }

            Console.WriteLine(labyrinth[input[0], input[1]]);
        }
    }
}