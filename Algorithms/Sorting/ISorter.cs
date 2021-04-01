using System;
using System.Collections.Generic;

namespace Algorithms.Sorting
{
    interface ISorter
    {
        void Sort<T>(IList<T> collection) where T : IComparable<T>;
    }
}
