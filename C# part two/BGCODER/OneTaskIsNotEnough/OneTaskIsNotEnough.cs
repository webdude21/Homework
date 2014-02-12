using System;
using System.IO;

class OneTaskIsNotEnough
{
    static bool[] lamps;
    static string instructionsOne;
    static string instructionsTwo;

    static void Main()
    {
        GetInput();
        Console.WriteLine(SolveTaskOne());
        // Not finished
    }

    static int SolveTaskOne()
    {
        int jumps = 1;
        int lastLamp = 0;
        while (!AllLampsAreLit())
        {
            jumps++;
            int currentLamp = Array.IndexOf(lamps, false);
            while (currentLamp < lamps.Length)
            {
                lamps[currentLamp] = true;
                lastLamp = currentLamp + 1;
                currentLamp += jumps;
            }
        }
        return lastLamp;
    }

    static bool AllLampsAreLit()
    {
        foreach (bool lamp in lamps)
        {
            if (!lamp)
            {
                return false;
            }
        }
        return true;
    }

    static void GetInput()
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