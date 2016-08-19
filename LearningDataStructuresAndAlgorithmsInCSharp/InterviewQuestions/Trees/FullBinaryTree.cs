using Learning.DataStructures;

namespace Learning.InterviewQuestions.Trees
{
    /// <summary>
    /// Time complexity of the above code is O(n) where n is number of nodes in given binary tree.
    /// Source: http://www.geeksforgeeks.org/check-whether-binary-tree-full-binary-tree-not/
    /// </summary>
    public class FullBinaryTree : BinaryTree
    {
        public bool IsFullBinaryTree(Node node)
        {
            if (node == null) return true;

            // if leaf node
            if (node.left == null && node.right == null) return true;

            // if both left and right subtrees are not null they are full
            if ((node.left != null) && (node.right != null)) return IsFullBinaryTree(node.left) && IsFullBinaryTree(node.right);

            // if none work
            return false;
        }
    }
}
