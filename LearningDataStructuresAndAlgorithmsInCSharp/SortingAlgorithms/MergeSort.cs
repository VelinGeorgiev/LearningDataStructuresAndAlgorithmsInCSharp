using System;
using System.Collections.Generic;

namespace Learning.SortingAlgorithms
{
    public class MergeSort<T> where T: IComparable
    {
        public T[] TopDownSort(T[] arr)
        {
            if (arr.Length <= 1) return arr;

            int mid = arr.Length / 2; //ceil maybe
            T[] left = new T[mid];
            T[] right = new T[arr.Length - mid];

            for (int i = 0; i < left.Length; i++)
            {
                left[i] = arr[i];
            }
            for (int i = 0; i < right.Length; i++)
            {
                right[i] = arr[i + left.Length];
            }

            left = TopDownSort(left);
            right = TopDownSort(right);
            T[] result = TopDownMerge(left, right);
            return CopyArray(result, arr);
        }

        private T[] TopDownMerge(T[] left, T[] right)
        {
            // Result merge array.
            T[] result = new T[left.Length + right.Length];
            // Initial index of the result array.
            int k = 0;

            // Initial indexes of left and right subarrays.
            int i = 0, j = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i].CompareTo(right[j]) <= 0)
                {
                    result[k] = left[i]; i++;
                }
                else
                {
                    result[k] = right[j]; j++;
                }
                k++;
            }

            // Copy remaining elements of left, if any.
            while (i < left.Length)
            {
                result[k] = left[i];
                i++;
                k++;
            }

            // Copy remaining elements of right, if any.
            while (j < right.Length)
            {
                result[k] = right[j];
                j++;
                k++;
            }

            return result;
        }

        private T[] CopyArray(T[] result, T[] array)
        {
            for (var i = 0; i < result.Length; i++)
            {
                array[i] = result[i];
            }
            return array;
        }

        public void BottomUpSort(T[] list)
        {
            T[] result = new T[list.Length];
            int chunk = 1;
            while (chunk < list.Length)
            {
                int i = 0;
                while (i < list.Length - chunk)
                {
                    BottomUpMerge(list, i, chunk, result);
                    i += chunk * 2;
                }
                chunk *= 2;
            }
        }

        private void BottomUpMerge(IList<T> list, int leftPosition, int chunkSize, IList<T> workList)
        {
            int rightPosition = leftPosition + chunkSize;
            int endPosition = Math.Min(leftPosition + chunkSize * 2 - 1, list.Count - 1);
            int leftIndex = leftPosition;
            int rightIndex = rightPosition;

            for (int i = 0; i <= endPosition - leftPosition; i++)
            {
                if (leftIndex < rightPosition &&
                        (rightIndex > endPosition ||
                        list[leftIndex].CompareTo(list[rightIndex]) <= 0))
                {
                    workList[i] = list[leftIndex++];
                }
                else
                {
                    workList[i] = list[rightIndex++];
                }
            }

            for (int i = leftPosition; i <= endPosition; i++)
            {
                list[i] = workList[i - leftPosition];
            }
        }
    }
}

