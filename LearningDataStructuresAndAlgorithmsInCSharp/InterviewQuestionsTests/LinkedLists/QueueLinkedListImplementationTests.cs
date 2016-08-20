using Learning.InterviewQuestions.LinkedLists;
using NUnit.Framework;

namespace Learning.InterviewQuestionsTests.LinkedLists
{
    [TestFixture]
    public class QueueLinkedListImplementationTests
    {
        private readonly QueueLinkedListImplementation _queue;

        public QueueLinkedListImplementationTests()
        {
            _queue = new QueueLinkedListImplementation();
        }

        [Test]
        public void TestQueue()
        {
            _queue.Enqueue(10);
            _queue.Enqueue(20);
            _queue.Enqueue(30);
            _queue.Enqueue(40);
            _queue.Enqueue(50);
            var list = _queue.PrintQueue();
            Assert.AreEqual(list[0], 10);
            Assert.AreEqual(list[4], 50);

            _queue.Dequeue();
            _queue.Dequeue();
            var list1 = _queue.PrintQueue();
            Assert.AreEqual(list1[0], 30);
        }
    }
}

