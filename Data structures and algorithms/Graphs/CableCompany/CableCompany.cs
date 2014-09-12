namespace CableCompany
{
    using System;

    using GraphLibrary;

    internal class CableCompany
    {
        private static void Main(string[] args)
        {
            var streetGraph = InitializeGraph();
            var result = streetGraph.PrimeMinimumSpanningTree(1);
            var cableUsed = 0m;

            foreach (var edge in result)
            {
                Console.WriteLine(edge);
                cableUsed += edge.Distance;
            }

            Console.WriteLine("The cable used is {0}", cableUsed);
        }

        private static Graph<int> InitializeGraph()
        {
            var graph = new Graph<int>();

            for (var i = 0; i < 6; i++)
            {
                graph.AddNode(i);
            }

            graph.AddConnection(1, 2, 1, true);
            graph.AddConnection(1, 4, 2, true);
            graph.AddConnection(2, 3, 3, true);
            graph.AddConnection(2, 5, 13, true);
            graph.AddConnection(3, 4, 4, true);
            graph.AddConnection(3, 6, 3, true);
            graph.AddConnection(4, 6, 16, true);
            graph.AddConnection(4, 7, 14, true);
            graph.AddConnection(5, 6, 12, true);
            graph.AddConnection(5, 8, 1, true);
            graph.AddConnection(5, 9, 13, true);
            graph.AddConnection(6, 7, 1, true);
            graph.AddConnection(6, 9, 1, true);

            return graph;
        }
    }
}