using System;
using Learning.InterviewQuestions;
using NUnit.Framework;

namespace Learning.InterviewQuestionsTests
{
    [TestFixture]
    public class TreesTests
    {
        [Test]
        public void FindMinimumDepthOfABinaryTreeRecursive()
        {
            BinaryTree tree = new BinaryTree();
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
            BinaryTree tree = new BinaryTree();
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
            BinaryTree tree = new BinaryTree();
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
            BinaryTree tree = new BinaryTree();
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
