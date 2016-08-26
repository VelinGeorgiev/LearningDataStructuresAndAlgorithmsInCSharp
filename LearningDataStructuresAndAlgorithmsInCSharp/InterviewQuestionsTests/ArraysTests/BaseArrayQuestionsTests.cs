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

        [Test]
        public void MaxSum()
        {
            int[] arr = { 8, 3, 1, 2 };
            Assert.AreEqual(_ba.RotationsMaximumSum(arr, arr.Length), 29);
        }

        [Test]
        public void ArrayMaxLenTo0()
        {
            int[] arr = { 15, -2, 2, -8, 1, 7, 10, 23 };
            Assert.AreEqual(_ba.ArrayMaxLenTo0(arr), 5);
        }

        [Test]
        public void MaxPathSum()
        {
            int[] ar1 = { 2, 3, 7, 10, 12, 15, 30, 34 };
            int[] ar2 = { 1, 5, 7, 8, 10, 15, 16, 19 };
            int m = ar1.Length;
            int n = ar2.Length;
            Assert.AreEqual(_ba.MaxPathSum(ar1,ar2,m,n), 122);
        }

        [Test]
        public void TransitionPoint()
        {
            int[] ar1 = { 0, 0, 0, 1, 1 };
            int m = ar1.Length;
            Assert.AreEqual(_ba.TransitionPoint(ar1,m), 3);
        }

        [Test]
        public void TransitionPoint2()
        {
            int[] ar1 = { 0, 0, 0, 0, 1 };
            int m = ar1.Length;
            Assert.AreEqual(_ba.TransitionPoint(ar1, m), 4);
        }

        [Test]
        public void TransitionPoint3()
        {
            int[] ar1 = { 0, 0, 1, 1, 1 };
            int m = ar1.Length;
            Assert.AreEqual(_ba.TransitionPoint(ar1, m), 2);
        }

        [Test]
        public void NextGreaterElement()
        {
            int[] arr = { 11, 13, 21, 3 };
            int n = arr.Length;
            var dict = new Dictionary<int,int>();
            _ba.NextGreaterElement(arr, n, dict);

            Assert.AreEqual(dict[11], 13);
            Assert.AreEqual(dict[13], 21);
            Assert.AreEqual(dict[3], -1);
            Assert.AreEqual(dict[21], -1);
        }

        [Test]
        public void SubArraySum()
        {
            int[] arr = { 15, 2, 4, 8, 9, 5, 10, 23 };
            int n = arr.Length;
            int sum = 23;
            Assert.IsTrue(_ba.SubArraySum(arr, n, sum));
        }

        [Test]
        public void HasArrayTwoCandidates()
        {
            int[] a = { 1, 4, 45, 6, 10, -8 };
            int n = 16;
            int arrSize = 6;
            Assert.IsTrue(_ba.HasArrayTwoCandidates(a, arrSize, n));
        }

        [Test]
        public void ZigZagArray()
        {
            int[] arr = { 4, 3, 7, 8, 6, 2, 1 };
            int n = arr.Length;
            _ba.ZigZagArray(arr, n);

            Assert.AreEqual(arr[0], 3);
            Assert.AreEqual(arr[1], 7);
            Assert.AreEqual(arr[2], 4);
            Assert.AreEqual(arr[3], 8);
            Assert.AreEqual(arr[4], 2);
            Assert.AreEqual(arr[5], 6);
            Assert.AreEqual(arr[6], 1);
        }

        [Test]
        public void PrintLeaders()
        {
            int[] arr = { 16, 17, 4, 3, 5, 2 };
            int n = arr.Length;
            var res= new List<int>();
            _ba.PrintLeaders(arr, n, res);

            Assert.AreEqual(res[0], 2);
            Assert.AreEqual(res[1], 5);
            Assert.AreEqual(res[2], 17);
        }

        [Test]
        public void NextGreatest()
        {
            int[] arr = { 16, 17, 4, 3, 5, 2 };
            _ba.NextGreatest(arr); 

            Assert.AreEqual(arr[0], 17);
            Assert.AreEqual(arr[1], 5);
            Assert.AreEqual(arr[2], 5);
            Assert.AreEqual(arr[3], 5);
            Assert.AreEqual(arr[4], 2);
            Assert.AreEqual(arr[5], -1);
        }

        [Test]
        public void FindTwoOddNumbers()
        {
            int[] arr = new[] {12, 23, 34, 12, 12, 23, 12, 45};
            IList<int> result = new List<int>();

            _ba.FindTwoOddNumbers(arr, result);

            Assert.AreEqual(result[0], 34);
            Assert.AreEqual(result[1], 45);
        }

        [Test]
        public void FindTwoOddNumbers3()
        {
            int[] arr = new[] { 12, 23, 34, 12, 12, 23, 12, 45, 34, 34 };
            IList<int> result = new List<int>();

            _ba.FindTwoOddNumbers(arr, result);

            Assert.AreEqual(result[0], 34);
            Assert.AreEqual(result[1], 45);
        }

        [Test]
        public void FindTwoOddNumbers2()
        {
            int[] arr = new[] { 1, 1, 2, 3, 3, -4, 5, 5 };
            IList<int> result = new List<int>();

            _ba.FindTwoOddNumbers(arr, result);

            Assert.AreEqual(result[0], 2);
            Assert.AreEqual(result[1], -4);
        }

        [Test]
        public void FindTwoOddNumbersWithSort()
        {
            int[] arr = new[] { 12, 23, 34, 12, 12, 23, 12, 45 };
            IList<int> result = new List<int>();

            _ba.FindTwoOddNumbersWithSort(arr, result);

            Assert.AreEqual(result[0], 34);
            Assert.AreEqual(result[1], 45);
        }

        [Test]
        public void FindTwoOddNumbersWithSort2()
        {
            int[] arr = new[] { 1,1,2,3,3,-4,5,5 };
            IList<int> result = new List<int>();

            _ba.FindTwoOddNumbersWithSort(arr, result);

            Assert.AreEqual(result[0], -4);
            Assert.AreEqual(result[1], 2);
        }

        [Test]
        public void FindTwoOddNumbersWithSort3()
        {
            int[] arr = new[] { 12, 23, 34, 12, 12, 23, 12, 45, 34, 34 };
            IList<int> result = new List<int>();

            _ba.FindTwoOddNumbers(arr, result);

            Assert.AreEqual(result[0], 34);
            Assert.AreEqual(result[1], 45);
        }

        [Test]
        public void PrintNge()
        {
            int[] arr = { 11, 13, 21, 3 };
            IDictionary<int, int> result = new Dictionary<int, int>();

            _ba.PrintNge(arr, result);

            Assert.AreEqual(result[11], 13);
            Assert.AreEqual(result[13], 21);
            Assert.AreEqual(result[21], -1);
            Assert.AreEqual(result[3], -1);
        }

        [Test]
        public void Sort012()
        {
            int[] arr = { 0, 1, 1, 0, 1, 2, 1, 2, 0, 0, 0, 1 };
            int arrSize = arr.Length;
            _ba.Sort012(arr, arrSize);

            Assert.AreEqual(arr[0], 0);
            Assert.AreEqual(arr[11], 2);
        }


        [Test]
        public void MajorityElementHash()
        {
            int[] a = { 1, 3, 3, 1, 2, 3 };
            Assert.AreEqual(_ba.MajorityElementHash(a), 3);
        }

        [Test]
        public void MajorityElementHash2()
        {
            int[] a = { 1, 3, 3, 1, 2, 2 };
            Assert.AreEqual(_ba.MajorityElementHash(a), 0);
        }

        [Test]
        public void PushZerosToEnd()
        {
            int[] arr = { 1, 9, 8, 4, 0, 0, 2, 7, 0, 6, 0, 9 };
            int n = arr.Length;
            _ba.PushZerosToEnd(arr, n);
            Assert.AreEqual(arr[10], 0);
            Assert.AreEqual(arr[11], 0);
        }

        [Test]
        public void IsTriplet()
        {
            int[] arr = { 3, 1, 4, 6, 5 };
            int n = arr.Length;
            Assert.IsTrue(_ba.IsTriplet(arr, n));
        }


        [Test]
        public void FindLongestConseqSubseq()
        {
            int[] arr = { 1, 9, 3, 10, 4, 20, 2 };
            int n = arr.Length;
            Assert.AreEqual(_ba.FindLongestConseqSubseq(arr, n), 4);
        }
        
    }
}
