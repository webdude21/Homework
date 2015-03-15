//  Write a generic class GenericList<T> that keeps a list of elements of some parametric type T. 
//  Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor. 
//  Implement methods for adding element, accessing element by index, removing element by index, inserting element at given position, 
//  clearing the list, finding element by its value and ToString(). Check all input parameters to avoid accessing elements at invalid positions.
//  Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.
//  Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the  GenericList<T>.
//  You may need to add a generic constraints for the type T.

namespace GenericList
{
    using System;
    using System.Text;

    internal class GenericList<T> where T : IComparable<T>
    {
        private uint capacity;

        private T[] content;

        public GenericList(uint initialCapacity = 1)
        {
            this.content = new T[initialCapacity];
            this.capacity = initialCapacity;
        }

        public uint Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return this.content[index];
            }
            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                this.content[index] = value;
            }
        }

        private T[] AutoGrow()
        {
            // this doubles the capacity of the array
            this.capacity = this.capacity * 2;
            var doubleSizeArr = new T[this.capacity];

            for (uint index = 0; index < this.Count; index++)
            {
                doubleSizeArr[index] = this.content[index];
            }

            return doubleSizeArr;
        }

        // This method adds adds a new element into the array (at the end)
        public void Add(T input)
        {
            this.GrowIfNeeded();
            this.content[this.Count] = input;
            this.Count++;
        }

        // This method checks if the list contains certain element
        public bool Contains(T input)
        {
            for (uint index = 0; index < this.Count; index++)
            {
                if (this.content[index].Equals(input))
                {
                    return true;
                }
            }
            return false;
        }

        // This method checks if the array needs to grow and if so it calls the AutoGrow method
        private void GrowIfNeeded()
        {
            if (this.Count + 1 > this.capacity)
            {
                this.content = this.AutoGrow();
            }
        }

        // This method allows the user to insert an element at a precise position
        public void InsertAt(uint positionToInsert, T input)
        {
            if (positionToInsert > this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            this.GrowIfNeeded();

            for (var i = this.Count; i > positionToInsert; i--)
            {
                this.content[i] = this.content[i - 1];
            }
            this.Count++;
            this.content[positionToInsert] = input;
        }

        // This method allows the user to remove an element at a precise position
        public void RemoveAt(uint elementToRemove)
        {
            if (elementToRemove >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            for (var i = elementToRemove; i < this.Count; i++)
            {
                this.content[i] = this.content[i + 1];
            }
            this.Count--;
        }

        // This method clears the array by giving each and every cell default 
        // value for the type that's used
        public void Clear()
        {
            for (uint index = 0; index < this.capacity; index++)
            {
                this.content[index] = default(T);
            }
            this.Count = 0;
        }

        public T Min()
        {
            var min = this.content[0];
            for (var index = 1; index < this.Count; index++)
            {
                if (min.CompareTo(this.content[index]) > 0)
                {
                    min = this.content[index];
                }
            }
            return min;
        }

        public T Max()
        {
            var max = this.content[0];
            for (var index = 1; index < this.Count; index++)
            {
                if (max.CompareTo(this.content[index]) < 0)
                {
                    max = this.content[index];
                }
            }
            return max;
        }

        // This is an override to the ToString() method to display the 
        // contents of the list in a more readable manner
        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var index = 0; index < this.Count; index++)
            {
                sb.Append(string.Format("[{0}]", this.content[index]));
            }
            return sb.ToString();
        }
    }
}