using Learning.Search;
using NUnit.Framework;

namespace Learning.SearchTests
{
    [TestFixture]
    public class BinarySearchTests
    {
        private readonly BinarySearch<int> _binarySearch;

        public BinarySearchTests()
        {
            _binarySearch = new BinarySearch<int>();
        }

        [TestCase(1)]
        [TestCase(9)]
        [TestCase(20)]
        [TestCase(10)]
        public void ArrayBinarySearchOfInts(int value)
        {
            var array = new[] {1,2,2,2,3,3,4,5,6,7,8,8,8,8,9,9,10,11,17,18,20}; // Must be a sorted array
            var result = _binarySearch.Search(array, value);

            Assert.AreEqual(value, result); // Really dump comparison
        }
    }
}
