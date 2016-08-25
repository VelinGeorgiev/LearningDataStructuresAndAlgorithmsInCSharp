using Learning.DataStructures;
using NUnit.Framework;

namespace Learning.DataStructuresTests
{
    [TestFixture]
    public class MinHeapTests
    {
        private readonly MinHeap _heap;

        public MinHeapTests()
        {
            _heap = new MinHeap(11);
        }

        [Test]
        public void BreadthFirstSearchTraversalTest()
        {
            _heap.InsertKey(3);
            _heap.InsertKey(2);
            _heap.DeleteKey(1);
            _heap.InsertKey(15);
            _heap.InsertKey(5);
            _heap.InsertKey(4);
            _heap.InsertKey(45);
            Assert.AreEqual(_heap.ExtractMin(), 2);

            Assert.AreEqual(_heap.GetMin(), 4);
            _heap.DecreaseKey(2, 1);
            Assert.AreEqual(_heap.GetMin(), 1);
        }
    }
}
