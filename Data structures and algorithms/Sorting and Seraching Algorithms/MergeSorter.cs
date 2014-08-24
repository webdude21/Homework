namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class MergeSorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var resultColection = SplitMerge(collection);
            for (var i = 0; i < collection.Count; i++)
            {
                collection[i] = resultColection[i];
            }
        }

        private static IList<T> SplitMerge(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            var middle = collection.Count / 2;
            IList<T> left = new T[middle];
            IList<T> right = new T[collection.Count - middle];

            for (var i = 0; i < middle; i++)
            {
                left[i] = collection[i];
            }

            for (var i = middle; i < collection.Count; i++)
            {
                right[i - middle] = collection[i];
            }

            left = SplitMerge(left);
            right = SplitMerge(right);

            return Merge(left, right);
        }

        private static IList<T> Merge(IList<T> left, IList<T> right)
        {
            IList<T> result = new List<T>();
            var leftIndex = 0;
            var rightIndex = 0;

            while (leftIndex < left.Count || rightIndex < right.Count)
            {
                if (leftIndex < left.Count && rightIndex < right.Count)
                {
                    if (left[leftIndex].CompareTo(right[rightIndex]) <= 0)
                    {
                        result.Add(left[leftIndex]);
                        leftIndex++;
                    }
                    else
                    {
                        result.Add(right[rightIndex]);
                        rightIndex++;
                    }
                }
                else if (leftIndex < left.Count)
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else if (rightIndex < right.Count)
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            return result;
        }
    }
}