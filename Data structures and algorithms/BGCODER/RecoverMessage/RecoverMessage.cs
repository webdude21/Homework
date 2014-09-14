namespace RecoverMessage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class RecoverMessage
    {
        private static readonly SortedDictionary<char, CharNode> Nodes = new SortedDictionary<char, CharNode>();

        private static CharNode GetNode(char letter)
        {
            if (!Nodes.ContainsKey(letter))
            {
                var node = new CharNode(letter);
                Nodes.Add(letter, node);
            }

            return Nodes[letter];
        }

        private static void Main()
        {
            ReadGraph();
            var result = DoTopologicalSort();

            Console.WriteLine(string.Join(string.Empty, result));
        }

        private static IEnumerable<char> DoTopologicalSort()
        {
            var result = new List<char>();
            var nodesWithoutIncomingEdges = new SortedSet<CharNode>();
            foreach (var node in Nodes.Where(node => node.Value.Parents.Count == 0))
            {
                nodesWithoutIncomingEdges.Add(node.Value);
            }


            while (nodesWithoutIncomingEdges.Count > 0)
            {
                var currentNode = nodesWithoutIncomingEdges.First();
                nodesWithoutIncomingEdges.Remove(currentNode);
                result.Add(currentNode.Letter);

                var children = currentNode.ChilderNodes.ToList();

                foreach (var child in children)
                {
                    child.Parents.Remove(currentNode);
                    currentNode.ChilderNodes.Remove(child);

                    if (child.Parents.Count == 0)
                    {
                        nodesWithoutIncomingEdges.Add(child);
                    }
                }
            }
            return result;
        }

        private static void ReadGraph()
        {
            var messageParts = int.Parse(Console.ReadLine());

            for (var i = 0; i < messageParts; i++)
            {
                var chars = Console.ReadLine().ToCharArray();
                var previousNode = GetNode(chars[0]);

                for (var j = 1; j < chars.Length; j++)
                {
                    var currentNode = GetNode(chars[j]);
                    previousNode.ChilderNodes.Add(currentNode);
                    currentNode.Parents.Add(previousNode);
                    previousNode = currentNode;
                }
            }
        }
    }


    internal class CharNode : IEquatable<CharNode>, IComparable<CharNode>
    {
        public CharNode(char letter)
        {
            this.Letter = letter;
            this.Parents = new SortedSet<CharNode>();
            this.ChilderNodes = new SortedSet<CharNode>();
        }

        public SortedSet<CharNode> Parents { get; set; }

        public SortedSet<CharNode> ChilderNodes { get; set; }

        public char Letter { get; set; }

        public bool IsUsed { get; set; }

        public bool Equals(CharNode other)
        {
            return this.Letter.Equals(other.Letter);
        }

        public int CompareTo(CharNode other)
        {
            return this.Letter.CompareTo(other.Letter);
        }
    }
}