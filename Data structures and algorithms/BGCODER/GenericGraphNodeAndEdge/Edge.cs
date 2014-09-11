namespace GenericGraphNodeAndEdge
{
    public class Edge<TK, T>
    {
        internal Edge(Node<T, TK> target, TK weight)
        {
            this.Target = target;
            this.Weight = weight;
        }

        internal Node<T, TK> Target { get; private set; }

        internal TK Weight { get; private set; }
    }
}