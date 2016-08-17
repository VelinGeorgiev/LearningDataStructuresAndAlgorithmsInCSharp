using System;
using System.Diagnostics.Contracts;

namespace Learning.SortingAlgorithms
{
    /// <summary>
    /// Based on the .NET implementation of DepthLimithQuickSort http://referencesource.microsoft.com/#mscorlib/system/array.cs,1aa7ced66ac73307,references
    /// </summary>
    public class QuickSort2<T> where T : IComparable
    {
        public void Sort(T[] array, int left, int right)
        {
            do
            {
                int i = left;
                int j = right;

                // pre-sort the low, middle (pivot), and high values in place.
                // this improves performance in the face of already sorted data, or 
                // data that is made up of multiple sorted runs appended together.
                int middle = GetMedian(i, j);
                SwapIfGreaterWithItems(array, i, middle); // swap the low with the mid point
                SwapIfGreaterWithItems(array, i, j);      // swap the low with the high
                SwapIfGreaterWithItems(array, middle, j); // swap the middle with the high

                T x = array[middle];
                do
                {
                    // Add a try block here to detect IComparers (or their
                    // underlying IComparables, etc) that are bogus.
                    try
                    {
                        while (array[i].CompareTo(x) < 0) i++;
                        while (x.CompareTo(array[j]) < 0) j--;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new ArgumentException("Arg_BogusIComparer");
                    }
                    catch (Exception e)
                    {
                        throw new InvalidOperationException("InvalidOperation_IComparerFailed", e);
                    }

                    Contract.Assert(i >= left && j <= right, "(i>=left && j<=right)  Sort failed - Is your IComparer bogus?");
                    if (i > j) break;
                    if (i < j)
                    {
                        Swap(array, i, j);
                    }
                    if (i != int.MaxValue) ++i;
                    if (j != int.MinValue) --j;
                } while (i <= j);

                if (j - left <= right - i)
                {
                    if (left < j) Sort(array, left, j);
                    left = i;
                }
                else
                {
                    if (i < right) Sort(array, i, right);
                    right = j;
                }
            } while (left < right);
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
            T t = array[i];
            array[i] = array[j];
            array[j] = t;
        }

        private int GetMedian(int low, int hi)
        {
            // Note both may be negative, if we are dealing with arrays w/ negative lower bounds.
            Contract.Requires(low <= hi);
            Contract.Assert(hi - low >= 0, "Length overflow!");
            return low + ((hi - low) >> 1);
        }
    }
}
