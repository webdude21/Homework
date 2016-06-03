namespace DancingMoves
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class DancingMoves
    {
        private const string Stop = "stop";

        private static int[] input;

        private static int currentPosition;

        private static void Main()
        {
            input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var directions = Console.ReadLine();
            var results = new List<int>();

            while (directions != Stop)
            {
                results.Add(ExecuteDirections(directions.Split()));
                directions = Console.ReadLine();
            }

            Console.WriteLine("{0:F1}", results.Average());
        }

        private static int ExecuteDirections(string[] directionInfo)
        {
            var steps = int.Parse(directionInfo[0]);
            var stepSize = int.Parse(directionInfo[2]);
            var setpDirection = directionInfo[1];
            var sum = 0;

            while (steps > 0)
            {
                steps--;
                sum += ExecuteStep(setpDirection, stepSize);
            }

            return sum;
        }

        private static int ExecuteStep(string stepDirection, int stepSize)
        {
            if (stepDirection == "right")
            {
                currentPosition = (currentPosition + stepSize) % input.Length;
            }
            else
            {
                if ((currentPosition - stepSize) % input.Length < 0)
                {
                    currentPosition = input.Length + (currentPosition - stepSize) % input.Length;
                }
                else
                {
                    currentPosition = (currentPosition - stepSize) % input.Length;
                }
            }

            return input[currentPosition];
        }
    }
}