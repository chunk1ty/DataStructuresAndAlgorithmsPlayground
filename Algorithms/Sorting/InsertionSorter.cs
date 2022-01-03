using System;
using System.Collections.Generic;

namespace Algorithms.Sorting
{
    public class InsertionSorter : ISorter
    {
        public void Sort<T>(IList<T> collection) where T : IComparable<T>
        {
            if (collection.Count <= 1)
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

        //public void Sort<T>(IList<T> collection) where T : IComparable<T>
        //{
        //    for (int i = 0; i < collection.Count - 1; i++)
        //    {
        //        if (collection[i].CompareTo(collection[i + 1]) == 1)
        //        {
        //            T value = collection[i + 1];
        //            int index = i;

        //            //for (int j = i; j >= 0; j--)
        //            //{
        //            //    if (collection[j].CompareTo(value) == 1)
        //            //    {
        //            //        collection[j + 1] = collection[j];
        //            //        index = j;
        //            //    }
        //            //}

        //            while (index >= 0 && collection[index].CompareTo(value) == 1)
        //            {
        //                collection[index + 1] = collection[index];
        //                index--;
        //            }

        //            collection[index + 1] = value;
        //        }
        //    }
        //}
    }
}
