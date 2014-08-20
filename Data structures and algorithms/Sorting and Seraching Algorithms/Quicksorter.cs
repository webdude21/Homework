namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Quicksorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var sorted = QuickSort(collection);
            collection.Clear();
            foreach (var element in sorted)
            {
                collection.Add(element);
            }
        }

        private static IEnumerable<T> QuickSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            var pivotIndex = GetPivotIndex(collection);
            var pivot = collection[pivotIndex];
            collection.RemoveAt(pivotIndex);
            IList<T> smallerThanPivot = new List<T>();
            IList<T> greaterThanPivot = new List<T>();

            foreach (var element in collection)
            {
                if (element.CompareTo(pivot) <= 0)
                {
                    smallerThanPivot.Add(element);
                }
                else
                {
                    greaterThanPivot.Add(element);
                }
            }

            return Combine(QuickSort(smallerThanPivot), pivot, QuickSort(greaterThanPivot));
        }

        private static IEnumerable<T> Combine(IEnumerable<T> smallerThanPivot, T pivot, IEnumerable<T> greaterThanPivot)
        {
            IList<T> result = smallerThanPivot.ToList();
            result.Add(pivot);

            foreach (var element in greaterThanPivot)
            {
                result.Add(element);
            }

            return result;
        }

        private static int GetPivotIndex(IList<T> collection)
        {
            const int MedianCandidatesCount = 3;

            if (collection.Count <= MedianCandidatesCount)
            {
                return collection.Count - 1;
            }

            int swap;
            var leftIndex = 0;
            var middleIndex = (collection.Count - 1) / 2;
            var rightIndex = collection.Count - 1;

            if (collection[leftIndex].CompareTo(collection[rightIndex]) > 0)
            {
                swap = rightIndex;
                rightIndex = leftIndex;
                leftIndex = swap;
            }

            if (collection[leftIndex].CompareTo(collection[middleIndex]) > 0)
            {
                middleIndex = leftIndex;
            }

            if (collection[middleIndex].CompareTo(collection[rightIndex]) <= 0)
            {
                return middleIndex;
            }

            swap = rightIndex;
            middleIndex = swap;

            return middleIndex;
        }
    }
}