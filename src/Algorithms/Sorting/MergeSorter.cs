namespace Sorting
{
    public class MergeSorter : ISorter
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

        //Uses recursion to break the collection into progressively smaller collections.
        //Eventually, each collection will have just one element.
        private IList<T> _Sort<T>(IList<T> unsorted) where T : IComparable<T>
        {
            if (unsorted.Count <= 1)
            {
                return unsorted;
            }

            IList<T> left = new List<T>();
            IList<T> right = new List<T>();

            int middle = unsorted.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                left.Add(unsorted[i]);
            }

            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = _Sort(left);
            right = _Sort(right);

            return Merge(left, right);
        }

        // takes two sorted "sublists" (left and right) of original list and merges them into a new colletion
        private IList<T> Merge<T>(IList<T> left, IList<T> right) where T : IComparable<T>
        {
            IList<T> result = new List<T>();

            while (left.Any() || right.Any())
            {
                if (left.Any() && right.Any())
                {
                    if (left.First().CompareTo(right.First()) < 0)
                    {
                        result.Add(left.First());
                        left.Remove(left.First());
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Any())
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Any())
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }

            return result;
        }
    }
}
