namespace FriendsOfPesho
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FriendsOfPesho
    {
        private static readonly Dictionary<Node, List<Connection>> StreetsToBuildings = new Dictionary<Node, List<Connection>>();

        private static readonly Dictionary<int, Node> Nodes = new Dictionary<int, Node>();

        private static void Main()
        {
            var hospitals = ReadInput();
            ulong result = long.MaxValue;

            foreach (var hospital in hospitals)
            {
                DoDijkstra(Nodes[hospital]);

                ulong currentResult = 0;
                foreach (var node in Nodes)
                {
                    if (!node.Value.IsHospital)
                    {
                        currentResult += node.Value.DijkstraDistance;
                    }
                }

                if (currentResult < result)
                {
                    result = currentResult;
                }
            }

            Console.WriteLine(result);
        }

        private static void DoDijkstra(Node sourceNode)
        {
            // Reset distance
            foreach (var node in Nodes)
            {
                node.Value.DijkstraDistance = ulong.MaxValue;
            }

            var queue = new Queue<Node>();
            sourceNode.DijkstraDistance = 0;
            queue.Enqueue(sourceNode);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                if (currentNode.DijkstraDistance == ulong.MaxValue)
                {
                    break;
                }

                foreach (var connection in StreetsToBuildings[currentNode])
                {
                    var potentialDistance = currentNode.DijkstraDistance + connection.Distance;
                    if (potentialDistance < connection.ToNode.DijkstraDistance)
                    {
                        connection.ToNode.DijkstraDistance = potentialDistance;
                        queue.Enqueue(connection.ToNode);
                    }
                }
            }

            Console.WriteLine();
        }

        private static IEnumerable<int> ReadInput()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var streetCount = input[1];
            var hospitals = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (var i = 0; i < streetCount; i++)
            {
                ReadConnections();
            }

            foreach (var hospital in hospitals)
            {
                Nodes[hospital].IsHospital = true;
            }

            return hospitals;
        }

        private static void ReadConnections()
        {
            var edgeInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var firstNode = AddNode(Nodes, edgeInfo[0]);
            var secondNode = AddNode(Nodes, edgeInfo[1]);
            var distance = edgeInfo[2];
            AddNodeWithConnection(firstNode);
            AddNodeWithConnection(secondNode);
            StreetsToBuildings[firstNode].Add(new Connection(secondNode, (ulong)distance));
            StreetsToBuildings[secondNode].Add(new Connection(firstNode, (ulong)distance));
        }

        private static void AddNodeWithConnection(Node firstNode)
        {
            if (!StreetsToBuildings.ContainsKey(firstNode))
            {
                StreetsToBuildings.Add(firstNode, new List<Connection>());
            }
        }

        private static Node AddNode(IDictionary<int, Node> nodes, int nodeId)
        {
            if (!nodes.ContainsKey(nodeId))
            {
                nodes.Add(nodeId, new Node(nodeId));
            }

            return nodes[nodeId];
        }
    }

    public class Connection
    {
        public Connection(Node toNode, ulong distance)
        {
            this.ToNode = toNode;
            this.Distance = distance;
        }

        public Node ToNode { get; set; }

        public ulong Distance { get; set; }
    }

    public class Node : IComparable, IComparable<Node>
    {
        public Node(int id, bool isHospital = false)
        {
            this.Id = id;
            this.IsHospital = isHospital;
            this.DijkstraDistance = ulong.MaxValue;
        }

        public int Id { get; set; }

        public ulong DijkstraDistance { get; set; }

        public bool IsHospital { get; set; }

        public int CompareTo(object obj)
        {
            var node = obj as Node;

            return this.CompareTo(node);
        }

        public int CompareTo(Node other)
        {
            return this.DijkstraDistance.CompareTo(other.DijkstraDistance);
        }
    }
}