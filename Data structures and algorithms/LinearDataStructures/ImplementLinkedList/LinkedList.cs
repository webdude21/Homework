namespace ImplementLinkedList
{
    public class LinkedList<T>
    {
        public ListItem<T> FirstElement { get; private set; }
        public ListItem<T> LastElement { get; private set; }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            this.Count += 1;
            if (this.FirstElement != null)
            {
                
            }
            AddFirst(new ListItem<T>(item));
        }

        public void AddFirst(ListItem<T> item)
        {
            item.NextItem = this.FirstElement;
            this.FirstElement = item;
        }

        public void AddLast(T item)
        {
            AddLast(new ListItem<T>(item));
        }

        public void AddLast(ListItem<T> item)
        {
            item.NextItem = this.FirstElement;
            this.FirstElement = item;
        }

    }
}
