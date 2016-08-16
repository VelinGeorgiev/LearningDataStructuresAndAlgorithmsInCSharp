using System;
using System.Collections.Generic;

namespace Learning.SortingAlgorithms
{
    /// <summary>
    /// Source: https://en.wikipedia.org/wiki/Quicksort
    /// </summary>
    public class QuickSort<T> where T : IComparable
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
}
