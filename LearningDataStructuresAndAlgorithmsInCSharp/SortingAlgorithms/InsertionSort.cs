using System;

namespace Learning.SortingAlgorithms
{
    class InsertionSort<T> where T : IComparable
    {
        /// <summary>
        /// The .NET implementation  http://referencesource.microsoft.com/#mscorlib/system/array.cs,c1c8d19d6b629d8c,references
        /// </summary>
        /// <param name="array"></param>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        public void Sort(T[] array, int lo, int hi)
        {
            int i, j;
            T t;
            for (i = lo; i < hi; i++)
            {
                j = i;
                t = array[i + 1];
                while (j >= lo && t.CompareTo(array[j]) < 0)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = t;
            }
        }

        /// <summary>
        /// Implementation https://github.com/gwtw/csharp-sorting/blob/master/src/InsertionSort.cs
        /// </summary>
        /// <param name="list"></param>
        public void Sort(T[] list)
        {
            for (int i = 1; i < list.Length; i++)
            {
                T item = list[i];
                int indexHole = i;
                while (indexHole > 0 && list[indexHole - 1].CompareTo(item) > 0)
                {
                    list[indexHole] = list[--indexHole];
                }
                list[indexHole] = item;
            }
        } 
    }
}
