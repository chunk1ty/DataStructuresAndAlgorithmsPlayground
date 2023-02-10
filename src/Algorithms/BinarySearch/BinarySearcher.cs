namespace BinarySearch;

public class BinarySearcher
{
    /// <summary>
    /// Returns index of target element or -1.
    /// </summary>
    /// <param name="elements"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int SearchByIteration(int[] elements, int target)
    {
        int left = 0;
        int right = elements.Length - 1;

        while (left <= right)
        {
            int middle = (left + right) / 2;

            if (elements[middle] == target)
            {
                return middle;
            }

            if (elements[middle] < target)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return -1;
    }
    
    /// <summary>
    /// Returns index of target element or -1.
    /// </summary>
    /// <param name="elements"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int SearchByRecursion(int[] elements, int target)
    {
        return Search(elements, target, 0, elements.Length - 1);
    }

    private int Search(int[] elements, int target, int left, int right)
    {
        if (left <= right)
        {
            int middle = (left + right) / 2;

            if (elements[middle] == target)
            {
                return middle;
            }

            if (elements[middle] < target)
            {
                return Search(elements, target, middle + 1, right);
            }
            else
            {
                return Search(elements, target, left, middle - 1);
            }
        }

        return -1;
    }
}