using Learning.InterviewQuestions.DynamicProgramming;
using NUnit.Framework;

namespace Learning.InterviewQuestionsTests.DynamicTests
{
    [TestFixture]
    public class BaseDynamicQuestionsTests
    {
        private BaseDynamicQuestions _dynamic;

        public BaseDynamicQuestionsTests()
        {
            _dynamic = new BaseDynamicQuestions();
        }

        [Test]
        public void NumberOfPaths()
        {
            Assert.AreEqual( _dynamic.NumberOfPaths(4, 4), 20);
            Assert.AreEqual(_dynamic.NumberOfPaths(4, 4), 20);
        }
    }
}
