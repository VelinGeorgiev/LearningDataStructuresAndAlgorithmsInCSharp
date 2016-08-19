using System.Collections.Generic;
using Learning.DataStructures;
using Learning.InterviewQuestions.Trees;
using NUnit.Framework;

namespace Learning.InterviewQuestionsTests.Trees
{
    [TestFixture]
    public class BinaryTreeToBstTests
    {
        [Test]
        public void Convert()
        {
            BinaryTreeToBst tree = new BinaryTreeToBst();
            var r = tree.root;
            r = new Node(10);
            r.left = new Node(30);
            r.right = new Node(15);
            r.left.left = new Node(20);
            r.left.right = new Node(5);

            tree.Convert(r);

            Assert.AreEqual(r.data, 20);
            Assert.AreEqual(r.left.data, 10);
            Assert.AreEqual(r.left.left.data, 5);
            Assert.AreEqual(r.left.right.data, 15);
            Assert.AreEqual(r.right.data, 30);
        }

        [Test]
        public void ConvertAndPrint()
        {
            BinaryTreeToBst tree = new BinaryTreeToBst();
            var r = tree.root;
            r = new Node(10);
            r.left = new Node(30);
            r.right = new Node(15);
            r.left.left = new Node(20);
            r.left.right = new Node(5);

            tree.Convert(r);
            var list = new List<int>();
            tree.PrintInorder(r,list);

            Assert.AreEqual(list[0], 5);
            Assert.AreEqual(list[1], 10);
            Assert.AreEqual(list[2], 15);
            Assert.AreEqual(list[3], 20);
            Assert.AreEqual(list[4], 30);
        }
    }
}
