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
    }
}
