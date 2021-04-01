using System;
using System.Collections.Generic;

namespace Algorithms.Sorting
{
    public class InsertionSorter : ISorter
    {
        public void Sort<T>(IList<T> collection) where T : IComparable<T>
        {
            if (collection.Count == 0 || collection.Count == 1)
            {
                return;
            }

            for (int i = 1; i < collection.Count; i++)
            {
                T currentValue = collection[i];
                int index = i - 1;

                while (index >= 0 && currentValue.CompareTo(collection[index]) <= 0)
                {
                    collection[index + 1] = collection[index];
                    index--;
                }

                collection[index + 1] = currentValue;
            }
        }
    }
}
