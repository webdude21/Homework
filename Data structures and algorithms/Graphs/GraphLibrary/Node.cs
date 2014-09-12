namespace GraphLibrary
{
    using System;
    using System.Collections.Generic;

    public class Node<T> : IComparable<Node<T>>
    {
        private readonly IList<Edge<T>> connections;

        public Node(T name)
        {
            this.Name = name;
            this.connections = new List<Edge<T>>();
        }

        public T Name { get; private set; }

        public decimal DijkstraDistance { get; set; }

        public List<Node<T>> DijkstraPath { get; set; }

        internal IEnumerable<Edge<T>> Connections
        {
            get
            {
                return this.connections;
            }
        }

        public int CompareTo(Node<T> other)
        {
            return this.DijkstraDistance.CompareTo(other.DijkstraDistance);
        }

        public override string ToString()
        {
            return this.Name.ToString();
        }

        public int CompareTo(object obj)
        {
            var node = obj as Node<T>;
            if (node != null)
            {
                return this.CompareTo(node);
            }

            throw new NullReferenceException();
        }

        internal void AddConnection(Node<T> targetNode, decimal distance, bool twoWay)
        {
            if (targetNode == null)
            {
                throw new ArgumentNullException("targetNode");
            }

            if (targetNode == this)
            {
                throw new ArgumentException("Node may not connect to itself.");
            }

            if (distance < 0)
            {
                throw new ArgumentException("Distance must be positive.");
            }

            this.connections.Add(new Edge<T>(this, targetNode, distance));
            if (twoWay)
            {
                targetNode.AddConnection(this, distance, false);
            }
        }
    }
}