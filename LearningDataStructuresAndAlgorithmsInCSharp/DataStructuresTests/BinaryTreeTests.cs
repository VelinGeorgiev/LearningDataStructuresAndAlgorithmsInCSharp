using System.Collections.Generic;
using Learning.DataStructures;
using NUnit.Framework;

namespace Learning.DataStructuresTests
{
    [TestFixture]
    public class BinaryTreeTests
    {
        private readonly BinaryTree _tree;

        public BinaryTreeTests()
        {
            _tree = new BinaryTree();
            _tree.root = new Node(1);
            _tree.root.left = new Node(2);
            _tree.root.right = new Node(3);
            _tree.root.left.left = new Node(4);
            _tree.root.left.right = new Node(5);
        }

        [Test]
        public void InorderDepthFirstTraversal()
        {
            var result = new List<Node>();
            _tree.InorderDepthFirstTraversal(_tree.root, result);

            Assert.AreEqual(result[0].data, 4);
            Assert.AreEqual(result[1].data, 2);
            Assert.AreEqual(result[2].data, 5);
            Assert.AreEqual(result[3].data, 1);
            Assert.AreEqual(result[4].data, 3);
        }

        [Test]
        public void PreorderDepthFirstTraversal()
        {
            var result = new List<Node>();
            _tree.PreorderDepthFirstTraversal(_tree.root, result);

            Assert.AreEqual(result[0].data, 1);
            Assert.AreEqual(result[1].data, 2);
            Assert.AreEqual(result[2].data, 4);
            Assert.AreEqual(result[3].data, 5);
            Assert.AreEqual(result[4].data, 3);
        }

        [Test]
        public void PostorderDepthFirstTraversal()
        {
            var result = new List<Node>();
            _tree.PostorderDepthFirstTraversal(_tree.root, result);

            Assert.AreEqual(result[0].data, 4);
            Assert.AreEqual(result[1].data, 5);
            Assert.AreEqual(result[2].data, 2);
            Assert.AreEqual(result[3].data, 3);
            Assert.AreEqual(result[4].data, 1);
        }

        [Test]
        public void ReverseLevelOrderTraversalTest()
        {
            _tree.root = new Node(1);
            _tree.root.left = new Node(2);
            _tree.root.right = new Node(3);
            _tree.root.left.left = new Node(4);
            _tree.root.left.right = new Node(5);
            _tree.root.right.left = new Node(6);
            _tree.root.right.right = new Node(7);
            var list = new List<int>();

            _tree.ReverseLevelOrder(_tree.root, list);

            Assert.AreEqual(list[0], 4);
            Assert.AreEqual(list[1], 5);
            Assert.AreEqual(list[2], 6);
            Assert.AreEqual(list[3], 7);
            Assert.AreEqual(list[4], 2);
            Assert.AreEqual(list[5], 3);
            Assert.AreEqual(list[6], 1);
        }

        [Test]
        public void LevelOrderTraversalTest()
        {
            _tree.root = new Node(1);
            _tree.root.left = new Node(2);
            _tree.root.right = new Node(3);
            _tree.root.left.left = new Node(4);
            _tree.root.left.right = new Node(5);
            _tree.root.right.left = new Node(6);
            _tree.root.right.right = new Node(7);
            var list = new List<int>();

            _tree.LevelOrder(_tree.root, list);

            Assert.AreEqual(list[0], 1);
            Assert.AreEqual(list[1], 2);
            Assert.AreEqual(list[2], 3);
            Assert.AreEqual(list[3], 4);
            Assert.AreEqual(list[4], 5);
            Assert.AreEqual(list[5], 6);
            Assert.AreEqual(list[6], 7);
        }

        [Test]
        public void InorderWithStack()
        {
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);

            var list = new List<int>();

            tree.InorderTraversalWithStack(_tree.root, list);

            Assert.AreEqual(list[0], 4);
            Assert.AreEqual(list[1], 2);
            Assert.AreEqual(list[2], 5);
            Assert.AreEqual(list[3], 1);
            Assert.AreEqual(list[4], 3);
        }

        
    }
}
