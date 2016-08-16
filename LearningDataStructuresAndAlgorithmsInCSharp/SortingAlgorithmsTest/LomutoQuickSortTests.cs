using System;
using Learning.SortingAlgorithms;
using NUnit.Framework;

namespace Learning.SortingAlgorithmsTest
{
    [TestFixture]
    public class LomutoQuickSortTests
    {
        private readonly LomutoQuickSort<int> _quickSort;

        public LomutoQuickSortTests()
        {
            _quickSort = new LomutoQuickSort<int>();
        }

        [Test]
        public void LomutoQuickSortOfIntsTests()
        {
            var array = new[] { 10, 4, 6, 7, 8, 5, 3, 2, 1, 9 };
            _quickSort.Sort(array, 0, array.Length - 1);

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
        public void TestLomutoQuickSortOfObjects()
        {
            SortObject[] array = {
                new SortObject { Name = "10", Value = 10},
                new SortObject { Name = "4", Value = 4},
                new SortObject { Name = "6", Value = 6},
                new SortObject { Name = "7", Value = 7},
                new SortObject { Name = "8", Value = 8},
                new SortObject { Name = "5", Value = 5},
                new SortObject { Name = "3", Value = 3},
                new SortObject { Name = "2", Value = 2},
                new SortObject { Name = "1", Value = 1},
                new SortObject { Name = "9", Value = 9}
            };

            var quickSort = new LomutoQuickSort<SortObject>();
            quickSort.Sort(array, 0, array.Length - 1);

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
        public void TestLomutoQuickSortOfIntsBigLength()
        {
            var random = new Random();
            var array = new int[200000];
            int min = 0;
            int max = 200000;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(min, max);
            }
            _quickSort.Sort(array, 0, array.Length - 1);

            for (int j = 0; j < array.Length - 1; j++)
            {
                Assert.LessOrEqual(array[j], array[j + 1]);
            }
        }
    }
}
