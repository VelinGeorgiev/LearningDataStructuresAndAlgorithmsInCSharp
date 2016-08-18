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
            _tree.Root = new Node(1);
            _tree.Root.Left = new Node(2);
            _tree.Root.Right = new Node(3);
            _tree.Root.Left.Left = new Node(4);
            _tree.Root.Left.Right = new Node(5);
        }

        [Test]
        public void InorderDepthFirstTraversal()
        {
            var result = new List<Node>();
            _tree.InorderDepthFirstTraversal(_tree.Root, result);

            Assert.AreEqual(result[0].Data, 4);
            Assert.AreEqual(result[1].Data, 2);
            Assert.AreEqual(result[2].Data, 5);
            Assert.AreEqual(result[3].Data, 1);
            Assert.AreEqual(result[4].Data, 3);
        }

        [Test]
        public void PreorderDepthFirstTraversal()
        {
            var result = new List<Node>();
            _tree.PreorderDepthFirstTraversal(_tree.Root, result);

            Assert.AreEqual(result[0].Data, 1);
            Assert.AreEqual(result[1].Data, 2);
            Assert.AreEqual(result[2].Data, 4);
            Assert.AreEqual(result[3].Data, 5);
            Assert.AreEqual(result[4].Data, 3);
        }

        [Test]
        public void PostorderDepthFirstTraversal()
        {
            var result = new List<Node>();
            _tree.PostorderDepthFirstTraversal(_tree.Root, result);

            Assert.AreEqual(result[0].Data, 4);
            Assert.AreEqual(result[1].Data, 5);
            Assert.AreEqual(result[2].Data, 2);
            Assert.AreEqual(result[3].Data, 3);
            Assert.AreEqual(result[4].Data, 1);
        }
    }
}
