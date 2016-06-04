namespace PenguinAirlines
{
    using System;
    using System.Linq;

    internal class PenguinAirlines
    {
        private const string DirectFlight = "There is a direct flight.";

        private const string NoFlightsAvailable = "No flights available.";

        private const string NoMoreQueries = "Have a break";

        private const string NoFlights = "None";

        private static int islands;

        private static bool[,] adjacencyMatrix;

        private static void Main()
        {
            ReadInput();
            RespondToQueries();
        }

        private static void RespondToQueries()
        {
            var queryInput = Console.ReadLine();

            while (queryInput != NoMoreQueries)
            {
                var parsedInput = queryInput.Split();
                Console.WriteLine(CheckForFligths(int.Parse(parsedInput[0]), int.Parse(parsedInput[1])));
                queryInput = Console.ReadLine();
            }
        }

        private static string CheckForFligths(int from, int to)
        {
            return adjacencyMatrix[from, to] ? DirectFlight : NoFlightsAvailable;
        }

        private static void ReadInput()
        {
            islands = int.Parse(Console.ReadLine());
            adjacencyMatrix = new bool[islands, islands];

            for (var fligthFrom = 0; fligthFrom < islands; fligthFrom++)
            {
                foreach (var fligthTo in Console.ReadLine().Split().Where(f => f != NoFlights).Select(int.Parse))
                {
                    adjacencyMatrix[fligthFrom, fligthTo] = true;
                    adjacencyMatrix[fligthTo, fligthFrom] = true;
                }
            }
        }
    }
}