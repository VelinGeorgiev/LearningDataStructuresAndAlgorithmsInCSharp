using System.Collections.Generic;
using Learning.DataStructures;
using Learning.InterviewQuestions.Trees;
using NUnit.Framework;

namespace Learning.InterviewQuestionsTests.Trees
{
    [TestFixture]
    public class BinaryTreeLeftRightViewTests
    {
        [Test]
        public void BinaryTreeLeftView()
        {
            BinaryTreeLeftRightView tree = new BinaryTreeLeftRightView();
            tree.root = new Node(12);
            tree.root.left = new Node(10);
            tree.root.right = new Node(30);
            tree.root.right.left = new Node(25);
            tree.root.right.right = new Node(40);
            IList<int> list = new List<int>();

            tree.LeftView(tree.root, 1, list);

            Assert.AreEqual(list[0], 12);
            Assert.AreEqual(list[1], 10);
            Assert.AreEqual(list[2], 25);
        }

        [Test]
        public void BinaryTreeRightView()
        {
            BinaryTreeLeftRightView tree = new BinaryTreeLeftRightView();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);
            tree.root.right.left = new Node(6);
            tree.root.right.right = new Node(7);
            tree.root.right.left.right = new Node(8);
            IList<int> list = new List<int>();

            tree.RightView(tree.root, 1, list);

            Assert.AreEqual(list[0], 1);
            Assert.AreEqual(list[1], 3);
            Assert.AreEqual(list[2], 7);
            Assert.AreEqual(list[3], 8);
        }

        [Test]
        public void BottomView()
        {
            BinaryTreeLeftRightView tree = new BinaryTreeLeftRightView();
            HorizontalNode  root = new HorizontalNode(20);
            root.left = new HorizontalNode(8);
            root.right = new HorizontalNode(22);
            root.left.left = new HorizontalNode(5);
            root.left.right = new HorizontalNode(3);
            root.right.left = new HorizontalNode(4);
            root.right.right = new HorizontalNode(25);
            root.left.right.left = new HorizontalNode(10);
            root.left.right.right = new HorizontalNode(14);

            IDictionary<int, int> dict = new Dictionary<int, int>();

            tree.BottomView(root, dict);

            Assert.AreEqual(dict[0], 4);
            Assert.AreEqual(dict[2], 25);
        }

    }
}
