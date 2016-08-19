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
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);
            
            Assert.IsTrue(tree.IsFullBinaryTree(tree.root));
        }

        [Test]
        public void IsFullBinaryTreeTest2()
        {
            FullBinaryTree tree = new FullBinaryTree();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);

            Assert.IsFalse(tree.IsFullBinaryTree(tree.root));
        }


    }
}
