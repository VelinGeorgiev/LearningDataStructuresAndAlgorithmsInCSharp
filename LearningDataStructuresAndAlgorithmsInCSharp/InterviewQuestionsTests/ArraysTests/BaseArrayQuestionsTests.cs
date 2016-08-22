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

        [Test]
        public void FindMaxSum()
        {
            int[] arr = new int[] { 5, 5, 10, 100, 10, 5 };
            Assert.AreEqual(_ba.FindMaxSum(arr), 110);
        }

        [Test]
        public void FindCountUpto()
        {
            Assert.AreEqual(_ba.FindCountUpto(2), 9);
        }

        [Test]
        public void ReverseArray()
        {
            int[] arr = new int[] { 1,2,3,4,5,6 };
            _ba.ReverseArray(arr,arr.Length,0,4);
            Assert.AreEqual(arr[0], 4);
        }

        [Test]
        public void FlipBits()
        {
            var a = 73; //1001001;
            var b = 21; //0010101;
            var result = _ba.FlipBits(a,b); //1011100
            Assert.AreEqual(result, 4);
        }

        [Test]
        public void GetMissingNo()
        {
            int[] arr = new int[] { 1, 2, 3, 5, 6 };
            var result = _ba.GetMissingNo(arr, arr.Length);
            Assert.AreEqual(result, 4);
        }

        [Test]
        public void Permute()
        {
            char[] arr = {'a', 'b', 'c'};
            IList<char[]> list = new List<char[]>();
             _ba.Permute(arr, 0, arr.Length-1, list);

            Assert.AreEqual(list[5][0], 'c'); // todo: fix this
            Assert.AreEqual(list[5][1], 'a');
            Assert.AreEqual(list[5][2], 'b');
        }

        [Test]
        public void LeftRotate()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            _ba.LeftRotate(arr, 2, 7);
            Assert.AreEqual(arr[6], 2);
        }

        [Test]
        public void LeftRotate2()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            _ba.LeftRotate2(arr, 2);
            Assert.AreEqual(arr[6], 2);
        }

        [Test]
        public void LeftRotate21()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };
            _ba.LeftRotate2(arr, 3);
            Assert.AreEqual(arr[0], 4);
            Assert.AreEqual(arr[7], 3);
        }

        [Test]
        public void LeftRotate3()
        {
            int[] arr = {1, 2, 3, 4, 5, 6, 7, 8};
            _ba.LeftRotate3(arr, 3);
            Assert.AreEqual(arr[0], 4);
            Assert.AreEqual(arr[7], 3);
        }

    }
}
