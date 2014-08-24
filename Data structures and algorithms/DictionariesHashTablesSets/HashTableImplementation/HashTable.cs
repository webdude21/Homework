namespace HashTableImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        private const int DefaultInitialCapacity = 16;

        private const double MaxLoadBeforeGrow = 0.75;

        private const int HashMagicNumber = 2147483647;

        private const string CapacityZeroOrNegativeErrorMessage =
            "Initial HashTable size can not be less than or equal to 0!";

        private LinkedList<KeyValuePair<K, T>>[] internalStore;

        private int tableLoad;

        public HashTable(int initialCapacity = DefaultInitialCapacity)
        {
            if (initialCapacity <= 0)
            {
                throw new ArgumentException(CapacityZeroOrNegativeErrorMessage);
            }

            this.internalStore = new LinkedList<KeyValuePair<K, T>>[initialCapacity];
            this.Capacity = initialCapacity;
        }

        public int Count { get; private set; }

        public int Capacity { get; private set; }

        public T this[K key]
        {
            get
            {
                return this.internalStore[this.GetHashIndex(key)].First(item => item.Key.Equals(key)).Value;
            }

            set
            {
                this.OcuppyNewCellIfNeeded(key);
                this.Count += 1;
                this.internalStore[this.GetHashIndex(key)].AddLast(new KeyValuePair<K, T>(key, value));
            }
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            foreach (var linkedListItem in this.internalStore)
            {
                if (linkedListItem != null)
                {
                    foreach (var keyValuePair in linkedListItem)
                    {
                        yield return keyValuePair;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(K key, T value)
        {
            this[key] = value;
        }

        public void RemoveKey(K key)
        {
            this.internalStore[this.GetHashIndex(key)].RemoveFirst();
        }

        private void OcuppyNewCellIfNeeded(K key)
        {
            if (this.internalStore[this.GetHashIndex(key)] == null)
            {
                this.tableLoad++;
                this.ExpandIfNeeded();
                this.internalStore[this.GetHashIndex(key)] = new LinkedList<KeyValuePair<K, T>>();
            }
        }

        public T Find(K key)
        {
            return this[key];
        }

        public bool Contains(K key)
        {
            return this.internalStore[this.GetHashIndex(key)] != null
                   && this.internalStore[this.GetHashIndex(key)].Any(keyValuePair => keyValuePair.Key.Equals(key));
        }

        public int GetHashIndex(K key)
        {
            return (key.GetHashCode() & HashMagicNumber) % this.Capacity;
        }

        private void ExpandIfNeeded()
        {
            if (this.tableLoad > this.Capacity * MaxLoadBeforeGrow)
            {
                var newHash = new HashTable<K, T>(this.Capacity * 2);

                foreach (var keyValuePair in this)
                {
                    newHash.Add(keyValuePair.Key, keyValuePair.Value);
                }

                this.internalStore = newHash.internalStore;
                this.Capacity = newHash.Capacity;
                this.Count = newHash.Count;
                this.tableLoad = newHash.tableLoad;
            }
        }
    }
}