namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T>
        where T : IComparable<T>
    {
        private static readonly Random RandomGenerator = new Random();

        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            // it actually does linear search
            return this.items.Contains(item);
        }

        public bool BinarySearch(T item)
        {
            var left = 0;
            var right = this.items.Count;

            for (var currentIndex = left; currentIndex < right; currentIndex++)
            {
                var middle = (right + left) / 2;
                if (this.items[currentIndex].Equals(item))
                {
                    return true;
                }

                if (item.CompareTo(this.items[currentIndex]) > 0)
                {
                    left = middle;
                    currentIndex = middle;
                }
                else
                {
                    right = middle;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            for (var index = this.items.Count - 1; index > 0; index--)
            {
                this.SwapItems(index, RandomGenerator.Next(index + 1));
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (var i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }

        private void SwapItems(int firstItemIndex, int secondItemIndex)
        {
            var swapper = this.items[firstItemIndex];
            this.items[firstItemIndex] = this.items[secondItemIndex];
            this.items[secondItemIndex] = swapper;
        }
    }
}