namespace AdvancedDataStructures
{
    using System;
    using System.Collections.Generic;

    internal class PriorityQueue<T> where T : IComparable<T>
    {
        private readonly List<T> elements = new List<T>();

        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        public void Clear()
        {
            this.elements.Clear();
        }

        public T Peek()
        {
            return this.elements[0];
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

        public void Update(T value)
        {
            var index = 0;

            for (var i = 0; i < this.elements.Count; i++)
            {
                if (this.elements[i].Equals(value))
                {
                    index = i;
                    break;
                }
            }
            
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
                if (this.HasRightDescendant(index) && this.LeftBiggerThanRight(index))
                {
                    smallerChild = RightIndex(index);
                }

                if (this.BiggerThanSmallerChild(index, smallerChild))
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


        private void SwapElements(int elementIndex, int otherElementIndex)
        {
            var previousElement = this.elements[elementIndex];
            this.elements[elementIndex] = this.elements[otherElementIndex];
            this.elements[otherElementIndex] = previousElement;
        }
    }
}