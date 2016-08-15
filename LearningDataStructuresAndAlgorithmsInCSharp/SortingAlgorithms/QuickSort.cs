using System;
using System.Collections.Generic;

namespace Learning.SortingAlgorithms
{
    /// <summary>
    /// Source: https://en.wikipedia.org/wiki/Quicksort
    /// </summary>
    public class QuickSort
    {  
       /// <summary>
       /// Less efficient than Hoare Partition Scheme
       /// Uses last element
       /// Degrades to O(n2) when the array is already sorted as well as when the array has all equal elements
       ///to boost performance including various ways to select pivot, deal with equal elements, use other sorting algorithms such as Insertion sort for small arrays and so on
       /// </summary>
       /// <param name="array"></param>
       /// <param name="lo"></param>
       /// <param name="hi"></param> 
        public void LomutoPartitionScheme(int[] array, int lo, int hi)
        {
            if (lo < hi)
            {
                int pivot = LomutoPartition(array, lo, hi);
                LomutoPartitionScheme(array, lo, pivot - 1);
                LomutoPartitionScheme(array, pivot + 1, hi);
            }
        }

        private int LomutoPartition(int[] array, int lo, int hi)
        {
            int pivot = array[hi];
            int i = lo;
            for (int j = lo; j <= hi - 1; j++) // or j < hi
            {
                if (array[j] <= pivot) // or <
                { 
                    Swap(ref array[i], ref array[j]);
                    i++;
                }
            }
            Swap(ref array[i], ref array[hi]);
            return i;
        }
        /// <summary>
        /// Hoare's scheme is more efficient than Lomuto's partition scheme because it does three times fewer swaps on average, and it creates efficient partitions even when all values are equal.
        /// it also doesn't produce a stable sort
        /// </summary>
        /// <param name="array"></param>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        public void HoarePartitionScheme(int[] array, int lo, int hi)
        {
            if (lo < hi)
            {
                int pivot = HoarePartition(array, lo, hi);
                HoarePartitionScheme(array, lo, pivot);
                HoarePartitionScheme(array, pivot + 1, hi);
            }
        }

        private int HoarePartition(int[] array, int lo, int hi)
        {
            int pivot = array[lo];
            int i = lo - 1;
            int j = hi + 1;
            while (true)
            {
                do { i += 1; } while (array[i] < pivot);
                do { j -= 1; } while (array[j] > pivot);
                if (i >= j)
                {
                    return j;
                }
                Swap(ref array[i], ref array[j]);
            }
        }

        private void Swap(ref int indexOne, ref int indexTwo)
        {
            int temp = indexOne;
            indexOne = indexTwo;
            indexTwo = temp;
        }
    }

    /// <summary>
    /// Object quick sort implementation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QuickSort<T> : IComparer<T>
    {
        readonly Func<T, T, int> _comparer;

        public QuickSort(Func<T, T, int> comparer)
        {
            _comparer = comparer;
        }

        public int Compare(T x, T y)
        {
            return _comparer(x, y);
        }

        public void LomutoPartitionScheme(T[] array, int lo, int hi)
        {
            if (lo < hi)
            {
                int pivot = LomutoPartition(array, lo, hi);
                LomutoPartitionScheme(array, lo, pivot - 1);
                LomutoPartitionScheme(array, pivot + 1, hi);
            }
        }

        private int LomutoPartition(T[] array, int lo, int hi)
        {
            T pivot = array[hi];
            int i = lo;
            for (int j = lo; j <= hi - 1; j++) // or j < hi
            {
                if (_comparer(array[j], pivot) <= 0)
                {
                    Swap(ref array[i], ref array[j]);
                    i++;
                }
            }
            Swap(ref array[i], ref array[hi]);
            return i;
        }

        public void HoarePartitionScheme(T[] array, int lo, int hi)
        {
            if (lo < hi)
            {
                int pivot = HoarePartition(array, lo, hi);
                HoarePartitionScheme(array, lo, pivot);
                HoarePartitionScheme(array, pivot + 1, hi);
            }
        }

        private int HoarePartition(T[] array, int lo, int hi)
        {
            T pivot = array[lo];
            int i = lo - 1;
            int j = hi + 1;
            while (true)
            {
                do { i += 1; } while (_comparer(array[i], pivot) < 0);
                do { j -= 1; } while (_comparer(array[j], pivot) > 0);
                if (i >= j)
                {
                    return j;
                }
                Swap(ref array[i], ref array[j]);
            }
        }

        private void Swap(ref T indexOne, ref T indexTwo)
        {
            T temp = indexOne;
            indexOne = indexTwo;
            indexTwo = temp;
        }
    }

    //[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    //private static int GetMedian(int low, int hi)
    //{
    //    // Note both may be negative, if we are dealing with arrays w/ negative lower bounds.
    //    Contract.Requires(low <= hi);
    //    Contract.Assert(hi - low >= 0, "Length overflow!");
    //    return low + ((hi - low) >> 1);
    //}

    //More optimizations:
    //A popular choice for picking this value is to determine the median value in
    //the array.You can do this by taking the upper bound of the array and dividing
    //it by 2. For example:
    //theFirst = arr[(int)arr.GetUpperBound(0) / 2]

    // Compute median-of-three.  But also partition them, since we've done the comparison.
    //int mid = lo + (hi - lo) / 2;


    //private void Heapsort(int lo, int hi)
    //{
    //    int n = hi - lo + 1;
    //    for (int i = n / 2; i >= 1; i = i - 1)
    //    {
    //        DownHeap(i, n, lo);
    //    }
    //    for (int i = n; i > 1; i = i - 1)
    //    {
    //        Swap(lo, lo + i - 1);

    //        DownHeap(1, i - 1, lo);
    //    }
    //}

    //private void DownHeap(int i, int n, int lo)
    //{
    //    Object d = keys[lo + i - 1];
    //    Object dt = (items != null) ? items[lo + i - 1] : null;
    //    int child;
    //    while (i <= n / 2)
    //    {
    //        child = 2 * i;
    //        if (child < n && comparer.Compare(keys[lo + child - 1], keys[lo + child]) < 0)
    //        {
    //            child++;
    //        }
    //        if (!(comparer.Compare(d, keys[lo + child - 1]) < 0))
    //            break;
    //        keys[lo + i - 1] = keys[lo + child - 1];
    //        if (items != null)
    //            items[lo + i - 1] = items[lo + child - 1];
    //        i = child;
    //    }
    //    keys[lo + i - 1] = d;
    //    if (items != null)
    //        items[lo + i - 1] = dt;
    //}

    //private void InsertionSort(int lo, int hi)
    //{
    //    int i, j;
    //    Object t, ti;
    //    for (i = lo; i < hi; i++)
    //    {
    //        j = i;
    //        t = keys[i + 1];
    //        ti = (items != null) ? items[i + 1] : null;
    //        while (j >= lo && comparer.Compare(t, keys[j]) < 0)
    //        {
    //            keys[j + 1] = keys[j];
    //            if (items != null)
    //                items[j + 1] = items[j];
    //            j--;
    //        }
    //        keys[j + 1] = t;
    //        if (items != null)
    //            items[j + 1] = ti;
    //    }
    //}

    //public static void Reverse(Array array, int index, int length)
    //{
    //    if (array == null)
    //        throw new ArgumentNullException("array");
    //    if (index < array.GetLowerBound(0) || length < 0)
    //        throw new ArgumentOutOfRangeException((index < 0 ? "index" : "length"), Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
    //    if (array.Length - (index - array.GetLowerBound(0)) < length)
    //        throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
    //    if (array.Rank != 1)
    //        throw new RankException(Environment.GetResourceString("Rank_MultiDimNotSupported"));
    //    Contract.EndContractBlock();

    //    bool r = TrySZReverse(array, index, length);
    //    if (r)
    //        return;

    //    int i = index;
    //    int j = index + length - 1;
    //    Object[] objArray = array as Object[];
    //    if (objArray != null)
    //    {
    //        while (i < j)
    //        {
    //            Object temp = objArray[i];
    //            objArray[i] = objArray[j];
    //            objArray[j] = temp;
    //            i++;
    //            j--;
    //        }
    //    }
    //    else
    //    {
    //        while (i < j)
    //        {
    //            Object temp = array.GetValue(i);
    //            array.SetValue(array.GetValue(j), i);
    //            array.SetValue(temp, j);
    //            i++;
    //            j--;
    //        }
    //    }
    //}
}
