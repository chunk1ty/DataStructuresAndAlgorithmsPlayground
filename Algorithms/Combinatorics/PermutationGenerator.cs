using System;

namespace Algorithms.Combinatorics
{
    public class PermutationGenerator
    {
        public static void Generate(int size)
        {
            var permutation = new int[size];
            var used = new bool[size];

            _Generate(0, permutation, used);
        }

        private static void _Generate(int currentNumber, int[] permutation, bool[] used)
        {
            int size = permutation.Length;
            if (currentNumber == size)
            {
                Console.WriteLine(string.Join(" ", permutation));
                return;
            }

            for (int index = 0; index < size; index++)
            {
                if (used[index])
                {
                    continue;
                }

                permutation[currentNumber] = index + 1;
                used[index] = true;
                _Generate(currentNumber + 1, permutation, used);
                used[index] = false;
            }
        }
    }
}