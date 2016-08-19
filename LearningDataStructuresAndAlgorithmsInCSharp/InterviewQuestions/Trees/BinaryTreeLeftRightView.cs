using System;
using System.Collections.Generic;
using Learning.DataStructures;

namespace Learning.InterviewQuestions.Trees
{
    public class BinaryTreeLeftRightView : BinaryTree
    {
        private int _maxLevel;

        // Recursive function to print left view.
        // http://www.geeksforgeeks.org/print-left-view-binary-tree/
        // Time Complexity: The function does a simple traversal of the tree, so the complexity is O(n).
        public void LeftView(Node node, int level, IList<int> list)
        {
            if (node == null) return;

            // If this is the first node of its level.
            if (_maxLevel < level)
            {
                Console.Write(node.data + " ");
                list.Add(node.data);

                _maxLevel = level;
            }
            LeftView(node.left, level + 1, list);
            LeftView(node.right, level + 1, list);
        }

        // Recursive function to print right view of a binary tree.
        // http://www.geeksforgeeks.org/print-right-view-binary-tree-2/
        // Time Complexity: The function does a simple traversal of the tree, so the complexity is O(n).
        public void RightView(Node node, int level, IList<int> list)
        {
            if (node == null) return;

            // If this is the last Node of its level
            if (_maxLevel < level)
            {
                Console.Write(node.data + " ");
                list.Add(node.data);

                _maxLevel = level;
            }
            RightView(node.right, level + 1, list);
            RightView(node.left, level + 1, list);
        }
    }
}
