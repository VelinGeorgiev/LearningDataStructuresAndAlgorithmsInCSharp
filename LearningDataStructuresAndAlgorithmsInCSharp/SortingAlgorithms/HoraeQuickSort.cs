using System;

namespace Learning.SortingAlgorithms
{
    /// <summary>
    /// Hoare's scheme is more efficient than Lomuto's partition scheme because it does three times fewer swaps on average, and it creates efficient partitions even when all values are equal.
    /// it also doesn't produce a stable sort
    /// Source: https://en.wikipedia.org/wiki/Quicksort
    /// </summary>
    public class HoraeQuickSort<T> where T : IComparable
    {  
        public void Sort(T[] array, int lo, int hi)
        {
            if (lo < hi)
            {
                int p = Partition(array, lo, hi);
                Sort(array, lo, p);
                Sort(array, p + 1, hi);
            }
        }

        private int Partition(T[] array, int lo, int hi)
        {
            T pivot = array[lo];
            int i = lo - 1;
            int j = hi + 1;
            while (true)
            {
                do { i += 1; } while (array[i].CompareTo(pivot) < 0);
                do { j -= 1; } while (array[j].CompareTo(pivot) > 0);
                if (i >= j)
                {
                    return j;
                }
                Swap(array, i, j);
            }
        }

        private void Swap(T[] array, int i, int j)
        {
            T t = array[i];
            array[i] = array[j];
            array[j] = t;
        }
    }
}
