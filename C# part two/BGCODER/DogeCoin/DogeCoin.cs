using System;
using System.Linq;

namespace DogeCoin
{
    class DogeCoin
    {
        private static ulong[,] labyrinth;
        private static int n, m;

        static void Main()
        {
            ReadInput();
            Console.WriteLine(GetBestPath());

        }

        private static void ReadInput()
        {
            var input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            n = input[0] + 1;
            m = input[1] + 1;
            labyrinth = new ulong[n, m];
            var enemyCount = int.Parse(Console.ReadLine());
            for (var i = 0; i < enemyCount; i++)
            {
                var coordinates = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                labyrinth[coordinates[0] + 1, coordinates[1] + 1]++;
            }
        }

        private static ulong GetBestPath()
        {
            for (var x = 1; x < n; x++)
            {
                for (var y = 1; y < m; y++)
                {
                    if (labyrinth[x - 1, y] > labyrinth[x, y - 1])
                    {
                        labyrinth[x, y] += labyrinth[x - 1, y];
                    }
                    else
                    {
                        labyrinth[x, y] += labyrinth[x, y - 1];
                    }
                }
            }
            return labyrinth[n - 1, m - 1];
        }
    }
}
