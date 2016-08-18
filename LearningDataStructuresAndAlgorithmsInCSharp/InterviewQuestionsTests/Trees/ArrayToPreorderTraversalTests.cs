using System;
using Learning.DataStructures;
using Learning.InterviewQuestions.Trees;
using NUnit.Framework;

namespace Learning.InterviewQuestionsTests.Trees
{
    [TestFixture]
    public class ArrayToPreorderTraversalTests
    {
        [Test]
        public void ArrayToPreorderTraversal()
        {
            ArrayToPreorderTraversal bst = new ArrayToPreorderTraversal();
            int[] array = { 2,4,3 };
            Assert.IsTrue(bst.CanRepresentBst(array, array.Length));
        }

        [Test]
        public void ArrayToPreorderTraversal2()
        {
            ArrayToPreorderTraversal bst = new ArrayToPreorderTraversal();
            int[] array = { 2, 4, 1 };
            Assert.IsFalse(bst.CanRepresentBst(array, array.Length));
        }

        [Test]
        public void ArrayToPreorderTraversal22()
        {
            ArrayToPreorderTraversal bst = new ArrayToPreorderTraversal();
            int[] array = { 2, 1, 4 };
            Assert.IsTrue(bst.CanRepresentBst(array, array.Length));
        }


        [Test]
        public void ArrayToPreorderTraversal3()
        {
            ArrayToPreorderTraversal bst = new ArrayToPreorderTraversal();
            int[] array = { 40, 30, 35, 80, 100 };
            Assert.IsTrue(bst.CanRepresentBst(array, array.Length));
        }

        [Test]
        public void ArrayToPreorderTraversal4()
        {
            ArrayToPreorderTraversal bst = new ArrayToPreorderTraversal();
            int[] array = { 40, 30, 35, 20, 80, 100 };
            Assert.IsFalse(bst.CanRepresentBst(array, array.Length));
        }
    }
}
