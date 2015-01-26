namespace Eggcelent
{
    using System;

    internal class Eggcelent
    {
        private const char Dot = '.';

        private const char Asterik = '*';

        private static void Main()
        {
            var n = int.Parse(Console.ReadLine()); // 4
            var eggHeight = 2 * n; // 8 
            var eggWidth = (3 * n) - 1; // 11
            var drawingAreaWidth = (3 * n) + 1; // 13
            var eggEnds = n - 1; // 3
            var eggMiddle = drawingAreaWidth / 2;

            for (var row = 0; row < eggHeight; row++)
            {
                for (var col = 0; col < drawingAreaWidth; col++)
                {
                    if (col > 0 && col < eggWidth)
                    {
                        if ((row == 0 || row == eggHeight - 1) && col > eggMiddle - (eggEnds / 2) - 1 && col < eggMiddle + (eggEnds / 2) + 1)
                        {
                            Console.Write(Asterik);
                        }
                        else if (row > 0 && col + row + eggEnds == eggMiddle + 1)
                        {
                            Console.Write(Asterik);
                        }
                        else
                        {
                            Console.Write(Dot);
                        }
                    }
                    else
                    {
                        Console.Write(Dot);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}