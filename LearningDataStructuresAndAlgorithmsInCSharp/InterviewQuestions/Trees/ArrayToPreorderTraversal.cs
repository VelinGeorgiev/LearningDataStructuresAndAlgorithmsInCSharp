using System.Collections.Generic;
using Learning.DataStructures;

namespace Learning.InterviewQuestions.Trees
{
    /// <summary>
    /// http://www.geeksforgeeks.org/check-if-a-given-array-can-represent-preorder-traversal-of-binary-search-tree/
    /// </summary>
    public class ArrayToPreorderTraversal : BinaryTree
    {
        public bool CanRepresentBst(int[] pre, int n)
        {
            // Create an empty stack
            Stack<int> s = new Stack<int>();

            // Initialize current root as minimum possible value
            int root = int.MinValue;

            // Traverse given array
            for (int i = 0; i < n; i++)
            {
                // If we find a node who is on right side
                // and smaller than root, return false
                if (pre[i] < root) return false;

                // If pre[i] is in right subtree of stack top,
                // Keep removing items smaller than pre[i]
                // and make the last removed item as new
                // root.
                while (s.Count > 0 && s.Peek() < pre[i])
                    root = s.Pop();

                // At this point either stack is empty or
                // pre[i] is smaller than root, push pre[i]
                s.Push(pre[i]);
            }
            return true;
        }
    }
}
