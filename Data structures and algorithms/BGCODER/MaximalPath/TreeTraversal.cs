using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MaximalPath
{
    internal class TreeTraversal
    {
        private static IList<Node<int>> nodeList;

        private static readonly HashSet<Node<int>> UsedNodes = new HashSet<Node<int>>();

        private static readonly char[] CharsToRemove = { '(', ')', ' ', '<', '-' };

        private static bool passedRoot;

        private static void Main()
        {
            nodeList = ReadInput();
            Console.WriteLine(FindLongestPath());
        }

        private static ulong FindLongestPath()
        {
            ulong currnetMaxPath = 0;

            foreach (var leaf in FindLeaves())
            {
                UsedNodes.Clear();
                passedRoot = false;
                TryPath(leaf, 0, ref currnetMaxPath);
            }

            return currnetMaxPath;
        }

        private static void TryPath(Node<int> startNode, ulong currentPathValue, ref ulong currnetMaxPath)
        {
            while (true)
            {
                if (UsedNodes.Contains(startNode))
                {
                    return;
                }

                UsedNodes.Add(startNode);
                currentPathValue = (ulong)startNode.Value + currentPathValue;

                if (startNode.HasParent && !passedRoot)
                {
                    TryPath(startNode.Parent, currentPathValue, ref currnetMaxPath);
                    continue;
                }

                passedRoot = true;

                foreach (var child in startNode.Offspring)
                {
                    TryPath(child, currentPathValue, ref currnetMaxPath);
                }

                if (currnetMaxPath < currentPathValue)
                {
                    currnetMaxPath = currentPathValue;
                }
            }
        }

        private static IEnumerable<Node<int>> FindLeaves()
        {
            return nodeList.Where(node => !node.HasChildren);
        }

        private static IList<Node<int>> ReadInput()
        {
            if (File.Exists(@"..\..\input.txt"))
            {
                Console.SetIn(new StreamReader(@"..\..\input.txt"));
            }

            var n = int.Parse(Console.ReadLine());
            var nodes = new Dictionary<int, Node<int>>();

            for (var i = 1; i < n; i++)
            {
                var inputData =
                    Console.ReadLine()
                        .Split(CharsToRemove, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                var parentId = inputData[0];
                var childId = inputData[1];

                if (!nodes.ContainsKey(parentId))
                {
                    nodes.Add(parentId, new Node<int>(parentId));
                }

                if (!nodes.ContainsKey(childId))
                {
                    nodes.Add(childId, new Node<int>(childId));
                }

                nodes[parentId].AddChild(nodes[childId]);
                nodes[childId].AddPerent(nodes[parentId]);
            }

            return nodes.Values.ToList();
        }
    }
}