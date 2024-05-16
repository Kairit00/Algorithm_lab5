using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Xml;

namespace GMI24H_Labb5_Grupp_ERTGRUPPNR.MyAlgorithmLibrary
{
    /// <summary>
    /// This class is used to implement the algorithms defined in the ISearcher interface.
    /// When you have implemented the algorithms, you should be able to test them by instantiating
    /// a Searcher object and call the methods.
    /// </summary>
    public class Searcher : ISearcher
    {

        // ----------------- BINARY SEARCH ---------------
        public int BinarySearch(int[] array, int target)
        {
            //Find the target item's index in the sorted array
            //If item isn't in the array, return -1
            int min = 0;
            int max = array.Length - 1;
            while (min <= max)
            {
                //find the dividing item
                int mid = (min + max) / 2;

                //see if we need to seach the left or right half
                if (target < array[mid])
                {
                    max = mid - 1;
                }
                else if (target > array[mid])
                {
                    min = mid + 1;
                }
                else
                {
                    return mid;
                }
            }
            //If we get here, the target is not in the array
            return -1;
        }
         
        //    ------------ JUMP SEARCH ----------------
        public int JumpSearch(int[] array, int target)
        {
            int n = array.Length;
            int step = (int)Sqrt(n); // Determine the jump size
            int prev = 0;

            // Jumping ahead in the array
            while (prev < n && array[prev] < target)
            {
                prev += step;
            }

            // Doing linear search in the block
            int end = Min(prev, n); // Ensure end doesn't exceed array bounds
            for (int i = prev - step; i < end; i++)
            {
                if (array[i] == target)
                {
                    return i;
                }
            }

            return -1; // If the element is not found
        }

        // Helper methods
        private int Sqrt(int x)
        {
            int sqrt = 1;
            while (sqrt * sqrt <= x)
            {
                sqrt++;
            }
            return sqrt - 1;
        }

        private int Min(int a, int b)
        {
            return a < b ? a : b;
        }

        //         ---------- LINEAR SEARCH --------------
        public int LinearSearch(int[] array, int target)
        {
            // Iterate through the array to find the target
            for (int i = 0; i < array.Length; i++)
            {
                // Check if the current element is the target
                if (array[i] == target)
                {
                    return i; // Return the index of the target element
                }
            }

            // If the loop completes without finding the target, return -1
            return -1;
        }
    }
}
