namespace ImplementStack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    internal class StackAdt<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 16;

        private T[] internalStorage;

        public StackAdt(int initialCapacity = InitialCapacity)
        {
            this.internalStorage = new T[initialCapacity];
        }

        public int CurrentCapacity
        {
            get
            {
                return this.internalStorage.Length;
            }
        }

        public int Count { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            for (var index = this.Count - 1; index >= 0; index--)
            {
                yield return this.internalStorage[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Push(T item)
        {
            if (this.Count >= this.internalStorage.Length)
            {
                this.Grow();
            }

            this.internalStorage[this.Count] = item;
            this.Count++;
        }

        public T Pop()
        {
            var itemToPop = this.Peek();
            this.Count--;
            return itemToPop;
        }

        public T Peek()
        {
            if (this.Count > 0)
            {
                return this.internalStorage[this.Count - 1];
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
    }
}