namespace ImplementQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    internal class LinkedQueue<T> : IEnumerable<T>
    {
        private readonly LinkedList<T> internalList = new LinkedList<T>();

        public int Count
        {
            get
            {
                return this.internalList.Count;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.internalList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this.internalList).GetEnumerator();
        }

        public void Enqueue(T item)
        {
            this.internalList.AddLast(item);
        }

        public T Peek()
        {
            if (this.internalList.Count == 0)
            {
                throw new ArgumentException("The queue is empty!");
            }

            return this.internalList.First.Value;
        }

        public T Dequeue()
        {
            var itemToReturn = this.Peek();
            this.internalList.RemoveFirst();
            return itemToReturn;
        }
    }
}