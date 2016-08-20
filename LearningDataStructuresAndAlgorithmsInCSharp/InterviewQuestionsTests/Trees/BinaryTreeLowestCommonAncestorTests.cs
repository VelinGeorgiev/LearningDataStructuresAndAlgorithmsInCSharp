using Learning.DataStructures;
using Learning.InterviewQuestions.Trees;
using NUnit.Framework;

namespace Learning.InterviewQuestionsTests.Trees
{
    [TestFixture]
    public class BinaryTreeLowestCommonAncestorTests
    {
        [Test]
        public void FindLca()
        {
            BinaryTreeLowestCommonAncestor tree = new BinaryTreeLowestCommonAncestor();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);
            tree.root.right.left = new Node(6);
            tree.root.right.right = new Node(7);

            Assert.AreEqual(tree.FindLca(tree.root, 4, 5).data, 2);
            Assert.AreEqual(tree.FindLca(tree.root, 4, 6).data, 1);
            Assert.AreEqual(tree.FindLca(tree.root, 3, 4).data, 1);
            Assert.AreEqual(tree.FindLca(tree.root, 2, 4).data, 2);
        }

        [Test]
        public void FindLca2()
        {
            BinaryTreeLowestCommonAncestor tree = new BinaryTreeLowestCommonAncestor();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);
            tree.root.right.left = new Node(6);
            tree.root.right.right = new Node(7);

            Assert.AreEqual(tree.FindLca(4, 5).data, 2);
            Assert.AreEqual(tree.FindLca(4, 6).data, 1);
            Assert.AreEqual(tree.FindLca(4, 10), null);
        }

        [Test]
        public void FindLcainBst()
        {
            BinaryTreeLowestCommonAncestor tree = new BinaryTreeLowestCommonAncestor();
            tree.root = new Node(20);
            tree.root.left = new Node(8);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(12);
            tree.root.left.right.left = new Node(10);
            tree.root.left.right.right = new Node(14);
            tree.root.right = new Node(22);

            Assert.AreEqual(tree.FindLcainBst(tree.root, 10, 14).data, 12);
            Assert.AreEqual(tree.FindLcainBst(tree.root, 14, 8).data, 8);
            Assert.AreEqual(tree.FindLcainBst(tree.root, 10, 22).data, 20);
        }
    }
}
