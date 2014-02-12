//  Write a generic class GenericList<T> that keeps a list of elements of some parametric type T. 
//  Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor. 
//  Implement methods for adding element, accessing element by index, removing element by index, inserting element at given position, 
//  clearing the list, finding element by its value and ToString(). Check all input parameters to avoid accessing elements at invalid positions.
//  Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.
//  Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the  GenericList<T>.
//  You may need to add a generic constraints for the type T.

using System;
using System.Collections.Generic;
using System.Text;

namespace GenericList
{
    class GenericList<T> where T : IComparable<T>
    {
        private T[] content;
        private uint count;
        private uint capacity;

        public GenericList(uint initialCapacity = 1)
        {
            // Constructor
            this.content = new T[initialCapacity];
            this.capacity = initialCapacity;
        }

        public uint Count
        {
            // This field holds the count of the actually accessible slots in the array
            get
            {
                return this.count;
            }
        }

        public T this[int index]
        {
            // if the user tries to access slots that are reserved, but not 
            // currently used an exception is thrown
            get
            {
                if (index < 0 || index >= this.count)
                {
                    throw new IndexOutOfRangeException();
                }
                return this.content[index];
            }
            set
            {
                if (index < 0 || index >= this.count)
                {
                    throw new IndexOutOfRangeException();
                }
                this.content[index] = value;
            }
        }

        private T[] AutoGrow()
        {
            // this doubles the capacity of the array
            this.capacity = capacity * 2;
            T[] doubleSizeArr = new T[this.capacity];

            for (uint index = 0; index < this.Count; index++)
            {
                doubleSizeArr[index] = content[index];
            }

            return doubleSizeArr;
        }

        public void Add(T input)
        {
            // This method adds adds a new element into the array (at the end)
            GrowIfNeeded();
            this.content[count] = input;
            this.count++;
        }

        public bool Contains(T input)
        {
            // This method checks if the list contains certain element
            for (uint index = 0; index < this.count; index++)
            {
                if (this.content[index].Equals(input))
                {
                    return true;
                }
            }
            return false;
        }

        private void GrowIfNeeded()
        {
            // This method checks if the array needs to grow and if so it calls the AutoGrow method
            if (this.Count + 1 > this.capacity)
            {
                this.content = AutoGrow();
            }
        }

        public void InsertAt(uint positionToInsert, T input)
        {
            // This method allows the user to insert an element at a precise position
            if (positionToInsert > this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            GrowIfNeeded();

            for (uint i = this.count; i > positionToInsert; i--)
            {
                this.content[i] = this.content[i - 1];
            }
            this.count++;
            this.content[positionToInsert] = input;
        }

        public void RemoveAt(uint elementToRemove)
        {
            // This method allows the user to remove an element at a precise position
            if (elementToRemove >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            for (uint i = elementToRemove; i < this.Count; i++)
            {
                this.content[i] = this.content[i + 1];
            }
            this.count--;
        }

        public void Clear()
        {
            // This method clears the array by giving each and every cell default 
            // value for the type that's used 
            for (uint index = 0; index < this.capacity; index++)
            {
                this.content[index] = default(T);
            }
            this.count = 0;
        }

        public T Min()
        {
            T min = this.content[0];
            for (int index = 1; index < this.count; index++)
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
            T max = this.content[0];
            for (int index = 1; index < this.count; index++)
            {
                if (max.CompareTo(this.content[index]) < 0)
                {
                    max = this.content[index];
                }
            }
            return max;
        }

        public override string ToString()
        {
            // This is an override to the ToString() method to display the 
            // contents of the list in a more readable manner
            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < this.Count; index++)
            {
                sb.Append(string.Format("[{0}]", this.content[index]));
            }
            return sb.ToString();
        }
    }
}
