using System;
using System.Collections;
using System.Collections.Generic;

namespace ImplementQueue
{
    class LinkedQueue<T> : IEnumerable<T>
    {
        readonly LinkedList<T> internalList = new LinkedList<T>();
        public int Count
        {
            get { return internalList.Count; }
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
        public IEnumerator<T> GetEnumerator()
        {
            return internalList.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) internalList).GetEnumerator();
        }
    }
}
