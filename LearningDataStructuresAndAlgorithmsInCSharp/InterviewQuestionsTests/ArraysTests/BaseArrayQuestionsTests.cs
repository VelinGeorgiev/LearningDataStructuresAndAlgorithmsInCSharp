using System.Collections.Generic;
using System.Text;
using Learning.DataStructures;
using Learning.InterviewQuestions.Arrays;
using Learning.InterviewQuestions.Trees;
using NUnit.Framework;

namespace Learning.InterviewQuestionsTests.ArraysTests
{
    [TestFixture]
    public class BaseArrayQuestionsTests
    {
        private readonly BaseArrayQuestions _ba;

        public BaseArrayQuestionsTests()
        {
            _ba = new BaseArrayQuestions();
        }

        [Test]
        public void Convert0To5()
        {
           Assert.AreEqual(_ba.Convert0To5(10120), 15125);
        }

        [Test]
        public void RunLengthEncoding()
        {
            Assert.AreEqual(_ba.RunLengthEncoding("wwwwaaadexxxxxx"),  "w4a3d1e1x6");
        }

        [Test]
        public void FloorSqrt()
        {
            Assert.AreEqual(_ba.FloorSqrt(11), 3);
        }



    }
}
