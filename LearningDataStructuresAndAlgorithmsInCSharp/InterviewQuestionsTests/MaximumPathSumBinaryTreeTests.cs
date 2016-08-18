using Learning.DataStructures;
using Learning.InterviewQuestions;
using NUnit.Framework;

namespace Learning.InterviewQuestionsTests
{
    [TestFixture]
    public class MaximumPathSumBinaryTreeTests
    {
        [Test]
        public void MaximumPathSumRecursive()
        {
            MaximumPathSumBinaryTree tree = new MaximumPathSumBinaryTree();
            tree.Root = new Node(10);
            tree.Root.Left = new Node(2);
            tree.Root.Right = new Node(10);
            tree.Root.Left.Left = new Node(20);
            tree.Root.Left.Right = new Node(1);
            tree.Root.Right.Right = new Node(-25);
            tree.Root.Right.Right.Left = new Node(3);
            tree.Root.Right.Right.Right = new Node(4);

            var result = tree.FindMaxSum(tree.Root);
            Assert.AreEqual(result, 42);
        }

        [Test]
        public void MaximumPathSumRecursive2()
        {
            MaximumPathSumBinaryTree tree = new MaximumPathSumBinaryTree();
            tree.Root = new Node(10);
            tree.Root.Left = new Node(4);
            tree.Root.Left.Left = new Node(20);
            tree.Root.Left.Right = new Node(21);
            tree.Root.Right = new Node(3);

            var result = tree.FindMaxSum(tree.Root);
            Assert.AreEqual(result, 45);
        }

        [Test]
        public void MaximumPathSumRecursive3()
        {
            MaximumPathSumBinaryTree tree = new MaximumPathSumBinaryTree();
            tree.Root = new Node(10);
            tree.Root.Left = new Node(4);
            tree.Root.Left.Left = new Node(20);
            tree.Root.Left.Right = new Node(21);
            tree.Root.Right = new Node(3);
            tree.Root.Right.Left = new Node(8);

            var result = tree.FindMaxSum(tree.Root);
            Assert.AreEqual(result, 46);
        }
    }
}
