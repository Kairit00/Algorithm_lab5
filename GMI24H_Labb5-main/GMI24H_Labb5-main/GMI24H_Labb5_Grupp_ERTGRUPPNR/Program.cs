using GMI24H_Labb5_Grupp_ERTGRUPPNR;
using GMI24H_Labb5_Grupp_ERTGRUPPNR.MyAlgorithmLibrary;
using System.Diagnostics;


/// <summary>
/// NOTE: You are by no means obligated to use this project structure. It is just a suggestion. If you want to create
/// your own project from scratch, you are most welcome to do so.
/// 
/// In the Program class you have the Main methods which is the starting point of any program which I am sure that you
/// already are aware of. 
/// 
/// Please write comments in your own code for specific test cases or other things that you want to show.
/// It is ok to write your code in English and your comments in Swedish. However, do not mix Enlish and Swedish IN THE CODE.
/// 
/// It is very much up to you how you decide to organize your work so do not feel obligated to use the structure provided in this template.
///
/// Experiment and have fun! 
/// 
/// Best of luck! /Elin
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {

        TimeSpan binarySearchTime = TimeSpan.Zero;
        TimeSpan linearSearchTime = TimeSpan.Zero;
        TimeSpan jumpSearchTime = TimeSpan.Zero;
        TimeSpan exponentialSearchTime = TimeSpan.Zero;
        TimeSpan interpolationSearchTime = TimeSpan.Zero;

        TimeSpan bubbleSortTime = TimeSpan.Zero;
        TimeSpan heapSortTime = TimeSpan.Zero;
        TimeSpan insertionSortTime = TimeSpan.Zero;
        TimeSpan quickSortTime = TimeSpan.Zero;
        TimeSpan selectionSortTime = TimeSpan.Zero;

        Sorter sorter = new Sorter();
        Searcher searcher = new Searcher();

        /**
         * Testing code for sort algorithm
         */
        for (int i = 0; i < 5; i++)
        {
            int[] randomNumbers = new int[1000];
            Random random = new Random();

            for (int j = 0; j < randomNumbers.Length; j++)
            {
                randomNumbers[j] = random.Next(0, 100);
            }

            switch (i)
            {
                case 0: //           ------Bubblesort----------
                    Stopwatch bubbleSortStopwatch = new Stopwatch();
                    bubbleSortStopwatch.Start();
                    sorter.BubbleSort(randomNumbers);
                    bubbleSortStopwatch.Stop();
                    bubbleSortTime = bubbleSortStopwatch.Elapsed;
                    break;
                case 1: //          -------HeapSort------------
                    Stopwatch heapSortStopwatch = new Stopwatch();
                    heapSortStopwatch.Start();
                    sorter.HeapSort(randomNumbers);
                    heapSortStopwatch.Stop();
                    heapSortTime = heapSortStopwatch.Elapsed;

                    break;
                case 2: //--------------- insertionSort -----------
                    Stopwatch insertionSortStopwatch = new Stopwatch();
                    insertionSortStopwatch.Start();
                    sorter.InsertionSort(randomNumbers);
                    insertionSortStopwatch.Stop();
                    insertionSortTime = insertionSortStopwatch.Elapsed;

                    break;
                case 3: //------------- Quicksort ---------
                    Stopwatch quickSortStopwatch = new Stopwatch();
                    quickSortStopwatch.Start();
                    sorter.QuickSort(randomNumbers, 0, randomNumbers.Length - 1);
                    quickSortStopwatch.Stop();
                    quickSortTime = quickSortStopwatch.Elapsed;
                    break;
                case 4: //           -------- Selectionsort
                    Stopwatch selectionSortStopwatch = new Stopwatch();
                    selectionSortStopwatch.Start();
                    sorter.SelectionSort(randomNumbers);
                    selectionSortStopwatch.Stop();
                    selectionSortTime = selectionSortStopwatch.Elapsed;
                    break;
            }
        }

        /**
         * Showing code for the Sort algorithm!
         */
        Console.WriteLine("Sort Timings:");
        if (bubbleSortTime != null)
            Console.WriteLine($"    Bubble Sort Time:    {bubbleSortTime}");
        if (heapSortTime != null)
            Console.WriteLine($"    Heap Sort Time:      {heapSortTime}");
        if (insertionSortTime != null)
            Console.WriteLine($"    Insertion Sort Time: {insertionSortTime}");
        if (quickSortTime != null)
            Console.WriteLine($"    Quick Sort Time:     {quickSortTime}");
        if (selectionSortTime != null)
            Console.WriteLine($"    Selection Sort Time: {selectionSortTime}");

        /**
         * Testing code for the search-algorithms!
         */

        //    ------------ JUMP SEARCH ------------
        int[] jsArray = { 0, 1,2, 45, 55, 60, 69, 88, 94, 101, 105, 155 };
        Stopwatch jumpSearchStopwatch = new Stopwatch();
        jumpSearchStopwatch.Start();
        int jfound = searcher.JumpSearch(jsArray, 2);
        if (jfound != 2) throw new Exception("Jump Search failed!");
        jumpSearchStopwatch.Stop();
        jumpSearchTime = jumpSearchStopwatch.Elapsed;

        //    ------------ BINARY SEARCH ----------------
        int[] bsArray = { 0, 1, 2, 3, 4, 6, 28, 34, 34, 38, 67, 69, 347, 467 };
        Stopwatch binarySearchStopwatch = new Stopwatch();
        binarySearchStopwatch.Start();
        int bsfound = searcher.BinarySearch(bsArray, 347);
        if (bsfound != 12) throw new Exception("Binary Search failed!");
        binarySearchStopwatch.Stop();
        binarySearchTime = jumpSearchStopwatch.Elapsed;

        //    -------------- LINEAR SEARCH -------------
        int[] linear = { 0, 1, 45, 69, 10, 52, 130, 65, 32, 75, 735, 90, 50 };
        Stopwatch linearSearchStopwatch = new Stopwatch();
        linearSearchStopwatch.Start();
        int lfound = searcher.LinearSearch(linear, 90);
        if (lfound != 11) throw new Exception("Linear Search failed!");
        linearSearchStopwatch.Stop();
        linearSearchTime = linearSearchStopwatch.Elapsed;

      
        /**
         * Showing the code for searching algorithm!
         */
        Console.WriteLine("\nSearch Timings:");
        if (binarySearchTime != null)
            Console.WriteLine($"    Binary Search Time:  {binarySearchTime}");
        if (linearSearchTime != null)
            Console.WriteLine($"    Linear Search Time:  {linearSearchTime}");
        if (jumpSearchTime != null)
            Console.WriteLine($"    Jump Search Time:    {jumpSearchTime}");
    }


}
