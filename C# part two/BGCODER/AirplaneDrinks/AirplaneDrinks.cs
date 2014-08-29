namespace AirplaneDrinks
{
    using System;
    using System.Collections.Generic;

    internal class AirplaneDrinks
    {
        private const byte timeToFillFlask = 47;

        private const byte teaDrinker = 41;

        private const byte coffeeDrinker = 0;

        private const byte served = 5;

        private static byte servingsLeftInFlask;

        private static ulong elapsedTime;

        private static byte[] passengers;

        private static ulong stuardessPosition;

        private static int leftToServe;

        private static List<ulong> teaDrinkers;

        private static void Main()
        {
            GetInput();
            ServeAllPassangers();
        }

        private static void ServeAllPassangers()
        {
            ServeTeaDrinkers();
            ServeCofeeDrinkers();
            MoveTo(0); // return to the coffe and tea machine
            Console.WriteLine(elapsedTime);
        }

        private static void ServeTeaDrinkers()
        {
            for (var loc = 0; loc < teaDrinkers.Count; loc++)
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

        private static void ServeCofeeDrinkers()
        {
            for (var pos = passengers.Length - 1; pos > 0; pos--)
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

        private static void ServePassenger(int drink)
        {
            elapsedTime += 4;
            servingsLeftInFlask--;
            passengers[stuardessPosition] = served;
            leftToServe--;
        }

        private static void MoveTo(ulong newPosition)
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

        private static void GetInput()
        {
            var passengerCount = ulong.Parse(Console.ReadLine());
            passengers = new byte[passengerCount + 1];
            teaDrinkers = new List<ulong>(byte.Parse(Console.ReadLine()));
            leftToServe = passengers.Length - 1;

            for (var seat = 0; seat < teaDrinkers.Capacity; seat++)
            {
                teaDrinkers.Add(ulong.Parse(Console.ReadLine()));
                passengers[teaDrinkers[seat]] = teaDrinker;
            }

            teaDrinkers.Sort();
            teaDrinkers.Reverse();
        }

        private static void FillFlask()
        {
            MoveTo(0);
            elapsedTime = elapsedTime + timeToFillFlask;
            servingsLeftInFlask = 7;
        }
    }
}