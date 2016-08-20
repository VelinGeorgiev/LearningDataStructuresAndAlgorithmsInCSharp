using System.Collections.Generic;
using Learning.InterviewQuestions.Arrays;
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

        [Test]
        public void GeneratePrintBinary()
        {
            var list = new List<string>();
            _ba.GeneratePrintBinary(10, list);
            Assert.AreEqual(list[9], "1010");
        }

        [Test]
        public void NumberOccurringOddNumberTimes()
        {
            int[] ar = { 2, 3, 5, 4, 5, 2, 4, 3, 5, 2, 4, 4, 2 };
            Assert.AreEqual(_ba.NumberOccurringOddNumberTimes(ar), 5);
        }

        [Test]
        public void FindMinDiff()
        {
            int[] arr = { 1, 5, 3, 19, 18, 25 };
            Assert.AreEqual(_ba.FindMinDiff(arr), 1);
        }

        [Test]
        public void KthSmallest()
        {
            int[] arr = { 12, 3, 5, 7, 19 };
            Assert.AreEqual(_ba.KthSmallest(arr, 2), 5);
        }

        [Test]
        public void KthLargest()
        {
            int[] arr = { 12, 3, 5, 7, 19 };
            Assert.AreEqual(_ba.KthLargest(arr, 2), 12);
        }

        [Test]
        public void RemoveDirtyCharacters()
        {
            int[] arr = { 12, 3, 5, 7, 19 };
            Assert.AreEqual(_ba.RemoveDirtyCharacters("geeksforgeeks", "geeks"), "for");
        } 
    }
}
