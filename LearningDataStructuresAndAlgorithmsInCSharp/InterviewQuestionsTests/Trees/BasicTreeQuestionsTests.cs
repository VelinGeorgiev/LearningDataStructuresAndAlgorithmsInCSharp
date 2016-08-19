using System.Text;
using Learning.DataStructures;
using Learning.InterviewQuestions.Trees;
using NUnit.Framework;

namespace Learning.InterviewQuestionsTests.Trees
{
    [TestFixture]
    public class BasicTreeQuestionsTests
    {
        private readonly BasicTreeQuestions _tree;

        public BasicTreeQuestionsTests()
        {
            _tree = new BasicTreeQuestions();
        }

        [Test]
        public void IsSumTree()
        {
            _tree.root = new Node(26);
            _tree.root.left = new Node(10);
            _tree.root.left.left = new Node(4);
            _tree.root.left.right = new Node(6);
            _tree.root.right = new Node(3);
            _tree.root.right.right = new Node(3);

            Assert.IsTrue(_tree.IsSumTree(_tree.root));
        }

        [Test]
        public void IsSumTree2()
        {
            _tree.root = new Node(26);
            _tree.root.left = new Node(10);
            _tree.root.left.left = new Node(4);
            _tree.root.left.right = new Node(6);
            _tree.root.right = new Node(3);
            _tree.root.right.left = new Node(1);
            _tree.root.right.right = new Node(3);

            Assert.IsFalse(_tree.IsSumTree(_tree.root));
        }

        [Test]
        public void MaxDepth()
        {
            _tree.root = new Node(1);
            _tree.root.left = new Node(2);
            _tree.root.right = new Node(3);
            _tree.root.left.left = new Node(4);
            _tree.root.left.right = new Node(5);

            Assert.AreEqual(_tree.MaxDepth(_tree.root), 3);
        }

        [Test]
        public void AreMirror()
        {
            Node a = new Node(1);
            Node b = new Node(1);
            a.left = new Node(2);
            a.right = new Node(3);
            a.left.left = new Node(4);
            a.left.right = new Node(5);

            b.left = new Node(3);
            b.right = new Node(2);
            b.right.left = new Node(5);
            b.right.right = new Node(4);

            Assert.IsTrue(_tree.AreMirror(a, b));
        }

        [Test]
        public void Serialize()
        {
            _tree.root = new Node(26);
            _tree.root.left = new Node(10);
            _tree.root.left.left = new Node(4);
            _tree.root.left.right = new Node(6);
            _tree.root.right = new Node(3);
            _tree.root.right.right = new Node(3);

            StringBuilder sb = new StringBuilder();
            _tree.Serialize(_tree.root, sb);

            string result = sb.ToString();
            Assert.AreEqual(result, "26 10 4 # # 6 # # 3 # 3 # # ");
        }

        [Test]
        public void Deserialize()
        {
            string input = "26 10 4 # # 6 # # 3 # 3 # # ";
            Node root = _tree.Deserialize(input);

            Assert.AreEqual(root.data, 26);
            Assert.AreEqual(root.left.data, 10);
            Assert.AreEqual(root.left.left.data, 4);
            Assert.AreEqual(root.left.right.data, 6);
            Assert.AreEqual(root.right.data, 3);
            Assert.AreEqual(root.right.right.data, 3);
        }
    }
}
