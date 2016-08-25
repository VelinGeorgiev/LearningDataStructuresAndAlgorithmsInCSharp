using System.Collections.Generic;
using Learning.DataStructures;
using NUnit.Framework;

namespace Learning.DataStructuresTests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        private readonly BinarySearchTree _bst;

        public BinarySearchTreeTests()
        {
            _bst = new BinarySearchTree();
        }

        [Test]
        public void InorderDepthFirstTraversal()
        {
            _bst.root = new Node(50);
            _bst.root.left = new Node(30);
            _bst.root.left.left = new Node(20);
            _bst.root.left.right = new Node(40);
            _bst.root.right = new Node(70);
            _bst.root.right.left = new Node(60);
            _bst.root.right.right = new Node(80);


            _bst.Delete(_bst.root, 20);

            Assert.AreEqual(_bst.root.data, 50);
            Assert.AreEqual(_bst.root.left.data, 30);
            Assert.AreEqual(_bst.root.left.left, null);

            _bst.Delete(_bst.root, 30);
            Assert.AreEqual(_bst.root.left.data, 40);

            _bst.Delete(_bst.root, 50);
            Assert.AreEqual(_bst.root.data, 60);
        }
    }
}
