namespace Combinatorics
{
    // How many words of 2 letters can you make with 4 letters? 
    public class Variator
    {
        private static int _n;
        private static int _p;
        private static char[] _items;
        
        private static int[] _variationIndexes;
        private static bool[] _used;
        
        public static void Variate(char[] items, int p)
        {
            _items = items;
            _n = _items.Length;
            _p = p;
            
            _variationIndexes = new int[_p];
            _used = new bool[_n];
            
            VariationsWithoutRepetitions(0);
        }

        private static void VariationsWithoutRepetitions(int index)
        {
            if (index == _p)
            {
                foreach (var variationIndex in _variationIndexes)
                {
                    Console.Write(_items[variationIndex] + " ");
                }
                Console.WriteLine(" ");
                return;
            }

            for (int i = 0; i < _n; i++)
            {
                if (_used[i])
                {
                    continue;
                }
                
                _used[i] = true;
                _variationIndexes[index] = i;
                
                VariationsWithoutRepetitions(index + 1);
                
                _used[i] = false;
            }
        }
    }
}