using System;
using System.Collections.Generic;

namespace Learning.SortingAlgorithms
{
    /// <summary>
    /// Top down implementation of merge sort for array and linked list
    /// Source: https://en.wikipedia.org/wiki/Merge_sort
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MergeSort<T> where T : IComparable
    {
        public T[] Sort(T[] arr)
        {
            if (arr.Length <= 1) return arr;

            int mid = arr.Length/2; //ceil maybe
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

            left = Sort(left);
            right = Sort(right);
            T[] result = Merge(left, right);
            return Copy(result, arr);
        }

        private T[] Merge(T[] left, T[] right)
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
                    result[k] = left[i];
                    i++;
                }
                else
                {
                    result[k] = right[j];
                    j++;
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

        public LinkedList<T> Sort(LinkedList<T> list)
        {
            if (list.Count <= 1) return list;

            // Recursive case. First, divide the list into equal-sized sublists
            // consisting of the even and odd-indexed elements.
            LinkedList<T> listA = new LinkedList<T>();
            LinkedList<T> listB = new LinkedList<T>();
            int i = 0;
            LinkedListNode<T> node = list.First;

            while (node != null)
            {
                if (i%2 == 0)
                {
                    listB.AddLast(node.Value);
                }
                else
                {
                    listA.AddLast(node.Value);
                }
                node = node.Next;
                i++;
            }

            // Recursively sort both sublists.
            listA = Sort(listA);
            listB = Sort(listB);
            // Then merge the now-sorted sublists.
            var result = Merge(listA, listB);
            return Copy(result, list);
        }

        private LinkedList<T> Merge(LinkedList<T> left, LinkedList<T> right)
        {
            LinkedList<T> result = new LinkedList<T>();
            LinkedListNode<T> leftNode = left.First;
            LinkedListNode<T> rightNode = right.First;

            while (leftNode != null && rightNode != null)
            {
                if (leftNode.Value.CompareTo(rightNode.Value) <= 0)
                {
                    result.AddLast(leftNode.Value);
                    leftNode = leftNode.Next;
                }
                else
                {
                    result.AddLast(rightNode.Value);
                    rightNode = rightNode.Next;
                }
            }

            // Copy remaining elements of left, if any.
            while (leftNode != null)
            {
                result.AddLast(leftNode.Value);
                leftNode = leftNode.Next;
            }

            // Copy remaining elements of right, if any.
            while (rightNode != null)
            {
                result.AddLast(rightNode.Value);
                rightNode = rightNode.Next;
            }

            return result;
        }

        private T[] Copy(T[] result, T[] array)
        {
            for (var i = 0; i < result.Length; i++)
            {
                array[i] = result[i];
            }
            return array;
        }

        private LinkedList<T> Copy(LinkedList<T> result, LinkedList<T> list)
        {
            LinkedListNode<T> resultNode = result.First;
            LinkedListNode<T> listNode = list.First;

            while (resultNode != null)
            {
                listNode.Value = resultNode.Value;
                resultNode = resultNode.Next;
                listNode = listNode.Next;
            }

            return list;
        }
    }
}

