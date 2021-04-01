using System;
using System.Collections.Generic;

namespace Algorithms.Sorting
{
    public class SortingPlaygrounder
    {
        public static void Play()
        {
            ISorter sorter = new InsertionSorter();
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

            for (int i = 1; i < maxNumbers; i++)
            {
                numbers.Add(random.Next(i, i + 100));
            }

            return numbers;
        }
    }
}
