using System;
using System.Collections.Generic;
using System.IO;

class Guitar
{
    static void Main()
    {
        string[] songsAsStrings = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        int[] songs = new int[songsAsStrings.Length];
        int start = int.Parse(Console.ReadLine());
        int maxVolume = int.Parse(Console.ReadLine());

        for (int i = 0; i < songs.Length; i++)
        {
            songs[i] = int.Parse(songsAsStrings[i]);
        }

        int[,] solutions = new int[songs.Length + 1, maxVolume +1];
        solutions[0, start] = 1;

        for (int i = 1; i < solutions.GetLength(0); i++)
        {
            int interval = songs[i - 1];
            for (int j = 0; j < solutions.GetLength(1); j++)
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

        for (int i = maxVolume; i >= 0; i--)
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