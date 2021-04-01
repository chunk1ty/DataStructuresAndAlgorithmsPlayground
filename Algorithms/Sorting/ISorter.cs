using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Sorting
{
    interface ISorter
    {
        void Sort<T>(IList<T> collection) where T : IComparable<T>;
    }
}
