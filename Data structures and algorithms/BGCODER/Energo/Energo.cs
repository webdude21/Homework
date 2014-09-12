namespace Energo
{
    using System;
    using System.Linq;

    using GraphLibrary;

    internal class Energo
    {
        private static void Main()
        {
            var cableGraph = new Graph<int>();
            var inputLines = int.Parse(Console.ReadLine());

            for (var i = 0; i < inputLines; i++)
            {
                var edgeInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
                cableGraph.AddConnection(edgeInfo[0], edgeInfo[1], edgeInfo[2], true); 
            }

            var resultTree = cableGraph.PrimeMinimumSpanningTree(1);
            Console.WriteLine(resultTree.Sum(edge => edge.Distance));
        }
    }
}