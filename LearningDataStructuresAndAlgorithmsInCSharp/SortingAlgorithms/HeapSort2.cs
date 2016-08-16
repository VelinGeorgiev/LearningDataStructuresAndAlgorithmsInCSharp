using System;

namespace Learning.SortingAlgorithms
{
    /// <summary>
    /// Based on the .NET implementation http://referencesource.microsoft.com/#mscorlib/system/array.cs,279a1030efda819d
    /// Does not use recursion when DownHeap so a bit better on space complexity.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class HeapSort2<T> where T : IComparable
    {
        public void Sort(T[] array, int lo, int hi)
        {
            int n = hi - lo + 1;
            for (int i = n / 2; i >= 1; i = i - 1)
            {
                DownHeap(array, i, n, lo);
            }
            for (int i = n; i > 1; i = i - 1)
            {
                Swap(array, lo, lo + i - 1);
                DownHeap(array, 1, i - 1, lo);
            }
        }

        private void DownHeap(T[] array, int i, int n, int lo)
        {
            T d = array[lo + i - 1];
            int child;
            while (i <= n / 2)
            {
                child = 2 * i;
                if (child < n && array[lo + child - 1].CompareTo(array[lo + child]) < 0)
                {
                    child++;
                }
                if (!(d.CompareTo(array[lo + child - 1]) < 0))
                    break;
                array[lo + i - 1] = array[lo + child - 1];
                i = child;
            }
            array[lo + i - 1] = d;
        }

        private void Swap(T[] array, int i, int j)
        {
            T t = array[i];
            array[i] = array[j];
            array[j] = t;
        }
    }
}
