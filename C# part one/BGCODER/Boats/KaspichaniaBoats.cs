namespace Boats
{
    using System;

    internal class KaspichaniaBoats
    {
        private const char Dot = '.';

        private const char Asterik = '*';

        private static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var baseWidth = (n * 2) + 1;
            var height = 6 + (((n - 3) / 2) * 3);
            var sailsHeight = (height / 3) * 2;
            var hullHeight = height / 3;

            DrawSails(baseWidth, sailsHeight);
            DrawHull(baseWidth, hullHeight);
        }

        private static void DrawHull(int baseWidth, int hullHeight)
        {
            var offset = 0;
            for (var row = 0; row < hullHeight; row++)
            {
                for (var col = 0; col < baseWidth; col++)
                {
                    if (row == hullHeight - 1 && col - 1 > offset && baseWidth - col - 2 > offset)
                    {
                        Console.Write(Asterik);
                    }
                    else if (col - 1 == offset)
                    {
                        Console.Write(Asterik);
                    }
                    else if (baseWidth - col - 2 == offset)
                    {
                        Console.Write(Asterik);
                    }
                    else if (baseWidth / 2 == col)
                    {
                        Console.Write(Asterik);
                    }
                    else
                    {
                        Console.Write(Dot);
                    }
                }

                offset++;
                Console.WriteLine();
            }
        }

        private static void DrawSails(int baseWidth, int sailsHeight)
        {
            var offset = 0;

            for (var row = 0; row < sailsHeight; row++)
            {
                for (var col = 0; col < baseWidth; col++)
                {
                    if (row == sailsHeight - 1)
                    {
                        Console.Write(Asterik);
                    }
                    else if (baseWidth / 2 == col + offset)
                    {
                        Console.Write(Asterik);
                    }
                    else if (baseWidth / 2 == col - offset)
                    {
                        Console.Write(Asterik);
                    }
                    else if (baseWidth / 2 == col)
                    {
                        Console.Write(Asterik);
                    }
                    else
                    {
                        Console.Write(Dot);
                    }
                }

                offset++;
                Console.WriteLine();
            }
        }
    }
}