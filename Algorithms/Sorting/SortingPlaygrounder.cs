using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Sorting
{
    public class SortingPlaygrounder
    {
        public static void Play()
        {
            ISorter sorter = new SelectionSorter();
            List<int> numbers = GenerateRandomNumbers(100);
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
                numbers.Add(random.Next(i, i * 3));
            }

            return numbers;
        }
    }
}
