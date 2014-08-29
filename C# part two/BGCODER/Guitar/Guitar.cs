namespace Guitar
{
    using System;

    internal class Guitar
    {
        private static void Main()
        {
            var songsAsStrings = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            var songs = new int[songsAsStrings.Length];
            var start = int.Parse(Console.ReadLine());
            var maxVolume = int.Parse(Console.ReadLine());

            for (var i = 0; i < songs.Length; i++)
            {
                songs[i] = int.Parse(songsAsStrings[i]);
            }

            var solutions = new int[songs.Length + 1, maxVolume + 1];
            solutions[0, start] = 1;

            for (var i = 1; i < solutions.GetLength(0); i++)
            {
                var interval = songs[i - 1];
                for (var j = 0; j < solutions.GetLength(1); j++)
                {
                    if (solutions[i - 1, j] == 1)
                    {
                        if (j - interval >= 0)
                        {
                            solutions[i, j - interval] = 1;
                        }

                        if (j + interval <= maxVolume)
                        {
                            solutions[i, j + interval] = 1;
                        }
                    }
                }
            }

            for (var i = maxVolume; i >= 0; i--)
            {
                if (solutions[songs.Length, i] == 1)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine(-1);
        }
    }
}