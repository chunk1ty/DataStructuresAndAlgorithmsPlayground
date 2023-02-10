namespace Sorting
{
    public class QuickSorter : ISorter
    {
        public void Sort<T>(IList<T> collection) where T : IComparable<T>
        {
            if (collection.Count <= 1)
            {
                return;
            }

            IList<T> sortedCollection = _Sort(collection);

            collection.Clear();
            foreach (T item in sortedCollection)
            {
                collection.Add(item);
            }
        }

        private IList<T> _Sort<T>(IList<T> collection) where T : IComparable<T>
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            int pivotPosition = 0;
            T pivot = collection[pivotPosition];
            collection.RemoveAt(pivotPosition);

            IList<T> lesser = new List<T>();
            IList<T> greater = new List<T>();
            for (int i = 0; i < collection.Count; i++)
            {
                if (pivot.CompareTo(collection[i]) > 0)
                {
                    lesser.Add(collection[i]);
                }
                else
                {
                    greater.Add(collection[i]);
                }
            }

            lesser = _Sort(lesser);
            greater = _Sort(greater);

            List<T> result = new List<T>();
            result.AddRange(lesser);
            result.Add(pivot);
            result.AddRange(greater);

            return result;
        }
    }
}
