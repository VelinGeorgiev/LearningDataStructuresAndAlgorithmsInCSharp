using System;
using System.Collections.Generic;
using Learning.DataStructures;
using Learning.SortingAlgorithms;
using NUnit.Framework;

namespace Learning.SortingAlgorithmsTest
{
    [TestFixture]
    public class BottomUpMergeSortTests
    {
        private readonly BottomUpMerge<int> _mergeSort;

        public BottomUpMergeSortTests()
        {
            _mergeSort = new BottomUpMerge<int>();
        }

        [Test]
        public void BottomUpMergeSortOfInts()
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
        public void BottomUpMergeSortOfIntsBigLength()
        {
            var random = new Random();
            var array = new int[200000];
            int min = 0;
            int max = 200000;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(min, max);
            }

            _mergeSort.Sort(array);

            for (int j = 0; j < array.Length - 1; j++)
            {
                Assert.LessOrEqual(array[j], array[j + 1]);
            }
        }

        [Test]
        public void FindDublicatesBottomUpSort()
        {
            int[] arrayA = {8, 6, 7, 4, 4, 5, 2, 3, 1, 9, 10};
            int[] arrayB = {8, 6, 7, 4};

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

        [Test]
        public void MergeSortLinkedList()
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
        public void SortLinkedListBigList()
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
