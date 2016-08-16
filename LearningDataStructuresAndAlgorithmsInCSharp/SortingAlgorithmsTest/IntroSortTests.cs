using System;
using Learning.SortingAlgorithms;
using NUnit.Framework;

namespace Learning.SortingAlgorithmsTest
{
    [TestFixture]
    public class IntroSortTests
    {
        private readonly IntroSort<int> _introSort;

        public IntroSortTests()
        {
            _introSort = new IntroSort<int>();
        }

        [Test]
        public void IntroSortOfInts()
        {
            var array = new[] {10, 4, 6, 7, 8, 5, 3, 2, 1, 9};
            _introSort.Sort(array, 0, array.Length-1, 1);

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
        public void IntroSortOfIntsBigLength()
        {
            var random = new Random();
            var array = new int[200000];
            int min = 0;
            int max = 200000;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(min, max);
            }
            _introSort.Sort(array, 0, array.Length-1, 1);

            for (int j = 0; j < array.Length - 1; j++)
            {
                Assert.LessOrEqual(array[j], array[j + 1]);
            }
        }
    }
}
