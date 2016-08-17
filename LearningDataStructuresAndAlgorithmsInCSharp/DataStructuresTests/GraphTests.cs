using System.Collections.Generic;
using Learning.DataStructures;
using NUnit.Framework;

namespace Learning.DataStructuresTests
{
    [TestFixture]
    public class GraphTests
    {
        private readonly Graph<int> _graph;

        public GraphTests()
        {
            _graph = new Graph<int>(new int[][]
            {
                new int[] {3, 6}, // successors of vertice 0
                new int[] {2, 3, 4, 5, 6}, // successors of vertice 1
                new int[] {1, 4, 5}, // successors of vertice 2
                new int[] {0, 1, 5}, // successors of vertice 3
                new int[] {1, 2, 6}, // successors of vertice 4
                new int[] {1, 2, 3}, // successors of vertice 5
                new int[] {0, 1, 4} // successors of vertice 6
            });
        }

        [Test]
        public void BreadthFirstSearchTraversalTest()
        {
            var result = new List<int>();
            _graph.BreadthFirstSearchTraversal(0, result);

            Assert.AreEqual(result[0], 0);
            Assert.AreEqual(result[1], 3);
            Assert.AreEqual(result[2], 6);
            Assert.AreEqual(result[3], 1);
            Assert.AreEqual(result[4], 5);
            Assert.AreEqual(result[5], 4);
            Assert.AreEqual(result[6], 2);
        }

        [Test]
        public void DepthFirstSearchTraversalWithStackTest()
        {
            var result = new List<int>();
            _graph.DepthFirstSearchTraversalWithStack(0, result);

            Assert.AreEqual(result[0], 0);
            Assert.AreEqual(result[1], 6);
            Assert.AreEqual(result[2], 4);
            Assert.AreEqual(result[3], 2);
            Assert.AreEqual(result[4], 5);
            Assert.AreEqual(result[5], 1);
            Assert.AreEqual(result[6], 3);
        }

        [Test]
        public void DepthFirstSearchTraversalTest()
        {
            var result = new List<int>();
            var visited = new bool[100];
            _graph.DepthFirstSearchTraversal(0, visited, result);

            Assert.AreEqual(result[0], 0);
            Assert.AreEqual(result[1], 3);
            Assert.AreEqual(result[2], 1);
            Assert.AreEqual(result[3], 2);
            Assert.AreEqual(result[4], 4);
            Assert.AreEqual(result[5], 6);
            Assert.AreEqual(result[6], 5);
        }
    }
}
