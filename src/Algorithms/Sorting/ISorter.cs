namespace Sorting
{
    interface ISorter
    {
        void Sort<T>(IList<T> collection) where T : IComparable<T>;
    }
}
