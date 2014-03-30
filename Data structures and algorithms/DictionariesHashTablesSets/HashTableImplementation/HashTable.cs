using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HashTableImplementation
{
    public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        private LinkedList<KeyValuePair<K, T>>[] internalStore;
        private const int DefaultInitialCapacity = 16;
        private const double MaxLoadBeforeGrow = 0.75;
        private const int HashMagicNumber = 2147483647;
        private int tableLoad;
        private const string CapacityZeroOrNegativeErrorMessage = "Initial HashTable size can not be less than or equal to 0!";

        public int Count { get; private set; }
        public HashTable(int initialCapacity = DefaultInitialCapacity)
        {
            if (initialCapacity <= 0)
            {
                throw new ArgumentException(CapacityZeroOrNegativeErrorMessage);
            }
            this.internalStore = new LinkedList<KeyValuePair<K, T>>[initialCapacity];
            this.Capacity = initialCapacity;
        }
        public int Capacity { get; private set; }
        public void Add(K key, T value)
        {
            this[key] = value;
        }
        public void RemoveKey(K key)
        {
            this.internalStore[GetHashIndex(key)].RemoveFirst();
        }
        private void OcuppyNewCellIfNeeded(K key)
        {
            if (internalStore[GetHashIndex(key)] == null)
            {
                tableLoad++;
                ExpandIfNeeded();
                internalStore[GetHashIndex(key)] = new LinkedList<KeyValuePair<K, T>>();
            }
        }
        public T Find(K key)
        {
            return this[key];
        }
        public bool Contains(K key)
        {
            return this.internalStore[this.GetHashIndex(key)] != null &&
                this.internalStore[this.GetHashIndex(key)].Any(keyValuePair => keyValuePair.Key.Equals(key));
        }
        public T this[K key]
        {
            get { return this.internalStore[GetHashIndex(key)].First(item => item.Key.Equals(key)).Value; }

            set
            {
                OcuppyNewCellIfNeeded(key);
                this.Count += 1;
                internalStore[GetHashIndex(key)].AddLast(new KeyValuePair<K, T>(key, value));
            }
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
            return GetEnumerator();
        }
    }
}
