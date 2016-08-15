using System;
using System.Collections.Generic;
using Learning.SortingAlgorithms;
using NUnit.Framework;

namespace Learning.SortingAlgorithmsTest
{
    [TestFixture]
    public class MergeSortTests
    {
        private readonly MergeSort<int> _mergeSort;

        public MergeSortTests()
        {
            _mergeSort = new MergeSort<int>();
        }

        [Test]
        public void TopDownMergeSortOfInts()
        {
            var array = new[] {10, 4, 6, 7, 8, 5, 3, 2, 1, 9};
            _mergeSort.Sort(array);

            Assert.AreEqual(array[0], 1);
            Assert.AreEqual(array[1], 2);
            Assert.AreEqual(array[2], 3);
            Assert.AreEqual(array[3], 4);
            Assert.AreEqual(array[4], 5);
            Assert.AreEqual(array[5], 6);
            Assert.AreEqual(array[6], 7);
            Assert.AreEqual(array[7], 8);
            Assert.AreEqual(array[8], 9);
            Assert.AreEqual(array[9], 10);
        }

        [Test]
        public void AbsoluteListSorting()
        {
            var array = new[] { 1, -3, -4 };
            _mergeSort.Sort(array);

            Assert.AreEqual(array[0], -4);
            Assert.AreEqual(array[1], -3);
            Assert.AreEqual(array[2], 1);
        }

        [Test]
        public void TopDownMergeSortOfIntsBigLength()
        {
            var random = new Random();
            var array = new int[200000];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 200000);
            }
            _mergeSort.Sort(array);

            for (int j = 0; j < array.Length - 1; j++)
            {
                Assert.LessOrEqual(array[j], array[j + 1]);
            }
        }

        [Test]
        public void TopDownMergeSortFindDublicates()
        {
            int[] arrayA = { 8, 6, 7, 4, 4, 5, 2, 3, 1, 9, 10 };
            int[] arrayB = { 8, 6, 7, 4 };
            var sortedArrayA = _mergeSort.Sort(arrayA);
            var sortedArrayB = _mergeSort.Sort(arrayB);

            int i = 0;
            int j = 0;
            int found = 0;
            var list = new List<int>();

            while (i < sortedArrayA.Length && j < sortedArrayB.Length)
            {
                if (sortedArrayA[i] == sortedArrayB[j])
                {
                    found++;
                    list.Add(sortedArrayA[i]);
                    i++;
                    j++;
                }
                else if (sortedArrayA[i] < sortedArrayB[j])
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }

            Assert.AreEqual(found, 4);
            Assert.AreEqual(list[0], 4);
            Assert.AreEqual(list[1], 6);
            Assert.AreEqual(list[2], 7);
            Assert.AreEqual(list[3], 8);
        }

        /// <summary>
        /// Depending on a number of factors, it may actually be faster to copy the list to an array and then use a Quicksort.
        /// The reason this might be faster is that an array has much better cache performance than a linked list.
        /// If the nodes in the list are dispersed in memory, you may be generating cache misses all over the place. 
        /// Then again, if the array is large you will get cache misses anyway. 
        /// Mergesort parallelises better, so it may be a better choice if that is what you want.
        /// It is also much faster if you perform it directly on the linked list. 
        /// Since both algorithms run in O(n* log n), making an informed decision 
        /// would involve profiling them both on the machine you would like to run them on.
        /// Source: http://stackoverflow.com/questions/1525117/whats-the-fastest-algorithm-for-sorting-a-linked-list
        /// </summary>
        [Test]
        public void TopDownMergeSortLinkedList()
        {
            var linkedList = new LinkedList<int>();
            linkedList.AddLast(4);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(1);
            linkedList.AddLast(5);
            _mergeSort.Sort(linkedList);

            LinkedListNode<int> node = linkedList.First;
            while (node != null)
            {
                var nextNode = node.Next;
                if (nextNode != null)
                {
                    Assert.LessOrEqual(node.Value, nextNode.Value);
                }
                node = node.Next;
            }
        }

        [Test]
        public void TopDownSortLinkedListBigList()
        {
            var linkedList = new LinkedList<int>();
            var random = new Random();
            for (int i = 0; i < 200000; i++)
            {
                linkedList.AddLast(random.Next(0, 200000));
            }
            _mergeSort.Sort(linkedList);

            LinkedListNode<int> node = linkedList.First;
            while (node != null)
            {
                var nextNode = node.Next;
                if (nextNode != null)
                {
                    Assert.LessOrEqual(node.Value, nextNode.Value);
                }
                node = node.Next;
            }
        }
    }
}
