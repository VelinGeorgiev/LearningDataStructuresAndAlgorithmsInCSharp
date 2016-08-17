using System;

namespace Learning.Search
{
    public class BinarySearch<T> where T : IComparable
    {
        public T Search(T[] array, T item)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            int lo = 0;
            int hi = array.Length - 1;
            do
            {
                //int mid = (min + max)/2;
                int mid = lo + (hi - lo)/2;
                if (item.CompareTo(array[mid]) > 0)
                    lo = mid + 1;
                else
                    hi = mid - 1;
                if (array[mid].CompareTo(item) == 0)
                    return array[mid];
                //if (lo > hi) break;
            } while (lo <= hi);

            return default(T);
        }
    }
}
