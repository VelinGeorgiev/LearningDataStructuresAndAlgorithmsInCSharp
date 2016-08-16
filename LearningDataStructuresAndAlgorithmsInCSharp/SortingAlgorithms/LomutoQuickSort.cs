using System;

namespace Learning.SortingAlgorithms
{
    /// <summary>
    /// Less efficient than Hoare Partition Scheme
    /// Uses last element
    /// Degrades to O(n2) when the array is already sorted as well as when the array has all equal elements
    ///to boost performance including various ways to select pivot, deal with equal elements, use other sorting algorithms such as Insertion sort for small arrays and so on
    /// Source: https://en.wikipedia.org/wiki/Quicksort
    /// </summary>
    public class LomutoQuickSort<T> where T : IComparable
    {  
        public void Sort(T[] array, int lo, int hi)
        {
            if (lo < hi)
            {
                int p = Partition(array, lo, hi);
                Sort(array, lo, p - 1);
                Sort(array, p + 1, hi);
            }
        }

        private int Partition(T[] array, int lo, int hi)
        {
            T pivot = array[hi];
            int i = lo;
            for (int j = lo; j <= hi - 1; j++) // or j < hi
            {
                if (array[j].CompareTo(pivot) <= 0) // or <
                { 
                    Swap(array, i, j);
                    i++;
                }
            }
            Swap(array, i, hi);
            return i;
        }

        private void Swap(T[] array, int i, int j)
        {
            T t = array[i];
            array[i] = array[j];
            array[j] = t;
        }
    }
}
