using System;
using System.Collections;
using System.Collections.Generic;

namespace ImplementStack
{
    class StackAdt<T> : IEnumerable<T>
    {
        private T[] internalStorage;
        private const int InitialCapacity = 16;

        public StackAdt(int initialCapacity = InitialCapacity)
        {
            this.internalStorage = new T[initialCapacity];
        }
        public int CurrentCapacity
        {
            get { return internalStorage.Length; }
        }

        public int Count { get; private set; }

        public void Push(T item)
        {
            if (Count >= internalStorage.Length)
            {
                Grow();
            }

            internalStorage[Count] = item;
            Count++;
        }
        public T Pop()
        {
            var itemToPop = Peek();
            Count--;
            return itemToPop;
        }
        public T Peek()
        {
            if (Count > 0)
            {
                return internalStorage[Count - 1];
            }

            throw new InvalidOperationException("The stack is empty!");
        }
        private void Grow()
        {
            var index = 0;
            var newInternalStorage = new T[this.CurrentCapacity * 2];

            foreach (var item in this.internalStorage)
            {
                newInternalStorage[index] = item;
                index++;
            }

            this.internalStorage = newInternalStorage;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (var index = this.Count - 1; index >= 0; index--)
            {
                yield return internalStorage[index];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
