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
            tree.Root = new Node(1);
            tree.Root.Left = new Node(2);
            tree.Root.Right = new Node(3);
            tree.Root.Left.Left = new Node(4);
            tree.Root.Left.Right = new Node(5);

            var depth = tree.MinimumDepthRecursive();
            Console.Write(depth);
            Assert.AreEqual(depth, 2);
            //System.out.println("The minimum depth of " + "binary tree is : " + tree.minimumDepth());
        }

        [Test]
        public void FindMinimumDepthOfABinaryTreeRecursive2()
        {
            BinaryTreeMinDepth tree = new BinaryTreeMinDepth();
            tree.Root = new Node(1);
            tree.Root.Left = new Node(2);
            tree.Root.Right = new Node(3);
            tree.Root.Left.Left = new Node(4);
            tree.Root.Left.Right = new Node(5);
            tree.Root.Right.Left = new Node(4);
            tree.Root.Right.Right = new Node(5);

            var depth = tree.MinimumDepthRecursive();
            Console.Write(depth);
            Assert.AreEqual(depth, 3);
            //System.out.println("The minimum depth of " + "binary tree is : " + tree.minimumDepth());
        }


        [Test]
        public void FindMinimumDepthOfABinaryTreeWithQueue()
        {
            BinaryTreeMinDepth tree = new BinaryTreeMinDepth();
            tree.Root = new Node(1);
            tree.Root.Left = new Node(2);
            tree.Root.Right = new Node(3);
            tree.Root.Left.Left = new Node(4);
            tree.Root.Left.Right = new Node(5);

            var depth = tree.LevelOrderTraversalMinimumDepth();
            Console.Write(depth);
            Assert.AreEqual(depth, 2);
            //System.out.println("The minimum depth of " + "binary tree is : " + tree.minimumDepth());
        }

        [Test]
        public void FindMinimumDepthOfABinaryTreeWithQueue2()
        {
            BinaryTreeMinDepth tree = new BinaryTreeMinDepth();
            tree.Root = new Node(1);
            tree.Root.Left = new Node(2);
            tree.Root.Right = new Node(3);
            tree.Root.Left.Left = new Node(4);
            tree.Root.Left.Right = new Node(5);
            tree.Root.Right.Left = new Node(4);
            tree.Root.Right.Right = new Node(5);

            var depth = tree.LevelOrderTraversalMinimumDepth();
            Console.Write(depth);
            Assert.AreEqual(depth, 3);
            //System.out.println("The minimum depth of " + "binary tree is : " + tree.minimumDepth());
        }
    }
}
