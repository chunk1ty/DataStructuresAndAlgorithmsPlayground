namespace Combinatorics
{
    // https://stackoverflow.com/questions/756055/listing-all-permutations-of-a-string-integer
    // How many ways are there to arrange 3 letters?
    public class Permutator
    {
        private static int _n; 
        
        public static void Permute(char[] items)
        {
            _n = items.Length;
            PermutationWithoutRepetitions(0, items);
        }

        private static void PermutationWithoutRepetitions(int currentIndex, char[] items)
        {
            Console.WriteLine("Items: " + string.Join(" ", items));
            
            if (currentIndex == _n)
            {
                Console.WriteLine("Result: " + string.Join(" ", items));
                return;
            }

            for (int index = currentIndex; index < _n; index++)
            {
                Swap(ref items[currentIndex], ref items[index]);
                Console.WriteLine($"Swap BEFORE recursion: (cI [{currentIndex}], i [{index}]) values: (cI [{items[currentIndex]}], i [{items[index]}]) ");
                
                PermutationWithoutRepetitions(currentIndex + 1, items);
                
                Swap(ref items[currentIndex], ref items[index]);
                Console.WriteLine($"Swap AFTER recursion: (cI [{currentIndex}], i [{index}]) values: (cI [{items[currentIndex]}], i [{items[index]}]) ");
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