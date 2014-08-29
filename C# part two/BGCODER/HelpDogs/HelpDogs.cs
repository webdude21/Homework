namespace HelpDogs
{
    using System;
    using System.Linq;
    using System.Numerics;

    internal class HelpDogs
    {
        private const int Enemy = -1;

        private const int Food = -2;

        private static BigInteger[,] labyrinth;

        private static int n;

        private static int m;

        private static void Main()
        {
            ReadInput();
            Solve();
        }

        private static void ReadInput()
        {
            var input = Console.ReadLine().Split().ToArray();
            n = int.Parse(input[0]);
            m = int.Parse(input[1]);
            labyrinth = new BigInteger[n + 1, m + 1];

            input = Console.ReadLine().Split().ToArray();
            var Fx = int.Parse(input[0]);
            var Fy = int.Parse(input[1]);
            labyrinth[Fx + 1, Fy + 1] = Food;

            var enemyCount = int.Parse(Console.ReadLine());

            for (var i = 0; i < enemyCount; i++)
            {
                input = Console.ReadLine().Split().ToArray();
                var Ex = int.Parse(input[0]);
                var Ey = int.Parse(input[1]);
                labyrinth[Ex + 1, Ey + 1] = Enemy;
            }
        }

        public static void Solve()
        {
            for (var index = 1; index <= n; index++)
            {
                if (labyrinth[index, 1] == Enemy)
                {
                    break;
                }

                labyrinth[index, 1] = 1;
            }

            for (var index = 1; index <= m; index++)
            {
                if (labyrinth[1, index] == Enemy)
                {
                    break;
                }

                labyrinth[1, index] = 1;
            }

            for (var row = 1; row <= n; row++)
            {
                for (var col = 1; col <= m; col++)
                {
                    if (labyrinth[row, col] == Food)
                    {
                        labyrinth[row, col] = labyrinth[row - 1, col] + labyrinth[row, col - 1];
                        Console.WriteLine(labyrinth[row, col]);
                        Environment.Exit(10);
                    }

                    if (labyrinth[row, col] == 0)
                    {
                        labyrinth[row, col] = labyrinth[row - 1, col] + labyrinth[row, col - 1];
                    }
                    else if (labyrinth[row, col] == Enemy)
                    {
                        labyrinth[row, col] = 0;
                    }
                }
            }

            Console.WriteLine(1);
        }
    }
}