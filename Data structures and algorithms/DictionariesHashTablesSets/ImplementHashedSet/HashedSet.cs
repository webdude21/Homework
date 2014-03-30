using System.Collections;
using System.Collections.Generic;
using HashTableImplementation;

namespace ImplementHashedSet
{
    class HashedSet<T> : IEnumerable<T>
    {
        private HashTable<int, T> internalHashTable;
        private const int DefaultInitialCapacity = 16;
        public HashedSet(int initialCapacity = DefaultInitialCapacity)
        {
            this.internalHashTable = new HashTable<int, T>(initialCapacity);
        }
        public void Add(T item)
        {
            this.internalHashTable.Add(item.GetHashCode(), item);
        }
        public bool Find(T item)
        {
            return this.internalHashTable.Contains(item.GetHashCode());
        }
        public void Remove(T item)
        {
            this.internalHashTable.RemoveKey(item.GetHashCode());
        }
        public void Clear()
        {
            this.internalHashTable = new HashTable<int, T>();
        }
        public int Count { get { return this.internalHashTable.Count; } }
        public HashedSet<T> Union(HashedSet<T> other)
        {
            var newSet = new HashedSet<T>();

            foreach (var item in this)
            {
                newSet.Add(item);
            }

            foreach (var element in other)
            {
                newSet.Add(element);
            }

            return newSet;
        }
        public HashedSet<T> Intersect(HashedSet<T> other)
        {
            var newHashedSet = new HashedSet<T>();

            foreach (var item in this)
            {
                foreach (var otherItem in other)
                {
                    if (item.Equals(otherItem))
                    {
                        newHashedSet.Add(item);
                    }
                }
            }

            return newHashedSet;
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var keyValuePair in this.internalHashTable)
            {
                yield return keyValuePair.Value;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public override string ToString()
        {
            return string.Join(", ", this);
        }
    }
}
