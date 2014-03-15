/* You are given a tree of N nodes represented as a set of N-1 pairs of nodes 
 * (parent node, child node), each in the range (0..N-1). Write a program to 
 * read the tree and find: */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TreeTraversal
{
    class TreeTraversal
    {
        private static IList<Node<int>> nodeList;
        private static bool[] visited;

        static void Main()
        {
            nodeList = ReadInput();

            Console.WriteLine("The root is: {0}", FindRoot());
            Console.WriteLine("The leaves are: {0}", String.Join(", ", FindLeaves()));
            Console.WriteLine("The middle nodes are: {0}", String.Join(", ", FindMiddleNodes()));
            Console.WriteLine("The longest path takes {0} steps.", FindLongestPath());
        }

        private static int FindLongestPath()
        {
            int longestPath = 0;

            foreach (var leaf in FindLeaves())
            {
                visited = new bool[nodeList.Count];
                TryPath(leaf, 0, ref longestPath);
            }
            return longestPath;
        }

        private static void TryPath(Node<int> startNode, int currentDepth, ref int maxPathCount)
        {
            if (visited[nodeList.IndexOf(startNode)])
            {
                if (currentDepth > maxPathCount)
                {
                    maxPathCount = currentDepth;
                }
                return;
            }

            visited[nodeList.IndexOf(startNode)] = true;

            if (startNode.HasParent)
            {
                TryPath(startNode.Parent, currentDepth + 1, ref maxPathCount);
            }
            else if (startNode.HasChildren)
            {
                foreach (var child in startNode.Offspring)
                {
                    TryPath(child, currentDepth + 1, ref maxPathCount);
                }
            }
        }

        private static IEnumerable<Node<int>> FindMiddleNodes()
        {
            return nodeList.Where(node => (node.HasChildren && node.HasParent));
        }

        private static IEnumerable<Node<int>> FindLeaves()
        {
            return nodeList.Where(node => !node.HasChildren);
        }

        private static Node<int> FindRoot()
        {
            return nodeList.FirstOrDefault(node => (!node.HasParent));
        }

        private static IList<Node<int>> ReadInput()
        {
            if (File.Exists(@"..\..\input.txt"))
            {
                Console.SetIn(new StreamReader(@"..\..\input.txt"));
            }

            var n = int.Parse(Console.ReadLine());
            var nodes = new Node<int>[n];

            for (int i = 0; i < n; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            for (int i = 1; i <= n - 1; i++)
            {
                int[] inputData = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int parentId = inputData[0];
                int childId = inputData[1];

                nodes[parentId].AddChild(nodes[childId]);
                nodes[childId].AddPerent(nodes[parentId]);
            }

            return nodes;
        }
    }
}
