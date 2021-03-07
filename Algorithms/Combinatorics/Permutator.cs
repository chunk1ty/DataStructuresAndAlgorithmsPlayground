using System;

namespace Algorithms.Combinatorics
{
    // https://stackoverflow.com/questions/756055/listing-all-permutations-of-a-string-integer
    public class Permutator
    {
        private static int _n; 
        
        public static void Permute(char[] items)
        {
            _n = items.Length;
            _Permute(0, items);
        }

        private static void _Permute(int currentIndex, char[] items)
        {
            if (currentIndex == _n)
            {
                Console.WriteLine(string.Join(" ", items));
                return;
            }

            for (int index = currentIndex; index < _n; index++)
            {
                Swap(ref items[currentIndex], ref items[index]);
                
                _Permute(currentIndex + 1, items);
                
                Swap(ref items[currentIndex], ref items[index]);
            }
        }

        private static void Swap(ref char a, ref char b)
        {
            char temp = a;
            a = b;
            b = temp;
        }
    }
}