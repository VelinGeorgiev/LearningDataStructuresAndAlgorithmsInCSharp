using Learning.DataStructures;
using Learning.InterviewQuestions.Trees;
using NUnit.Framework;

namespace Learning.InterviewQuestionsTests.Trees
{
    [TestFixture]
    public class MaximumPathSumBinaryTreeTests
    {
        [Test]
        public void MaximumPathSumRecursive()
        {
            MaximumPathSumBinaryTree tree = new MaximumPathSumBinaryTree();
            tree.root = new Node(10);
            tree.root.left = new Node(2);
            tree.root.right = new Node(10);
            tree.root.left.left = new Node(20);
            tree.root.left.right = new Node(1);
            tree.root.right.right = new Node(-25);
            tree.root.right.right.left = new Node(3);
            tree.root.right.right.right = new Node(4);

            var result = tree.FindMaxSum(tree.root);
            Assert.AreEqual(result, 42);
        }

        [Test]
        public void MaximumPathSumRecursive2()
        {
            MaximumPathSumBinaryTree tree = new MaximumPathSumBinaryTree();
            tree.root = new Node(10);
            tree.root.left = new Node(4);
            tree.root.left.left = new Node(20);
            tree.root.left.right = new Node(21);
            tree.root.right = new Node(3);

            var result = tree.FindMaxSum(tree.root);
            Assert.AreEqual(result, 45);
        }

        [Test]
        public void MaximumPathSumRecursive3()
        {
            MaximumPathSumBinaryTree tree = new MaximumPathSumBinaryTree();
            tree.root = new Node(10);
            tree.root.left = new Node(4);
            tree.root.left.left = new Node(20);
            tree.root.left.right = new Node(21);
            tree.root.right = new Node(3);
            tree.root.right.left = new Node(8);

            var result = tree.FindMaxSum(tree.root);
            Assert.AreEqual(result, 46);
        }

        [Test]
        public void MaximumPathSumRecursive4()
        {
            MaximumPathSumBinaryTree tree = new MaximumPathSumBinaryTree();
            tree.root = new Node(-15);
            tree.root.left = new Node(5);
            tree.root.right = new Node(6);
            tree.root.left.left = new Node(-8);
            tree.root.left.right = new Node(1);
            tree.root.left.left.left = new Node(2);
            tree.root.left.left.right = new Node(6);
            tree.root.right.left = new Node(3);
            tree.root.right.right = new Node(9);
            tree.root.right.right.right = new Node(0);
            tree.root.right.right.right.left = new Node(4);
            tree.root.right.right.right.right = new Node(-1);
            tree.root.right.right.right.right.left = new Node(10);

            var result = tree.FindMaxSum(tree.root);
            Assert.AreEqual(result, 27);
        }
        
    }
}
