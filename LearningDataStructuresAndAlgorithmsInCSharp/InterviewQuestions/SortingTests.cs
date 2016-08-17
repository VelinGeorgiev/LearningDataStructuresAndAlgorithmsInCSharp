using NUnit.Framework;

namespace Learning.InterviewQuestions
{
    [TestFixture]
    public class SortingTests
    {
        /// <summary>
        /// You are given two sorted arrays, A and B, and A has a large enough bufer at the end
        //to hold B. Write a method to merge B into A in sorted order.
        /// </summary>
        [Test]
        public void MergeSortedArrays()
        {
            int[] temp = new int[] { 1, 2, 3, 4, 5, 6, 6, 7, 7, 8 };
            int[] a = new int[14];
            for (int x = 0; x < temp.Length; x++)
            {
                a[x] = temp[x];
            }
            
            int[] b = new[] {6, 8, 9, 10};
            int n = 10;
            int m = 4;

            //This code is a part of the standard merge-sort code. We merge A and B from the back, by comparing each element.
            int k = n + m - 1; // Index of last location of array b
            int i = n - 1; // Index of last element in array b
            int j = m - 1; // Index of last element in array a

            // Start comparing from the last element and merge a and b
            while (i >= 0 && j >= 0)
            {
                if (a[i] > b[j])
                {
                    a[k--] = a[i--];
                    }
                else
                {
                    a[k--] = b[j--];
                    }
                }
            while (j >= 0)
            {
                a[k--] = b[j--];
            }

            Assert.AreEqual(a[0], 1);
            Assert.AreEqual(a[1], 2);
            Assert.AreEqual(a[2], 3);
            Assert.AreEqual(a[3], 4);
            Assert.AreEqual(a[4], 5);
            Assert.AreEqual(a[5], 6);
            Assert.AreEqual(a[6], 6);
            Assert.AreEqual(a[7], 6);
            Assert.AreEqual(a[8], 7);
            Assert.AreEqual(a[9], 7);

            Assert.AreEqual(a[10], 8);
            Assert.AreEqual(a[11], 8);
            Assert.AreEqual(a[12], 9);
            Assert.AreEqual(a[13], 10);
        }
    }
}
