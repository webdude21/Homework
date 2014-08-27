namespace Guitar
{
    using System;
    using System.Linq;

    internal class Guitar
    {
        private static void Main()
        {
            var songs =
                Console.ReadLine()
                    .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            var start = int.Parse(Console.ReadLine());
            var maxVolume = int.Parse(Console.ReadLine());
            var solutions = new int[songs.Length + 1, maxVolume + 1];
            solutions[0, start] = 1;

            for (var row = 1; row < solutions.GetLength(0); row++)
            {
                var interval = songs[row - 1];
                for (var col = 0; col < solutions.GetLength(1); col++)
                {
                    if (solutions[row - 1, col] != 1)
                    {
                        continue;
                    }

                    if (col - interval >= 0)
                    {
                        solutions[row, col - interval] = 1;
                    }

                    if (col + interval <= maxVolume)
                    {
                        solutions[row, col + interval] = 1;
                    }
                }
            }

            for (var solution = maxVolume; solution >= 0; solution--)
            {
                if (solutions[songs.Length, solution] == 1)
                {
                    Console.WriteLine(solution);
                    return;
                }
            }

            Console.WriteLine(-1);
        }
    }
}