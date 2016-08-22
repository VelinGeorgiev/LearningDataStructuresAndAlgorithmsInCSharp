using Learning.DataStructures.LinkedList;
using Learning.InterviewQuestions.LinkedLists;
using NUnit.Framework;

namespace Learning.InterviewQuestionsTests.LinkedLists
{
    [TestFixture]
    public class BaseLinkedListsTests
    {
        private readonly BaseLinkedLists _bll;

        public BaseLinkedListsTests()
        {
            _bll = new BaseLinkedLists();
        }

        [Test]
        public void PrintMiddle()
        {
            _bll.head = new Node(1);
            _bll.head.next = new Node(2);
            _bll.head.next.next = new Node(3);
            _bll.head.next.next.next = new Node(4);
            _bll.head.next.next.next.next = new Node(5);
            _bll.PrintMiddle();

            Assert.AreEqual(_bll.output[0], 3);
        }

        [Test]
        public void RemoveKthNode()
        {
            _bll.head = new Node(1);
            _bll.head.next = new Node(2);
            _bll.head.next.next = new Node(3);
            _bll.head.next.next.next = new Node(4);
            _bll.head.next.next.next.next = new Node(5);
            _bll.head.next.next.next.next.next = new Node(6);

            _bll.RemoveKthNode(_bll.head, 2);

            Assert.AreEqual(_bll.head.data, 1);
            Assert.AreEqual(_bll.head.next.data, 3);
            Assert.AreEqual(_bll.head.next.next.data, 5);
        }

        [Test]
        public void RemoveKthNode2()
        {
            _bll.head = new Node(1);
            _bll.head.next = new Node(2);
            _bll.head.next.next = new Node(3);
            _bll.head.next.next.next = new Node(4);
            _bll.head.next.next.next.next = new Node(5);
            _bll.head.next.next.next.next.next = new Node(6);

            _bll.RemoveKthNode(_bll.head, 3);

            Assert.AreEqual(_bll.head.data, 1);
            Assert.AreEqual(_bll.head.next.data, 2);
            Assert.AreEqual(_bll.head.next.next.data, 4);
            Assert.AreEqual(_bll.head.next.next.next.data, 5);
        }
    }
}

