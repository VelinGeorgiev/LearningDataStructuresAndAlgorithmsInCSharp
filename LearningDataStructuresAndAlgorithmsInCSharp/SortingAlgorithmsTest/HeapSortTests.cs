using System;
using System.Collections.Generic;
using Learning.SortingAlgorithms;
using NUnit.Framework;

namespace Learning.SortingAlgorithmsTest
{
    [TestFixture]
    public class HeapSortTests
    {
        private readonly HeapSort<int> _heapSort;

        public HeapSortTests()
        {
            _heapSort = new HeapSort<int>();
        }

        [Test]
        public void HeapSortOfInts()
        {
            var array = new[] {10, 4, 6, 7, 8, 5, 3, 2, 1, 9};
            _heapSort.Sort(array);

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
    }
}
