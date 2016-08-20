using System.Collections.Generic;
using Learning.DataStructures;
using Learning.InterviewQuestions.Trees;
using NUnit.Framework;

namespace Learning.InterviewQuestionsTests.Trees
{
    [TestFixture]
    public class BinaryTreeBoundaryTests
    {
        [Test]
        public void PrintBoundary()
        {
            BinaryTreeBoundary tree = new BinaryTreeBoundary();
            tree.root = new Node(20);
            tree.root.left = new Node(8);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(12);
            tree.root.left.right.left = new Node(10);
            tree.root.left.right.right = new Node(14);
            tree.root.right = new Node(22);
            tree.root.right.right = new Node(25);

            tree.PrintBoundary(tree.root);

            Assert.AreEqual(tree.Output[0], 20);
            Assert.AreEqual(tree.Output[1], 8);
            Assert.AreEqual(tree.Output[2], 4);
            Assert.AreEqual(tree.Output[3], 10);
            Assert.AreEqual(tree.Output[4], 14);
            Assert.AreEqual(tree.Output[5], 25);
            Assert.AreEqual(tree.Output[6], 22);
        }
    }
}
