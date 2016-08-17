using System;

namespace Learning.SortingAlgorithms
{
    /// <summary>
    /// Simplified Quick sort with median
    /// </summary>
    public class QuickSort<T> where T : IComparable
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
            // Compute median-of-three.
            int mid = lo + (hi - lo) / 2;
            T pivot = array[lo];
            Swap(array, mid, hi - 1);
            
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
