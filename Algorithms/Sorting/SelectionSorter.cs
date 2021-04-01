using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Sorting
{
    public class SelectionSorter : ISorter
    {
        public void Sort<T>(IList<T> collection) where T : IComparable<T>
        {
            if (collection.Count == 0 || collection.Count == 1)
            {
                return;
            }

            for (int i = 0; i < collection.Count -1; i++)
            {
                int minNumberIndex = i;

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[minNumberIndex].CompareTo(collection[j]) == 1)
                    {
                        minNumberIndex = j;
                    }
                }

                if (minNumberIndex != i)
                {
                    T temp = collection[minNumberIndex];
                    collection[minNumberIndex] = collection[i];
                    collection[i] = temp;
                }
            }
        }
    }
}
