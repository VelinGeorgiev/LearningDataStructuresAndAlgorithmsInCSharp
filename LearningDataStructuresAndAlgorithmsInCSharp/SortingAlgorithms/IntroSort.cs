using System;

namespace Learning.SortingAlgorithms
{
    /// <summary>
    /// Based on the .NET implementation http://referencesource.microsoft.com/#mscorlib/system/array.cs,78c62950ae211cd3,references
    /// </summary>
    public class IntroSort<T> where T : IComparable
    {
        private readonly int _introsortSizeThreshold;
        private readonly InsertionSort<T> _insertionSort;
        private readonly HeapSort2<T> _heapSort;

        public IntroSort()
        {
            _introsortSizeThreshold = 16;
            _insertionSort = new InsertionSort<T>();
            _heapSort = new HeapSort2<T>();
        }

        public void Sort(T[] array, int lo, int hi, int depthLimit)
        {
            while (hi > lo)
            {
                int partitionSize = hi - lo + 1;
                if (partitionSize <= _introsortSizeThreshold)
                {
                    if (partitionSize == 1)
                    {
                        return;
                    }
                    if (partitionSize == 2)
                    {
                        SwapIfGreaterWithItems(array, lo, hi);
                        return;
                    }
                    if (partitionSize == 3)
                    {
                        SwapIfGreaterWithItems(array, lo, hi - 1);
                        SwapIfGreaterWithItems(array, lo, hi);
                        SwapIfGreaterWithItems(array, hi - 1, hi);
                        return;
                    }

                    _insertionSort.Sort(array, lo, hi);
                    return;
                }

                if (depthLimit == 0)
                {
                    _heapSort.Sort(array, lo, hi);
                    return;
                }
                depthLimit--;

                int p = PickPivotAndPartition(array, lo, hi);
                Sort(array, p + 1, hi, depthLimit);
                hi = p - 1;
            }
        }

        private int PickPivotAndPartition(T[] array, int lo, int hi)
        {
            // Compute median-of-three.  But also partition them, since we've done the comparison.
            int mid = lo + (hi - lo) / 2;

            SwapIfGreaterWithItems(array, lo, mid);
            SwapIfGreaterWithItems(array, lo, hi);
            SwapIfGreaterWithItems(array, mid, hi);

            T pivot = array[mid];
            Swap(array, mid, hi - 1);
            int left = lo, right = hi - 1;  // We already partitioned lo and hi and put the pivot in hi - 1.  And we pre-increment & decrement below.

            while (left < right)
            {
                while (array[++left].CompareTo(pivot) < 0) ;
                while (pivot.CompareTo(array[--right]) < 0) ;

                if (left >= right)
                    break;

                Swap(array, left, right);
            }

            // Put pivot in the right location.
            Swap(array, left, (hi - 1));
            return left;
        }

        private void SwapIfGreaterWithItems(T[] array, int a, int b)
        {
            if (a != b)
            {
                if (array[a].CompareTo(array[b]) > 0)
                {
                    T t = array[a];
                    array[a] = array[b];
                    array[b] = t;
                }
            }
        }

        private void Swap(T[] array, int i, int j)
        {
            if (array[i].CompareTo(array[j]) > 0)
            {
                T t = array[i];
                array[i] = array[j];
                array[j] = t;
            }
        }
    }
}
