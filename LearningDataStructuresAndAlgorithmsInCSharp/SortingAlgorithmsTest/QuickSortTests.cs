using System;
using Learning.SortingAlgorithms;
using NUnit.Framework;

namespace Learning.SortingAlgorithmsTest
{
    [TestFixture]
    public class QuickSortTests
    {
        [Test]
        public void TestHoareQuickSortOfInts()
        {
            var array = new int[] { 10, 4, 6, 7, 8, 5, 3, 2, 1, 9 };
            var quickSort = new QuickSort();
            
            quickSort.HoarePartitionScheme(array, 0, array.Length - 1);

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
        public void TestLomutoQuickSortOfInts()
        {
            var array = new int[] { 11, 16, 2, 8, 1, 9, 4, 7 };
            var quickSort = new QuickSort();

            quickSort.LomutoPartitionScheme(array, 0, array.Length - 1);

            Assert.AreEqual(array[0], 1);
            Assert.AreEqual(array[1], 2);
            Assert.AreEqual(array[2], 4);
            Assert.AreEqual(array[3], 7);
            Assert.AreEqual(array[4], 8);
            Assert.AreEqual(array[5], 9);
            Assert.AreEqual(array[6], 11);
            Assert.AreEqual(array[7], 16);
        }

        [Test]
        public void TestHoareQuickSortOfObjects()
        {
            QuickSortObject[] array = {
                new QuickSortObject { Name = "10", Value = 10},
                new QuickSortObject { Name = "4", Value = 4},
                new QuickSortObject { Name = "6", Value = 6},
                new QuickSortObject { Name = "7", Value = 7},
                new QuickSortObject { Name = "8", Value = 8},
                new QuickSortObject { Name = "5", Value = 5},
                new QuickSortObject { Name = "3", Value = 3},
                new QuickSortObject { Name = "2", Value = 2},
                new QuickSortObject { Name = "1", Value = 1},
                new QuickSortObject { Name = "9", Value = 9}
            };

            Func<QuickSortObject, QuickSortObject, int> comparer = (x, y) =>
            {
                if (x.Value == y.Value) return 0;
                if (x.Value < y.Value) return -1;
                return 1;
            };
            var quickSort = new QuickSort<QuickSortObject>(comparer);
            quickSort.HoarePartitionScheme(array, 0, array.Length - 1);

            Assert.AreEqual(array[0].Value, 1);
            Assert.AreEqual(array[1].Value, 2);
            Assert.AreEqual(array[2].Value, 3);
            Assert.AreEqual(array[3].Value, 4);
            Assert.AreEqual(array[4].Value, 5);
            Assert.AreEqual(array[5].Value, 6);
            Assert.AreEqual(array[6].Value, 7);
            Assert.AreEqual(array[7].Value, 8);
            Assert.AreEqual(array[8].Value, 9);
            Assert.AreEqual(array[9].Value, 10);
        }

        [Test]
        public void TestLomutoQuickSortOfObjects()
        {
            QuickSortObject[] array = {
                new QuickSortObject { Name = "10", Value = 10},
                new QuickSortObject { Name = "4", Value = 4},
                new QuickSortObject { Name = "6", Value = 6},
                new QuickSortObject { Name = "7", Value = 7},
                new QuickSortObject { Name = "8", Value = 8},
                new QuickSortObject { Name = "5", Value = 5},
                new QuickSortObject { Name = "3", Value = 3},
                new QuickSortObject { Name = "2", Value = 2},
                new QuickSortObject { Name = "1", Value = 1},
                new QuickSortObject { Name = "9", Value = 9}
            };

            Func<QuickSortObject, QuickSortObject, int> comparer = (x, y) =>
            {
                if (x.Value == y.Value) return 0;
                if (x.Value < y.Value) return -1;
                return 1;
            };
            var quickSort = new QuickSort<QuickSortObject>(comparer);
            quickSort.LomutoPartitionScheme(array, 0, array.Length - 1);

            Assert.AreEqual(array[0].Value, 1);
            Assert.AreEqual(array[1].Value, 2);
            Assert.AreEqual(array[2].Value, 3);
            Assert.AreEqual(array[3].Value, 4);
            Assert.AreEqual(array[4].Value, 5);
            Assert.AreEqual(array[5].Value, 6);
            Assert.AreEqual(array[6].Value, 7);
            Assert.AreEqual(array[7].Value, 8);
            Assert.AreEqual(array[8].Value, 9);
            Assert.AreEqual(array[9].Value, 10);
        }

        //[TestCase(12, 3, 4)]
        //[TestCase(12, 2, 6)]
        //[TestCase(12, 4, 3)]
        //public void DivideTest(int n, int d, int q)
        //{
        //    Assert.AreEqual(q, n / d);
        //}
    }

    /// <summary>
    /// Test object.
    /// </summary>
    public class QuickSortObject
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
