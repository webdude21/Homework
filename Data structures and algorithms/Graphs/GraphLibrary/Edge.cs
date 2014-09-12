namespace GraphLibrary
{
    using System;

    public class Edge<T> : IComparable<Edge<T>>
    {
        public Edge(Node<T> begining, Node<T> target, decimal distance)
        {
            this.Source = begining;
            this.Target = target;
            this.Distance = distance;
        }

        public Node<T> Source { get; private set; }

        public Node<T> Target { get; private set; }

        public decimal Distance { get; private set; }

        public int CompareTo(Edge<T> other)
        {
            return this.Distance.CompareTo(other.Distance);
        }

        public int CompareTo(object obj)
        {
            var edge = obj as Edge<T>;
            if (edge != null)
            {
                return this.CompareTo(edge);
            }

            throw new NullReferenceException();
        }

        public override string ToString()
        {
            return string.Format("({0} {1}) -> {2}", this.Source, this.Target, this.Distance);
        }
    }
}