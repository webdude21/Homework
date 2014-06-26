namespace ImplementLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class LinkedList<T> : IEnumerable<T>
    {
        public ListItem<T> FirstElement { get; private set; }

        public ListItem<T> LastElement { get; private set; }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index >= this.Count || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                var currentItem = this.FirstElement;

                for (var i = 0; i < index; i++)
                {
                    currentItem = currentItem.NextItem;
                }

                return currentItem.Value;
            }

            set
            {
                if (index >= this.Count || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                var currentItem = this.FirstElement;

                for (var i = 0; i < index; i++)
                {
                    currentItem = currentItem.NextItem;
                }

                currentItem.Value = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentItem = this.FirstElement;

            while (currentItem != null)
            {
                yield return currentItem.Value;
                currentItem = currentItem.NextItem;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void AddFirst(T item)
        {
            this.AddFirst(new ListItem<T>(item));
        }

        public void AddFirst(ListItem<T> item)
        {
            this.Count += 1;

            if (this.FirstElement == null)
            {
                this.FirstElement = item;
                this.LastElement = item;
            }
            else
            {
                item.NextItem = this.FirstElement;
                this.FirstElement = item;
            }
        }

        public void AddLast(T item)
        {
            this.AddLast(new ListItem<T>(item));
        }

        public void AddLast(ListItem<T> item)
        {
            if (this.Count == 0)
            {
                AddFirst(item);
                return;
            }

            this.Count += 1;
            this.LastElement.NextItem = item;
            item.PreviousItem = this.LastElement;
            this.LastElement = item;
        }

        public void RemoveFirst()
        {
            if (this.FirstElement == null)
            {
                return;
            }

            this.Count -= 1;
            this.FirstElement = this.FirstElement.NextItem;
        }

        public void RemoveLast()
        {
            if (this.LastElement == null)
            {
                this.RemoveFirst();
                return;
            }

            this.Count -= 1;
            this.LastElement = this.LastElement.PreviousItem;
        }

        public void Clear()
        {
            this.FirstElement = null;
            this.LastElement = null;
            this.Count = 0;
        }

        public bool Contains(T item)
        {
            return Enumerable.Contains(this, item);
        }

        public override string ToString()
        {
            var resultBuilder = new StringBuilder();
            foreach (var item in this)
            {
                resultBuilder.Append(item);
                resultBuilder.Append(" ");
            }

            return "[" + resultBuilder.ToString().TrimEnd() + "]";
        }
    }
}