using System;

namespace Algorithms.Combinatorics
{
    // https://stackoverflow.com/questions/756055/listing-all-permutations-of-a-string-integer
    public class Permutator
    {
        public static void Permute(char[] items)
        {
            _Permute(items, 0);
        }

        static void _Permute(char[] items, int currentIndex)
        {
            int itemSize = items.Length;
            if (currentIndex == itemSize)
            {
                Console.WriteLine(string.Join(" ", items));
                return;
            }

            for (int index = currentIndex; index < itemSize; index++)
            {
                Swap(ref items[currentIndex], ref items[index]);
                _Permute(items, currentIndex + 1);
                Swap(ref items[currentIndex], ref items[index]);
            }
        }

        static void Swap(ref char a, ref char b)
        {
            char temp = a;
            a = b;
            b = temp;
        }
    }
}