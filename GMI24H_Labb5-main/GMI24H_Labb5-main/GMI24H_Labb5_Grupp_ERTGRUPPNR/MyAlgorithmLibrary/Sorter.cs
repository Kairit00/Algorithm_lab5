using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GMI24H_Labb5_Grupp_ERTGRUPPNR.MyAlgorithmLibrary
{
    /// <summary>
    /// This class is used to implement the algorithms defined in the ISorter interface.
    /// When you have implemented the algorithms, you should be able to test them by instantiating
    /// a Sorter object and call the methods.
    /// </summary>
    class Sorter : ISorter
    {
        //      -------------- BUBBLE SORT --------------
        public void BubbleSort(int[] arr)
        {
            //Repeat until array is sorted
            bool not_sorted = true;
            while (not_sorted)
            {
                //Assume we won't find a pair to swap
                not_sorted = false;

                //search the array for adjacent items that are out of order
                for (int i = 1; i < arr.Length; i++)
                {
                    //See if items i and i - 1 are out of order
                    if (arr[i] < arr[i - 1])
                    {
                        //Swap them
                        int temp = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = temp;

                        //array isn't sortered after all
                        not_sorted = true;
                    }
                }
            }
        }

        //         ----------- HEAP SORT ---------------
        public void HeapSort(int[] values)
        {
            for (int i = values.Length - 1; i > 0; i--)
            {
                Swap(ref values[0], ref values[i]); // Swap the root (maximum element) with the last element
                Heapify(values, 0, i);  // Re-heapify the remaining elements
            }
        }
        private void Heapify(int[] values, int index, int heapSize)
        { 
            int largest = index;// Initialize largest as the root
            // Get left and right child indices
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;

            if (leftChildIndex < heapSize && values[leftChildIndex] > values[largest]) 
            {
                largest = leftChildIndex;
            }

            if (rightChildIndex < heapSize && values[rightChildIndex] > values[largest])
            {
                largest = rightChildIndex;
            }

            if (largest != index)
            {   
                Swap(ref values[index], ref values[largest]);
                Heapify(values, largest, heapSize);
            }
        }

        private void Swap(ref int a, ref int b)
        {
            // Swap two elements in an array
            int temp = a;
            a = b;
            b = temp;
        }

        //     -------------- INSERTION SORT ---------------
        public void InsertionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                // Move item i into position in the sorted part of the array
                int j;
                for (j = i - 1; j >= 0 && arr[j] > arr[i]; j--)
                {
                    arr[j + 1] = arr[j]; // Shift elements to the right to make space for arr[i]
                }
                arr[j + 1] = arr[i]; // Insert arr[i] into its correct sorted position
            }
        }

        // -------------------- QUICK SORT ----------------
        public void QuickSort(int[] arr, int start, int end)
        {
            var i = start;
            var j = end;
            var pivot = arr[start];

            //partition step
            while (i <= j)
            {
                //find element on the left side
                while (arr[i] < pivot)
                {
                    i++;
                }
                //find element on right side
                while (arr[j] > pivot)
                {
                    j--;
                }
                //Swap elements if necessary
                if (i <= j)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
            }
            //recusively sort left and right
            if (start < j)
                QuickSort(arr, start, j);
            if (i < end)
                QuickSort(arr, i, end);
        }
        
        // ------------- SELECTION SORT -----------------
        public void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                // Find the smallest item with index j >= i
                int smallestIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[smallestIndex])
                    {
                        smallestIndex = j;
                    }
                }
                // Swap values[i] and values[smallestIndex]
                int temp = arr[i];
                arr[i] = arr[smallestIndex];
                arr[smallestIndex] = temp;
            }
        }
    }
}
