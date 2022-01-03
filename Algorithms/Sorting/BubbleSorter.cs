using System;
using System.Collections.Generic;

namespace Algorithms.Sorting
{
    public class BubbleSorter : ISorter
    {
        public void Sort<T>(IList<T> collection) where T : IComparable<T>
        {
            if (collection.Count <= 1)
            {
                return;
            }

            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[i].CompareTo(collection[j]) == 1)
                    {
                        T temp = collection[i];
                        collection[i] = collection[j];
                        collection[j] = temp;
                    }
                }
            }
        }
    }
}
