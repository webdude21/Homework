namespace TreeTraversal
{
    using System.Collections.Generic;

    internal class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
            this.Offspring = new List<Node<T>>();
        }

        public T Value { get; set; }

        public Node<T> Parent { get; set; }

        public IList<Node<T>> Offspring { get; set; }

        public bool HasParent
        {
            get
            {
                return this.Parent != null;
            }
        }

        public bool HasChildren
        {
            get
            {
                return this.Offspring.Count > 0;
            }
        }

        public void AddChild(Node<T> childNode)
        {
            this.Offspring.Add(childNode);
        }

        public void AddPerent(Node<T> parentNode)
        {
            this.Parent = parentNode;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}