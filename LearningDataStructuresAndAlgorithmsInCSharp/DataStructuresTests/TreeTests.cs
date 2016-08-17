using System.Collections.Generic;
using Learning.DataStructures;
using NUnit.Framework;

namespace Learning.DataStructuresTests
{
    [TestFixture]
    public class TreeTests
    {
        private readonly Tree<int> _tree;

        public TreeTests()
        {
            _tree =
                new Tree<int>(8,
                    new Tree<int>(20,
                        new Tree<int>(1),
                        new Tree<int>(12),
                        new Tree<int>(35)),
                    new Tree<int>(21),
                    new Tree<int>(14,
                        new Tree<int>(24),
                        new Tree<int>(6))
                );
        }

        [Test]
        public void BreadthFirstSearchTraversalTest()
        {
            var result = new List<int>();
            _tree.BreadthFirstSearchTraversal(result);

            Assert.AreEqual(result[0], 8);
            Assert.AreEqual(result[1], 20);
            Assert.AreEqual(result[2], 21);
            Assert.AreEqual(result[3], 14);
            Assert.AreEqual(result[4], 1);
            Assert.AreEqual(result[5], 12);
            Assert.AreEqual(result[6], 35);
            Assert.AreEqual(result[7], 24);
            Assert.AreEqual(result[8], 6);
        }

        [Test]
        public void DepthFirstSearchTraversalWithStackTest()
        {
            var result = new List<int>();
            _tree.DepthFirstSearchTraversalWithStack(result);

            Assert.AreEqual(result[0], 8);
            Assert.AreEqual(result[1], 14);
            Assert.AreEqual(result[2], 6);
            Assert.AreEqual(result[3], 24);
            Assert.AreEqual(result[4], 21);
            Assert.AreEqual(result[5], 20);
            Assert.AreEqual(result[6], 35);
            Assert.AreEqual(result[7], 12);
            Assert.AreEqual(result[8], 1);
        }

        [Test]
        public void DepthFirstSearchTraversalTest()
        {
            var result = new List<int>();
            _tree.DepthFirstSearchTraversal(_tree.Root, result);

            Assert.AreEqual(result[0], 8);
            Assert.AreEqual(result[1], 20);
            Assert.AreEqual(result[2], 1);
            Assert.AreEqual(result[3], 12);
            Assert.AreEqual(result[4], 35);
            Assert.AreEqual(result[5], 21);
            Assert.AreEqual(result[6], 14);
            Assert.AreEqual(result[7], 24);
            Assert.AreEqual(result[8], 6);
        }
    }
}
