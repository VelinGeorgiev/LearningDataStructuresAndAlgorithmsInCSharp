using System;
using System.Collections.Generic;

namespace Learning.SortingAlgorithms
{
    public class BottomUpMerge<T> where T : IComparable
    {
        public T[] Sort(T[] array)
        {
            T[] workArray = new T[array.Length];
            int len = array.Length;

            for (int width = 1; width < len; width = 2 * width)
            {
                for (int i = 0; i < len; i = i + 2 * width)
                {
                    Merge(array, i, Math.Min(i + width, len), Math.Min(i + 2 * width, len), workArray);
                }
                CopyArray(workArray, array);
            }
            return array;
        }

        private void Merge(T[] array, int iLeft, int iRight, int iEnd, T[] workArray)
        {
            int i = iLeft, j = iRight;
            for (int k = iLeft; k < iEnd; k++)
            {
                if (i < iRight && (j >= iEnd || array[i].CompareTo(array[j]) <= 0))
                {
                    workArray[k] = array[i];
                    i = i + 1;
                }
                else
                {
                    workArray[k] = array[j];
                    j = j + 1;
                }
            }
        }

        void CopyArray(T[] workArray, T[] array)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = workArray[i];
        }

        public void Sort(LinkedList<T> list)
        {
            LinkedListNode<T> head = list.First;

            if (head == null) return;

            int count = 0;
            LinkedListNode<T> next;
            LinkedListNode<T> countNext = head;
            int i = 0;

            while (countNext != null)
            {
                countNext = countNext.Next;
                count++;
            }
            LinkedListNode<T>[] array = new LinkedListNode<T>[count];

            countNext = head;
            int a = 0;
            while (countNext != null)
            {
                array[a] = countNext;
                countNext = countNext.Next;
                a++;
            }

            LinkedListNode<T> result = head;

            while (result != null)
            {
                next = result.Next;
                for (i = 0; (i < array.Length) && (array[i] != null); i++)
                {
                    result = Merge(array[i], result);
                    array[i] = null;
                }
                if (i == array.Length)
                {
                    i -= 1;
                }
                result = next;
            }
            // merge array into single list
            //        result = nil
            //for (i = 0; i < 32; i += 1)
            //            result = merge(array[i], result)
            //return result
            //        return list;
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

        private LinkedListNode<T> Merge(LinkedListNode<T> left, LinkedListNode<T> right)
        {
            LinkedListNode<T> result;
            if (left.Value.CompareTo(right.Value) <= 0)
            {
                result = left;
            }
            else
            {
                result = right;
            }

            return result;
        }
    }
}
