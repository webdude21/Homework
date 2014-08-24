namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (var i = 0; i < collection.Count - 1; i++)
            {
                for (var j = i + 1; j < collection.Count; j++)
                {
                    if (collection[i].CompareTo(collection[j]) > 0)
                    {
                        var currentItem = collection[i];
                        collection[i] = collection[j];
                        collection[j] = currentItem;
                    }
                }
            }
        }
    }
}