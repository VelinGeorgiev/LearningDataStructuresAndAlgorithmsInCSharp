using System.Collections.Generic;
using NUnit.Framework;

namespace Learning.DataStructuresTests
{
    [TestFixture]
    public class LinkedListsTests
    {
        [Test]
        public void TestEnumerateOverLinkedList()
        {
            var linkedList = new LinkedList<int>();
            linkedList.AddLast(1);
            linkedList.AddLast(3);
            linkedList.AddLast(2);
            linkedList.AddLast(5);
            linkedList.AddLast(4);
            linkedList.AddLast(7);
            linkedList.AddLast(8);
            linkedList.AddLast(6);
            linkedList.AddLast(10);
            linkedList.AddLast(9);

            var list = new List<int>();
            var linkedListIterator = linkedList.GetEnumerator();
            while (linkedListIterator.MoveNext())
            {
                list.Add(linkedListIterator.Current);
            }
            Assert.AreEqual(list[0], 1);
            Assert.AreEqual(list[1], 3);
            Assert.AreEqual(list[2], 2);
            Assert.AreEqual(list[3], 5);
            Assert.AreEqual(list[4], 4);
            Assert.AreEqual(list[5], 7);
            Assert.AreEqual(list[6], 8);
            Assert.AreEqual(list[7], 6);
            Assert.AreEqual(list[8], 10);
            Assert.AreEqual(list[9], 9);
        }

        [Test]
        public void TestIterateOverNextLinkedList()
        {
            var linkedList = new LinkedList<int>();
            linkedList.AddLast(1);
            linkedList.AddLast(3);
            linkedList.AddLast(2);
            linkedList.AddLast(5);
            linkedList.AddLast(4);
            linkedList.AddLast(7);
            linkedList.AddLast(8);
            linkedList.AddLast(6);
            linkedList.AddLast(10);
            linkedList.AddLast(9);

            var list = new List<int>();

            var node = linkedList.First;
            list.Add(node.Value);

            while (node != null && node.Next != null)
            {
                node = node.Next;
                list.Add(node.Value);
            }

            Assert.AreEqual(list[0], 1);
            Assert.AreEqual(list[1], 3);
            Assert.AreEqual(list[2], 2);
            Assert.AreEqual(list[3], 5);
            Assert.AreEqual(list[4], 4);
            Assert.AreEqual(list[5], 7);
            Assert.AreEqual(list[6], 8);
            Assert.AreEqual(list[7], 6);
            Assert.AreEqual(list[8], 10);
            Assert.AreEqual(list[9], 9);
        }
    }
}
