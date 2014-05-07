﻿using System;
using System.Collections.Generic;

namespace AdvancedDataStructures
{
    class PriorityQueue<T> where T : IComparable<T>
    {
        private readonly List<T> elements = new List<T>();

        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        public T Peek()
        {
            return this.elements[0];
        }

        private void SwapElements(int elementIndex, int otherElementIndex)
        {
            var previousElement = this.elements[elementIndex];
            this.elements[elementIndex] = this.elements[otherElementIndex];
            this.elements[otherElementIndex] = previousElement;
        }

        public void Enqueue(T value)
        {
            this.elements.Add(value);
            var index = this.Count - 1;
            var correctOrder = false;

            while (HasParent(index) && !correctOrder)
            {
                if (this.elements[ParentIndex(index)].CompareTo(this.elements[index]) > 0)
                {
                    this.SwapElements(index, ParentIndex(index));
                    index = ParentIndex(index);
                }
                else
                {
                    correctOrder = true;
                }
            }
        }

        public T Dequeue()
        {
            var result = this.Peek();

            this.elements[0] = this.elements[this.Count - 1];
            this.elements.RemoveAt(this.Count - 1);
            var index = 0;
            var correctOrder = false;

            while (this.HasLeftDescendant(index) && !correctOrder)
            {
                var smallerChild = LeftIndex(index);
                if (this.HasRightDescendant(index) && LeftBiggerThanRight(index) )
                {
                    smallerChild = RightIndex(index);
                }

                if (BiggerThanSmallerChild(index, smallerChild))
                {
                    this.SwapElements(index, smallerChild);
                }
                else
                {
                    correctOrder = true;
                }
                index = smallerChild;
            }

            return result;
        }

        private bool BiggerThanSmallerChild(int index, int smallerChild)
        {
            return this.elements[index].CompareTo(this.elements[smallerChild]) > 0;
        }

        private bool LeftBiggerThanRight(int index)
        {
            return this.elements[LeftIndex(index)].CompareTo(this.elements[RightIndex(index)]) > 0;
        }

        private static bool HasParent(int index)
        {
            return index > 0;
        }

        private static int ParentIndex(int currentIndex)
        {
            return (currentIndex - 1) / 2;
        }

        private static int LeftIndex(int currentIndex)
        {
            return (currentIndex * 2) + 1;
        }

        private static int RightIndex(int currentIndex)
        {
            return (currentIndex * 2) + 2;
        }

        private bool HasLeftDescendant(int currentIndex)
        {
            return LeftIndex(currentIndex) < this.Count;
        }

        private bool HasRightDescendant(int currentIndex)
        {
            return RightIndex(currentIndex) < this.Count;
        }

        public void Clear()
        {
            this.elements.Clear();
        }
    }
}
