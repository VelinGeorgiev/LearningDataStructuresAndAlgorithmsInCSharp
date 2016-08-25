using System.Collections.Generic;
using Learning.InterviewQuestions.LinkedLists;
using NUnit.Framework;

namespace Learning.InterviewQuestionsTests.LinkedLists
{
    [TestFixture]
    public class TwoNodeLinkedListTests
    {
        private readonly TwoNodeLinkedList _llist;

        public TwoNodeLinkedListTests()
        {
            _llist = new TwoNodeLinkedList();
        }

        [Test]
        public void Clone()
        {
            _llist.head = new TwoNode(5);
            _llist.AddFirst(4);
            _llist.AddFirst(3);
            _llist.AddFirst(2);
            _llist.AddFirst(1);

            // Setting up random references.
            _llist.head.down = _llist.head.next.next;
            _llist.head.next.down = _llist.head.next.next.next;
            _llist.head.next.next.down = _llist.head.next.next.next.next;
            _llist.head.next.next.next.down = _llist.head.next.next.next.next.next;
            _llist.head.next.next.next.next.down = _llist.head.next;
            
            // Making a clone of the original linked list.
            TwoNodeLinkedList clone = _llist.Clone();

            Dictionary<int, int> orig = new Dictionary<int, int>();
            Dictionary<int, int> result = new Dictionary<int, int>();

            _llist.Print(orig);
            clone.Print(result);

            Assert.AreEqual(_llist.head.data, clone.head.data);
            Assert.AreEqual(_llist.head.down.data, clone.head.down.data);

            Assert.AreEqual(_llist.head.next.data, clone.head.next.data);
            Assert.AreEqual(_llist.head.next.down.data, clone.head.next.down.data);
        }

        [Test]
        public void Flatten()
        {
           //TODO:
        }
    }
}

