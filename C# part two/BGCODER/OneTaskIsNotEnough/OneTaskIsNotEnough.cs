namespace OneTaskIsNotEnough
{
    using System;
    using System.IO;

    internal class OneTaskIsNotEnough
    {
        private static bool[] lamps;

        private static string instructionsOne;

        private static string instructionsTwo;

        private static void Main()
        {
            GetInput();
            Console.WriteLine(SolveTaskOne());

            // Not finished
        }

        private static int SolveTaskOne()
        {
            var jumps = 1;
            var lastLamp = 0;
            while (!AllLampsAreLit())
            {
                jumps++;
                var currentLamp = Array.IndexOf(lamps, false);
                while (currentLamp < lamps.Length)
                {
                    lamps[currentLamp] = true;
                    lastLamp = currentLamp + 1;
                    currentLamp += jumps;
                }
            }

            return lastLamp;
        }

        private static bool AllLampsAreLit()
        {
            foreach (var lamp in lamps)
            {
                if (!lamp)
                {
                    return false;
                }
            }

            return true;
        }

        private static void GetInput()
        {
            if (File.Exists(@"..\..\input.txt"))
            {
                Console.SetIn(new StreamReader(@"..\..\input.txt"));
            }

            lamps = new bool[int.Parse(Console.ReadLine())];
            instructionsOne = Console.ReadLine();
            instructionsTwo = Console.ReadLine();
        }
    }
}