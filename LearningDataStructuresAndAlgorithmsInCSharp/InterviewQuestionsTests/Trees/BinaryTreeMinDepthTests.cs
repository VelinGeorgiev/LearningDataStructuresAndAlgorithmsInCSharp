using System;
using Learning.DataStructures;
using Learning.InterviewQuestions.Trees;
using NUnit.Framework;

namespace Learning.InterviewQuestionsTests.Trees
{
    [TestFixture]
    public class BinaryTreeMinDepthTests
    {
        [Test]
        public void FindMinimumDepthOfABinaryTreeRecursive()
        {
            BinaryTreeMinDepth tree = new BinaryTreeMinDepth();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);

            var depth = tree.MinimumDepthRecursive();
            Console.Write(depth);
            Assert.AreEqual(depth, 2);
            //System.out.println("The minimum depth of " + "binary tree is : " + tree.minimumDepth());
        }

        [Test]
        public void FindMinimumDepthOfABinaryTreeRecursive2()
        {
            BinaryTreeMinDepth tree = new BinaryTreeMinDepth();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);
            tree.root.right.left = new Node(4);
            tree.root.right.right = new Node(5);

            var depth = tree.MinimumDepthRecursive();
            Console.Write(depth);
            Assert.AreEqual(depth, 3);
            //System.out.println("The minimum depth of " + "binary tree is : " + tree.minimumDepth());
        }


        [Test]
        public void FindMinimumDepthOfABinaryTreeWithQueue()
        {
            BinaryTreeMinDepth tree = new BinaryTreeMinDepth();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);

            var depth = tree.LevelOrderTraversalMinimumDepth();
            Console.Write(depth);
            Assert.AreEqual(depth, 2);
            //System.out.println("The minimum depth of " + "binary tree is : " + tree.minimumDepth());
        }

        [Test]
        public void FindMinimumDepthOfABinaryTreeWithQueue2()
        {
            BinaryTreeMinDepth tree = new BinaryTreeMinDepth();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);
            tree.root.right.left = new Node(4);
            tree.root.right.right = new Node(5);

            var depth = tree.LevelOrderTraversalMinimumDepth();
            Console.Write(depth);
            Assert.AreEqual(depth, 3);
            //System.out.println("The minimum depth of " + "binary tree is : " + tree.minimumDepth());
        }
    }
}
