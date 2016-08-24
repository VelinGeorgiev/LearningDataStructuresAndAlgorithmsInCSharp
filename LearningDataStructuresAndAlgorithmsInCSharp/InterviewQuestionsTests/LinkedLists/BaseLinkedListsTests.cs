using System.Collections.Generic;
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

        [Test]
        public void PrintNthFromLast()
        {
            _bll.head = new Node(1);
            _bll.head.next = new Node(2);
            _bll.head.next.next = new Node(3);
            _bll.head.next.next.next = new Node(4);
            _bll.head.next.next.next.next = new Node(5);
            _bll.head.next.next.next.next.next = new Node(6);
            var list = new List<int>();

            _bll.PrintNthFromLast(2, list);

            Assert.AreEqual(list[0], 5);
        }

        [Test]
        public void IntersectionOfSortedLists()
        {
            var a = new SinglyLinkedList();
            a.head = new Node(1);
            a.head.next = new Node(2);
            a.head.next.next = new Node(3);
            a.head.next.next.next = new Node(4);
            a.head.next.next.next.next = new Node(5);
            a.head.next.next.next.next.next = new Node(6);

            var b = new SinglyLinkedList();
            b.head = new Node(2);
            b.head.next = new Node(4);
            b.head.next.next = new Node(6);
            b.head.next.next.next = new Node(8);
            var result = _bll.IntersectionOfSortedLists(a.head, b.head);

            Assert.AreEqual(result.head.data, 6);
            Assert.AreEqual(result.head.next.data, 4);
            Assert.AreEqual(result.head.next.next.data, 2);
        }

        [Test]
        public void IntersectionOfSortedListsDesc()
        {
            var a = new SinglyLinkedList();
            a.head = new Node(6);
            a.head.next = new Node(5);
            a.head.next.next = new Node(4);
            a.head.next.next.next = new Node(3);
            a.head.next.next.next.next = new Node(2);
            a.head.next.next.next.next.next = new Node(1);

            var b = new SinglyLinkedList();
            b.head = new Node(8);
            b.head.next = new Node(6);
            b.head.next.next = new Node(4);
            b.head.next.next.next = new Node(2);
            var result = _bll.IntersectionOfSortedLists(a.head, b.head);

            Assert.AreEqual(result.head.data, 2);
            Assert.AreEqual(result.head.next.data, 4);
            Assert.AreEqual(result.head.next.next.data, 6);
        }

        [Test]
        public void MergeTwoSortedLinkedListsRecursion()
        {
            var a = new SinglyLinkedList();
            a.head = new Node(5);
            a.head.next = new Node(10);
            a.head.next.next = new Node(15);

            var b = new SinglyLinkedList();
            b.head = new Node(2);
            b.head.next = new Node(3);
            b.head.next.next = new Node(20);
            var result = _bll.MergeTwoSortedLinkedListsRecursion(a.head, b.head);

            Assert.AreEqual(result.data, 2);
            Assert.AreEqual(result.next.data, 3);
            Assert.AreEqual(result.next.next.data, 5);
            Assert.AreEqual(result.next.next.next.data, 10);
            Assert.AreEqual(result.next.next.next.next.data, 15);
            Assert.AreEqual(result.next.next.next.next.next.data, 20);
        }

        [Test]
        public void SortedListAbsoluteValues()
        {
            var a = new SinglyLinkedList();
            a.head = new Node(1);
            a.head.next = new Node(-2);
            a.head.next.next = new Node(3);
            a.head.next.next.next = new Node(4);
            a.head.next.next.next.next = new Node(5);
            a.head.next.next.next.next.next = new Node(-5);

            var result = _bll.SortedListAbsoluteValues(a.head);

            Assert.AreEqual(result.data, -5);
            Assert.AreEqual(result.next.data, -2);
            Assert.AreEqual(result.next.next.data, 1);
            Assert.AreEqual(result.next.next.next.data, 3);
            Assert.AreEqual(result.next.next.next.next.data, 4);
            Assert.AreEqual(result.next.next.next.next.next.data, 5);
        }

        [Test]
        public void DetectLoop()
        {
            _bll.head = new Node(20);
            _bll.head.next = new Node(4);
            _bll.head.next.next = new Node(15);
            _bll.head.next.next.next = new Node(10);

            // Create loop for testing
            _bll.head.next.next.next.next = _bll.head;

            Assert.IsTrue(_bll.DetectLoop());
        }

        [Test]
        public void RearrangeEvenOdd()
        {
            _bll.head = new Node(1);
            _bll.head.next = new Node(2);
            _bll.head.next.next = new Node(3);
            _bll.head.next.next.next = new Node(4);
            var result = _bll.RearrangeEvenOdd(_bll.head);

            // Given Linked List
            // 1->2->3->4->NULL
            // Modified Linked List
            // 1->3->2->4->NULL
            Assert.AreEqual(result.next.data, 3);
            Assert.AreEqual(result.next.next.data, 2);
        }

        [Test]
        public void AddTwoLists()
        {
            var a = new SinglyLinkedList();
            a.head = new Node(7);
           a.head.next = new Node(5);
           a.head.next.next = new Node(9);
           a.head.next.next.next = new Node(4);
           a.head.next.next.next.next = new Node(6);

            var b = new SinglyLinkedList();
            b.head = new Node(8);
            b.head.next = new Node(4);

            // add the two lists and see the result
            Node result = _bll.AddTwoLists(a.head, b.head);

            Assert.AreEqual(result.data, 5);
            Assert.AreEqual(result.next.data, 0);
            Assert.AreEqual(result.next.next.data, 0);
        }

        [Test]
        public void SortListOf012()
        {
            _bll.head = new Node(1);
            _bll.head.next = new Node(2);
            _bll.head.next.next = new Node(0);
            _bll.head.next.next.next = new Node(2);
            _bll.head.next.next.next.next = new Node(1);
             
            // add the two lists and see the result
            _bll.SortListOf012();

            Assert.AreEqual(_bll.head.data, 0);
            Assert.AreEqual(_bll.head.next.data, 1);
            Assert.AreEqual(_bll.head.next.next.data, 1);
            Assert.AreEqual(_bll.head.next.next.next.data, 2);
            Assert.AreEqual(_bll.head.next.next.next.next.data, 2);
        }

        [Test]
        public void PairWiseSwap()
        {
            _bll.head = new Node(1);
            _bll.head.next = new Node(2);
            _bll.head.next.next = new Node(3);
            _bll.head.next.next.next = new Node(4);
            _bll.head.next.next.next.next = new Node(5);

            // add the two lists and see the result
            _bll.PairWiseSwap(_bll.head);

            Assert.AreEqual(_bll.head.data, 2);
            Assert.AreEqual(_bll.head.next.data, 1);
            Assert.AreEqual(_bll.head.next.next.data, 4);
            Assert.AreEqual(_bll.head.next.next.next.data, 3);
            Assert.AreEqual(_bll.head.next.next.next.next.data, 5);
        }

        [Test]
        public void PairWiseSwapRecursion()
        {
            _bll.head = new Node(1);
            _bll.head.next = new Node(2);
            _bll.head.next.next = new Node(3);
            _bll.head.next.next.next = new Node(4);
            _bll.head.next.next.next.next = new Node(5);

            // add the two lists and see the result
            _bll.PairWiseSwapRecursion(_bll.head);

            Assert.AreEqual(_bll.head.data, 2);
            Assert.AreEqual(_bll.head.next.data, 1);
            Assert.AreEqual(_bll.head.next.next.data, 4);
            Assert.AreEqual(_bll.head.next.next.next.data, 3);
            Assert.AreEqual(_bll.head.next.next.next.next.data, 5);
        }

        [Test]
        public void SkipMdeleteN()
        {
            _bll.head = new Node(1);
            _bll.head.next = new Node(2);
            _bll.head.next.next = new Node(3);
            _bll.head.next.next.next = new Node(4);
            _bll.head.next.next.next.next = new Node(5);
            _bll.head.next.next.next.next.next = new Node(6);
            _bll.head.next.next.next.next.next.next = new Node(7);
            _bll.head.next.next.next.next.next.next.next = new Node(8);
            _bll.head.next.next.next.next.next.next.next.next = new Node(9);
            _bll.head.next.next.next.next.next.next.next.next.next = new Node(10);

            // add the two lists and see the result
            _bll.SkipMDeleteN(_bll.head, 2, 3);

            Assert.AreEqual(_bll.head.data, 1);
            Assert.AreEqual(_bll.head.next.data, 2);
            Assert.AreEqual(_bll.head.next.next.data, 6);
            Assert.AreEqual(_bll.head.next.next.next.data, 7);
        }


    }
}

