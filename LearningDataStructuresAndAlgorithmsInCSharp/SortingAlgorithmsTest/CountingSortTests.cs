using Learning.SortingAlgorithms;
using NUnit.Framework;

namespace Learning.SortingAlgorithmsTest
{
    [TestFixture]
    public class CountingSortTests
    {
        private readonly CountingSort _countngSort;

        public CountingSortTests()
        {
            _countngSort = new CountingSort();
        }

        [Test]
        public void CountingSortOfInts()
        {
            var array = new[] {10, 4, 6, 7, 8, 5, 3, 2, 1, 9};
            _countngSort.Sort(array);

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
        public void CountingSortOfInts2()
        {
            var array = new[] { 5, 1, 17, 20, 5, 5, 3, -100 };
            _countngSort.Sort(array);

            Assert.AreEqual(array[0], -100);
            Assert.AreEqual(array[1], 1);
            Assert.AreEqual(array[2], 3);
            Assert.AreEqual(array[3], 5);
            Assert.AreEqual(array[4], 5);
            Assert.AreEqual(array[5], 5);
            Assert.AreEqual(array[6], 17);
            Assert.AreEqual(array[7], 20);
        }

        [Test]
        public void CountingSortOfNegInts()
        {
            var array = new[] { -4, -3, 1, -2 };
            _countngSort.Sort(array);

            Assert.AreEqual(array[0], -4);
            Assert.AreEqual(array[1], -3);
            Assert.AreEqual(array[2], -2);
            Assert.AreEqual(array[3], 1);
        }
    }
}
