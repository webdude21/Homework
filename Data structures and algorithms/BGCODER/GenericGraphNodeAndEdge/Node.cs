namespace GenericGraphNodeAndEdge
{
    using System;
    using System.Collections.Generic;

    public class Node<T, TK>
    {
        private readonly IList<Edge<TK, T>> connections;

        public Node(T id)
        {
            this.Id = id;
            this.connections = new List<Edge<TK, T>>();
        }

        internal T Id { get; private set; }

        internal IEnumerable<Edge<TK, T>> Connections
        {
            get
            {
                return this.connections;
            }
        }

        internal void AddConnection(Node<T, TK> targetNode, TK weight, bool twoWay)
        {
            if (targetNode == null)
            {
                throw new ArgumentNullException("targetNode");
            }

            if (targetNode == this)
            {
                throw new ArgumentException("Node may not connect to itself.");
            }

            this.connections.Add(new Edge<TK, T>(targetNode, weight));
            if (twoWay)
            {
                targetNode.AddConnection(this, weight, false);
            }
        }
    }
}