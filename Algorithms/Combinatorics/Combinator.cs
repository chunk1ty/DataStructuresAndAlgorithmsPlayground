using System;

namespace Algorithms.Combinatorics
{
    public class Combinator
    {
        private static char[] _items;
        private static int _n;
        private static int _p = 2;

        private  static int[] _combinationIndexes;
        
        public static void Combinate(char[] items, int p)
        {
            _combinationIndexes = new int[p];
            _n = items.Length;
            _items = items;
            _p = p;
            GenerateCombinationsNoRepetitions(0, 0);
        }

        private static void GenerateCombinationsNoRepetitions(int index, int start)
        {
            if (index >= _p)
            {
                foreach (var combinationIndex in _combinationIndexes)
                {
                    Console.Write(_items[combinationIndex] + " ");
                }

                Console.WriteLine(" ");
                return;
            }

            for (int i = start; i < _n; i++)
            {
                _combinationIndexes[index] = i;
                GenerateCombinationsNoRepetitions(index + 1, i + 1);
            }
        }
    }
}