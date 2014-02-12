using System;
using System.Collections.Generic;

class AirplaneDrinks
{
    const byte timeToFillFlask = 47;
    static byte servingsLeftInFlask = 0;
    static ulong elapsedTime = 0;
    const byte teaDrinker = 41;
    const byte coffeeDrinker = 0;
    const byte served = 5;
    static byte[] passengers;
    static ulong stuardessPosition = 0;
    static int leftToServe = 0;
    static List<ulong> teaDrinkers;

    static void Main()
    {
        GetInput();
        ServeAllPassangers();
    }
    static void ServeAllPassangers()
    {
        ServeTeaDrinkers();
        ServeCofeeDrinkers();
        MoveTo(0); // return to the coffe and tea machine
        Console.WriteLine(elapsedTime);
    }
    static void ServeTeaDrinkers()
    {
        for (int loc = 0; loc < teaDrinkers.Count; loc++)
        {
            if (servingsLeftInFlask == 0)
            {
                FillFlask();
            }
            MoveTo(teaDrinkers[loc]);
            ServePassenger(teaDrinker);
        }
        servingsLeftInFlask = 0; // the tea will not be used anymore
    }
    static void ServeCofeeDrinkers()
    {
        for (int pos = passengers.Length - 1; pos > 0; pos--)
        {
            if (leftToServe == 0)
            {
                break;
            }
            if (servingsLeftInFlask == 0)
            {
                FillFlask();
            }

            if (passengers[pos] == coffeeDrinker)
            {
                MoveTo((ulong)pos);
                ServePassenger(coffeeDrinker);
            }
        }
    }
    static void ServePassenger(int drink)
    {
        elapsedTime += 4;
        servingsLeftInFlask--;
        passengers[stuardessPosition] = served;
        leftToServe--;
    }
    static void MoveTo(ulong newPosition)
    {
        if (stuardessPosition > newPosition)
        {
            elapsedTime = elapsedTime + (stuardessPosition - newPosition);
        }
        else
        {
            elapsedTime = elapsedTime + (newPosition - stuardessPosition);
        }
        stuardessPosition = newPosition;
    }
    static void GetInput()
    {
        ulong passengerCount = ulong.Parse(Console.ReadLine());
        passengers = new byte[passengerCount + 1];
        teaDrinkers = new List<ulong>(byte.Parse(Console.ReadLine()));
        leftToServe = passengers.Length - 1;

        for (int seat = 0; seat < teaDrinkers.Capacity; seat++)
        {
            teaDrinkers.Add(ulong.Parse(Console.ReadLine()));
            passengers[teaDrinkers[seat]] = teaDrinker;
        }

        teaDrinkers.Sort();
        teaDrinkers.Reverse();
    }
    static void FillFlask()
    {
        MoveTo(0);
        elapsedTime = elapsedTime + timeToFillFlask;
        servingsLeftInFlask = 7;
    }
}