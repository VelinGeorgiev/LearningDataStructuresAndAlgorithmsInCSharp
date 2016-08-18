using System;
using System.Collections.Generic;
using Learning.DataStructures;

namespace Learning.InterviewQuestions
{
    /// <summary>
    /// https://www.youtube.com/watch?v=hmWhJyz5kqc
    /// </summary>
    public class BinaryTreeMinDepth : BinaryTree
    {
        // A queue item (Stores pointer to node and an integer)
        struct QItem
        {
            public Node Node;
            public int Depth;
        };

        public int MinimumDepthRecursive()
        {
            return MinimumDepthRecursive(Root);
        }

        /// <summary>
        /// Calculate the minimum depth of the tree
        /// Time complexity of above solution is O(n) as it traverses the tree only once.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private int MinimumDepthRecursive(Node root)
        {
            // Corner case. Should never be hit unless the code is
            // called on root = NULL
            if (root == null)
                return 0;

            // Base case : Leaf Node. This accounts for height = 1.
            if (root.Left == null && root.Right == null)
                return 1;

            // If left subtree is NULL, recur for right subtree
            if (root.Left == null)
                return MinimumDepthRecursive(root.Right) + 1;

            // If right subtree is NULL, recur for right subtree
            if (root.Right == null)
                return MinimumDepthRecursive(root.Left) + 1;

            return Math.Min(MinimumDepthRecursive(root.Left), MinimumDepthRecursive(root.Right)) + 1;
        }

        public int LevelOrderTraversalMinimumDepth()
        {
            return LevelOrderTraversalMinimumDepth(Root);
        }

        /// <summary>
        /// Worst time case o(n) for both, check Space complexity
        /// The above method may end up with complete traversal of Binary Tree even when the topmost leaf is close to root. 
        /// A Better Solution for unbalanced trees might be to do Level Order Traversal.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private int LevelOrderTraversalMinimumDepth(Node root)
        {
            // Corner Case
            if (root == null) return 0;

            // Create an empty queue for level order tarversal
            Queue<QItem> q = new Queue<QItem>();

            // Enqueue Root and initialize depth as 1
            QItem qi = new QItem
            {
                Node = root,
                Depth = 1
            };
            q.Enqueue(qi);

            // Do level order traversal
            while (q.Count > 0)
            {
                // Remove the front queue item
                qi = q.Dequeue();
                
                // Get details of the remove item
                Node node = qi.Node;
                int depth = qi.Depth;

                // If this  is the first leaf node seen so far
                // Then return its depth as answer
                if (node.Left == null && node.Right == null)
                    return depth;

                // If left subtree is not NULL, add it to queue
                if (node.Left != null)
                {
                    qi.Node = node.Left;
                    qi.Depth = depth + 1;
                    q.Enqueue(qi);
                }

                // If right subtree is not NULL, add it to queue
                if (node.Right != null)
                {
                    qi.Node = node.Right;
                    qi.Depth = depth + 1;
                    q.Enqueue(qi);
                }
            }
            return 0;
        }

        /* Driver program to test above functions */
        //public static void main(String args[])
        //{
        //    BinaryTree tree = new BinaryTree();
        //    tree._root = new Node(1);
        //    tree._root.Left = new Node(2);
        //    tree._root.Right = new Node(3);
        //    tree._root.Left.Left = new Node(4);
        //    tree._root.Left.Right = new Node(5);

        //    Console.WriteLine("The minimum depth of " + "binary tree is : " + tree.MinimumDepth());
        //    //System.out.println("The minimum depth of " + "binary tree is : " + tree.minimumDepth());
        //}
    }
}
