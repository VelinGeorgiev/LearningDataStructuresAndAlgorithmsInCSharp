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
        public void Convert0To5()
        {
           Assert.AreEqual(_ba.Convert0To5(10120), 15125);
        }
    }
}
