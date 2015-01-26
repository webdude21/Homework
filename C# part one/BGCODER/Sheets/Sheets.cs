namespace Sheets
{
    using System;

    internal class Sheets
    {
        private static void Main()
        {
            var pieces = int.Parse(Console.ReadLine());
            var currentSize = 1024;

            for (var i = 0; i < 11; i++)
            {
                if (currentSize - pieces <= 0)
                {
                    pieces -= currentSize;
                }
                else
                {
                    Console.WriteLine("A{0}", i);
                }

                currentSize = currentSize / 2;
            }
        }
    }
}