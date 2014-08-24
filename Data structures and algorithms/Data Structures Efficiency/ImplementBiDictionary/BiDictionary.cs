namespace ImplementBiDictionary
{
    using System;
    using System.Collections.Generic;

    using Wintellect.PowerCollections;

    public class BiDictionary<K1, K2, T>
    {
        private readonly MultiDictionary<K1, T> firstKeyStorage;

        private readonly MultiDictionary<K2, T> secondKeyStorage;

        private readonly MultiDictionary<DoubleKey<K1, K2>, T> twoKeyStorage;

        public BiDictionary(bool allowDuplicateValues)
        {
            this.firstKeyStorage = new MultiDictionary<K1, T>(allowDuplicateValues);
            this.twoKeyStorage = new MultiDictionary<DoubleKey<K1, K2>, T>(allowDuplicateValues);
            this.secondKeyStorage = new MultiDictionary<K2, T>(allowDuplicateValues);
        }

        public void Add(K1 firstKey, K2 secondKey, T value)
        {
            this.twoKeyStorage.Add(new DoubleKey<K1, K2>(firstKey, secondKey), value);
            this.firstKeyStorage.Add(firstKey, value);
            this.secondKeyStorage.Add(secondKey, value);
        }

        public void Remove(K1 firstKey, K2 secondKey, T value)
        {
            this.twoKeyStorage.Remove(new DoubleKey<K1, K2>(firstKey, secondKey), value);
            this.firstKeyStorage.Remove(firstKey, value);
            this.secondKeyStorage.Remove(secondKey, value);
        }

        public bool ContainsByFirstKey(K1 key)
        {
            return this.firstKeyStorage.ContainsKey(key);
        }

        public bool ContainsBySecondKey(K2 key)
        {
            return this.secondKeyStorage.ContainsKey(key);
        }

        public bool ContainsByBothKeys(K1 firstKey, K2 secondKey)
        {
            return this.twoKeyStorage.ContainsKey(new DoubleKey<K1, K2>(firstKey, secondKey));
        }

        public ICollection<T> GetValueByBothKeys(K1 firstKey, K2 secondKey)
        {
            var keys = new DoubleKey<K1, K2>(firstKey, secondKey);
            if (this.ContainsByBothKeys(firstKey, secondKey))
            {
                return this.twoKeyStorage[keys];
            }

            throw new ArgumentException("There's no such key in the Dictionary!");
        }

        public ICollection<T> GetValueByFirstKey(K1 firstKey)
        {
            if (this.ContainsByFirstKey(firstKey))
            {
                return this.firstKeyStorage[firstKey];
            }

            throw new ArgumentException("There's no such key in the Dictionary!");
        }

        public ICollection<T> GetValueBySecondKey(K2 secondKey)
        {
            if (this.ContainsBySecondKey(secondKey))
            {
                return this.secondKeyStorage[secondKey];
            }

            throw new ArgumentException("There's no such key in the Dictionary!");
        }

        internal class DoubleKey<TK1, TK2> : IEquatable<T>
        {
            internal DoubleKey(TK1 firstKey, TK2 secondkey)
            {
                this.FirstKey = firstKey;
                this.Secondkey = secondkey;
            }

            internal TK1 FirstKey { get; private set; }

            internal TK2 Secondkey { get; private set; }

            public bool Equals(T otherObj)
            {
                var other = otherObj as DoubleKey<TK1, TK2>;
                return other != null && (this.FirstKey.Equals(other.FirstKey) && this.Secondkey.Equals(other.Secondkey));
            }

            public override int GetHashCode()
            {
                var hash = Math.Abs(this.FirstKey.GetHashCode() + this.Secondkey.GetHashCode());
                return hash;
            }

            public override bool Equals(object obj)
            {
                var other = obj as DoubleKey<TK1, TK2>;
                return other != null && (this.FirstKey.Equals(other.FirstKey) && this.Secondkey.Equals(other.Secondkey));
            }
        }
    }
}