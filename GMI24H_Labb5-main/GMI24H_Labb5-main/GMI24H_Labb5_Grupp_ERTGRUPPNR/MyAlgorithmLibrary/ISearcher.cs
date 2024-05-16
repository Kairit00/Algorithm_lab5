namespace GMI24H_Labb5_Grupp_ERTGRUPPNR.MyAlgorithmLibrary
{
    /// <summary>
    /// This interface is used to define which algorithms that can be implemented in the Searcher class
    /// and their parameters.
    /// </summary>
    public interface ISearcher
    {
        int LinearSearch(int[] array, int target);
        int BinarySearch(int[] array, int target);
        int JumpSearch(int[] array, int target);
    }
}