namespace GraphLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Graph<T>
    {
        private readonly HashSet<Node<T>> visited;

        public Graph()
        {
            this.Nodes = new Dictionary<T, Node<T>>();
            this.visited = new HashSet<Node<T>>();
        }

        internal IDictionary<T, Node<T>> Nodes { get; private set; }

        public void AddNode(T name)
        {
            var node = new Node<T>(name);
            if (this.Nodes.ContainsKey(name))
            {
                throw new ArgumentException(string.Format("Node with name {0} is existing in the graph.", name));
            }

            this.Nodes.Add(name, node);
        }

        public void AddConnection(T sourceNode, T targetNode, decimal distance, bool twoWay)
        {
            if (!this.Nodes.ContainsKey(sourceNode))
            {
                this.AddNode(sourceNode);
            }

            if (!this.Nodes.ContainsKey(targetNode))
            {
                this.AddNode(targetNode);
            }

            this.Nodes[sourceNode].AddConnection(this.Nodes[targetNode], distance, twoWay);
        }

        public List<Node<T>> FindShortestDistanceToAllNodes(T startNodeName)
        {
            if (!this.Nodes.ContainsKey(startNodeName))
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("{0} is not contained in the graph.", startNodeName));
            }

            this.SetShortestDistances(this.Nodes[startNodeName]);
            var nodes = new List<Node<T>>();

            foreach (var item in this.Nodes)
            {
                if (!item.Key.Equals(startNodeName))
                {
                    nodes.Add(item.Value);
                }
            }

            return nodes;
        }

        public void SetShortestDistances(Node<T> startNode)
        {
            var queue = new PriorityQueue<Node<T>>();

            // set to all nodes DijkstraDistance to PositiveInfinity
            foreach (var node in this.Nodes)
            {
                if (!startNode.Name.Equals(node.Key))
                {
                    node.Value.DijkstraDistance = decimal.MaxValue;

                    // queue.Enqueue(node.Value);
                }
            }

            startNode.DijkstraDistance = 0;
            queue.Enqueue(startNode);

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                if (currentNode.DijkstraDistance == decimal.MaxValue)
                {
                    break;
                }

                foreach (var neighbour in this.Nodes[currentNode.Name].Connections)
                {
                    var subDistance = currentNode.DijkstraDistance + neighbour.Distance;

                    if (subDistance < neighbour.Target.DijkstraDistance)
                    {
                        neighbour.Target.DijkstraDistance = subDistance;
                        queue.Enqueue(neighbour.Target);
                    }
                }
            }
        }

        public void SetAllDijkstraDistanceValue(decimal value)
        {
            foreach (var node in this.Nodes)
            {
                node.Value.DijkstraDistance = value;
            }
        }

        public decimal GetSumOfAllDijkstraDistance()
        {
            foreach (var item in this.Nodes.Where(item => !this.visited.Contains(item.Value)))
            {
                this.RunDfs(item.Value);
            }

            return this.Nodes.Sum(node => node.Value.DijkstraDistance);
        }

        public void RunDfs(Node<T> node)
        {
            this.visited.Add(node);
            foreach (var item in node.Connections)
            {
                if (!this.visited.Contains(item.Target))
                {
                    this.RunDfs(item.Target);
                }

                node.DijkstraDistance += item.Target.DijkstraDistance;
            }

            if (node.DijkstraDistance == 0)
            {
                node.DijkstraDistance++;
            }
        }

        public void RunBfs(T nodeName)
        {
            var nodes = new Queue<Node<T>>();
            var node = this.Nodes[nodeName];
            nodes.Enqueue(node);
            while (nodes.Count != 0)
            {
                var currentNode = nodes.Dequeue();
                currentNode.DijkstraDistance++;

                foreach (var connection in this.Nodes[currentNode.Name].Connections)
                {
                    nodes.Enqueue(connection.Target);
                }
            }
        }

        public List<Edge<T>> PrimeMinimumSpanningTree(T startNodeName)
        {
            if (!this.Nodes.ContainsKey(startNodeName))
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("{0} is not contained in the graph.", startNodeName));
            }

            var minimumSpanningTree = new List<Edge<T>>();
            var queue = new PriorityQueue<Edge<T>>();
            var node = this.Nodes[startNodeName];

            foreach (var edge in node.Connections)
            {
                queue.Enqueue(edge);
            }

            this.visited.Add(node);

            while (queue.Count > 0)
            {
                var edge = queue.Dequeue();

                if (this.visited.Contains(edge.Target))
                {
                    continue;
                }

                node = edge.Target;
                this.visited.Add(node);
                minimumSpanningTree.Add(edge);

                foreach (var item in node.Connections)
                {
                    if (!minimumSpanningTree.Contains(item))
                    {
                        if (!this.visited.Contains(item.Target))
                        {
                            queue.Enqueue(item);
                        }
                    }
                }
            }

            this.visited.Clear();
            return minimumSpanningTree;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var node in this.Nodes)
            {
                result.Append(node.Key + " -> ");

                foreach (var conection in node.Value.Connections)
                {
                    result.Append(conection.Target + "-" + conection.Distance + " ");
                }

                result.AppendLine();
            }

            return result.ToString();
        }
    }
}