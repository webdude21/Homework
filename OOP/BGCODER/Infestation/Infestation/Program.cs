namespace Infestation
{
    using System;
    using System.IO;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var pen = InitializePen();
            StartOperations(pen);
        }

        private static void StartOperations(HoldingPen pen)
        {
            var input = Console.ReadLine();
            while (input != "end")
            {
                pen.ParseCommand(input);
                input = Console.ReadLine();
            }
        }

        private static HoldingPen InitializePen()
        {
            if (File.Exists(@"../../../input.txt"))
            {
                Console.SetIn(new StreamReader(@"../../../input.txt"));
            }

            return new ExtendedHoldingPen();
        }
    }
}