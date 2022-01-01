using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
    public class SortingPlaygrounder
    {
        public static void Play()
        {
            ISorter sorter = new Mergesort();
            List<int> numbers = GenerateRandomNumbers(10);
            Console.WriteLine(string.Join(' ', numbers));

            sorter.Sort(numbers);
            Console.WriteLine("#######################################");
            Console.WriteLine(string.Join(' ', numbers));
        }

        private static List<int> GenerateRandomNumbers(int maxNumbers)
        {
            var numbers = new List<int>();
            Random random = new Random();

            for (int i = 0; i < maxNumbers; i++)
            {
                numbers.Add(random.Next(i, i + 100));
            }

            return numbers;
        }
    }

    public class Mergesort : ISorter
    {
        public void Sort<T>(IList<T> collection) where T : IComparable<T>
        {
            if (collection.Count <= 1)
            {
                return;
            }

            IList<T> sortedCollection = Merge(collection);

            collection.Clear();
            foreach (var item in sortedCollection)
            {
                collection.Add(item);
            }

        }

        private IList<T> Merge<T>(IList<T> collection) where T : IComparable<T>
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            IList<T> left = new List<T>();
            IList<T> right = new List<T>();

            int middle = collection.Count / 2;
            for (int i = 0; i < middle; i++)
            {
                left.Add(collection[i]);
            }

            for (int i = middle; i < collection.Count; i++)
            {
                right.Add(collection[i]);
            }

            left = Merge<T>(left);
            right = Merge<T>(right);


            return _Merge(left, right);
        }


        private IList<T> _Merge<T>(IList<T> left, IList<T> right) where T : IComparable<T>
        {
            IList<T> result = new List<T>();

            while (left.Any() || right.Any())
            {
                if (left.Any() && right.Any())
                {
                    if (left.First().CompareTo(right.First()) <= 0)
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
                else if(right.Any())
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }

            return result;
        }
    }
}
