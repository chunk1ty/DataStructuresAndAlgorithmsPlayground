using System;
using System.Collections.Generic;

namespace Algorithms.Sorting
{
    public class SelectionSorter : ISorter
    {
        public void Sort<T>(IList<T> collection) where T : IComparable<T>
        {
            if (collection.Count <= 1)
            {
                return;
            }

            for (int i = 0; i < collection.Count - 1; i++)
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

        //public void Sort<T>(IList<T> collection) where T : IComparable<T>
        //{
        //    for (int i = 0; i < collection.Count - 1; i++)
        //    {
        //        bool isSmaller = false;
        //        int minElementIndex = i;

        //        for (int j = i; j < collection.Count; j++)
        //        {
        //            if (collection[minElementIndex].CompareTo(collection[j]) > 0)
        //            {
        //                isSmaller = true;
        //                minElementIndex = j;
        //            }
        //        }

        //        if (isSmaller)
        //        {
        //            var temp = collection[i];
        //            collection[i] = collection[minElementIndex];
        //            collection[minElementIndex] = temp;
        //        }
        //    }
        //}
    }
}
