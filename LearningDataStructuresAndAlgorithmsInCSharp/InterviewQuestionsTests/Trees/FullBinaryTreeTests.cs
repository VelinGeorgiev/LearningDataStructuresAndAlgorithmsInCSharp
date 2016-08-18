using System;
using Learning.DataStructures;
using Learning.InterviewQuestions.Trees;
using NUnit.Framework;

namespace Learning.InterviewQuestionsTests.Trees
{
    [TestFixture]
    public class FullBinaryTreeTests
    {
        [Test]
        public void IsFullBinaryTreeTest()
        {
            FullBinaryTree tree = new FullBinaryTree();
            tree.Root = new Node(1);
            tree.Root.Left = new Node(2);
            tree.Root.Right = new Node(3);
            tree.Root.Left.Left = new Node(4);
            tree.Root.Left.Right = new Node(5);
            
            Assert.IsTrue(tree.IsFullBinaryTree(tree.Root));
        }

        [Test]
        public void IsFullBinaryTreeTest2()
        {
            FullBinaryTree tree = new FullBinaryTree();
            tree.Root = new Node(1);
            tree.Root.Left = new Node(2);
            tree.Root.Right = new Node(3);
            tree.Root.Left.Left = new Node(4);

            Assert.IsFalse(tree.IsFullBinaryTree(tree.Root));
        }


    }
}
