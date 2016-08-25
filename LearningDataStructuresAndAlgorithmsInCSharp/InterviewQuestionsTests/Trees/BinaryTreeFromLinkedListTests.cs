using System.Collections.Generic;
using Learning.DataStructures;
using Learning.InterviewQuestions.Trees;
using NUnit.Framework;

using LinkedListNode = Learning.DataStructures.LinkedList.Node;

namespace Learning.InterviewQuestionsTests.Trees
{
    [TestFixture]
    public class BinaryTreeFromLinkedListTests
    {
        [Test]
        public void ConvertList2Binary()
        {
            // create a linked list shown in above diagram
            LinkedListNode head = new LinkedListNode(10);
            head.next= new LinkedListNode(12);
            head.next.next = new LinkedListNode(15);
            head.next.next.next = new LinkedListNode(25);
            head.next.next.next.next = new LinkedListNode(30);
            head.next.next.next.next.next = new LinkedListNode(36);

            BinaryTreeFromLinkedList tree = new BinaryTreeFromLinkedList();
            tree.ConvertList2Binary(head, tree.root);

            Assert.AreEqual(tree.root.data, 10);
            Assert.AreEqual(tree.root.left.data, 12);
            Assert.AreEqual(tree.root.left.left.data, 25);
            Assert.AreEqual(tree.root.left.right.data, 30);
            Assert.AreEqual(tree.root.right.data, 15);
            Assert.AreEqual(tree.root.right.left.data, 36);
        }
    }
}
