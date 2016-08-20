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
    }
}

