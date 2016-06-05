namespace PenguinAirlines
{
    using System;
    using System.Linq;
    using System.Threading;

    internal class PenguinAirlines
    {
        private const string DirectFlight = "There is a direct flight.";

        private const string NoFlightsAvailable = "No flights available.";

        private const string IndirectFlights = "There are flights, unfortunately they are not direct, grandma :(";

        private const string NoMoreQueries = "Have a break";

        private const string NoFlights = "None";

        private static int islands;

        private static bool[,] adjacencyMatrix;

        private static int[] disjointSet;

        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
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

        private static int Find(int i)
        {
            if (disjointSet[i] < 0)
            {
                return i;
            }

            disjointSet[i] = Find(disjointSet[i]);

            return disjointSet[i];
        }

        private static bool Connected(int from, int y)
        {
            return Find(from) == Find(y);
        }

        private static string CheckForFligths(int from, int to)
        {
            if (adjacencyMatrix[from, to])
            {
                return DirectFlight;
            }

            if (Connected(from, to))
            {
                return IndirectFlights;
            }

            return NoFlightsAvailable;
        }

        private static void ReadInput()
        {
            islands = int.Parse(Console.ReadLine());
            disjointSet = Enumerable.Repeat(-1, islands).ToArray();
            adjacencyMatrix = new bool[islands, islands];
            for (var fligthFrom = 0; fligthFrom < islands; fligthFrom++)
            {
                foreach (var fligthTo in Console.ReadLine().Split().Where(f => f != NoFlights).Select(int.Parse))
                {
                    adjacencyMatrix[fligthFrom, fligthTo] = true;
                    adjacencyMatrix[fligthTo, fligthFrom] = true;
                    Union(fligthFrom, fligthTo);
                }
            }
        }

        private static void Union(int from, int to)
        {
            from = Find(from);
            to = Find(to);

            if (from == to)
            {
                return;
            }

            disjointSet[from] = to;
        }
    }
}