using System;
using System.Collections.Generic;

namespace Learning.DataStructures
{
    /// <summary>
    /// BinaryTree with BSF and DFS.
    /// Modified from source: http://www.geeksforgeeks.org/618/
    /// http://www.geeksforgeeks.org/bfs-vs-dfs-binary-tree/
    /// </summary>
    public class BinaryTree
    {
        //root of the Binary Tree
        public Node root;

        public BinaryTree()
        {
            root = null;
        }

        public void InorderDepthFirstTraversal(Node node, IList<Node> result)
        {
            if (node == null) return;

            // First recur on left child.
            InorderDepthFirstTraversal(node.left, result);

            // Then print the data of node.
            // System.out.print(node.key);
            Console.Write(node.data);
            result.Add(node);

            // Now recur on right child.
            InorderDepthFirstTraversal(node.right, result);
        }

        public void PreorderDepthFirstTraversal(Node node, IList<Node> result)
        {
            if (node == null) return;

            // First print data of node.
            // System.out.print(node.key);
            Console.Write(node.data);
            result.Add(node);

            // Then recur on left sutree.
            PreorderDepthFirstTraversal(node.left, result);

            // Now recur on right subtree
            PreorderDepthFirstTraversal(node.right, result);
        }

        public void PostorderDepthFirstTraversal(Node node, IList<Node> result)
        {
            if (node == null) return;

            // First recur on left subtree.
            PostorderDepthFirstTraversal(node.left, result);

            // Then recur on right subtree.
            PostorderDepthFirstTraversal(node.right, result);

            // Now deal with the node.
            // System.out.print(node.data);
            Console.Write(node.data);
            result.Add(node);
        }

        // Given a binary tree. Print its nodes in level order using array for implementing queue
        // http://www.geeksforgeeks.org/level-order-tree-traversal/
        // Time Complexity: O(n) where n is number of nodes in the binary tree
        public void LevelOrder(Node node, IList<int> list) // Breadth First Traversal or Level Order or Breadth First Search
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                Node tempNode = queue.Dequeue();
                Console.Write(tempNode.data);
                list.Add(tempNode.data);
                if (tempNode.left != null) queue.Enqueue(tempNode.left);
                if (tempNode.right != null) queue.Enqueue(tempNode.right);
            }
        }

        // Function to print REVERSE level order traversal a tree
        // Time Complexity: O(n) where n is number of nodes in the binary tree.
        // http://www.geeksforgeeks.org/reverse-level-order-traversal/
        public void ReverseLevelOrder(Node node, IList<int> list)
        {
            Stack<Node> stack = new Stack<Node>();
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);

            // Do something like normal level order traversal order. Following are the
            // differences with normal level order traversal
            // 1) Instead of printing a node, we Enqueue the node to Stack
            // 2) Right subtree is visited before left subtree
            while (queue.Count > 0)
            {
                // Dequeue node and make it node 
                node = queue.Dequeue();
                stack.Push(node);

                if (node.right != null) queue.Enqueue(node.right); // NOTE: RIGHT CHILD IS ENQUEUED BEFORE LEFT
                if (node.left != null) queue.Enqueue(node.left);
            }

            // Now pop all items from Stack one by one and print them
            while (stack.Count > 0)
            {
                node = stack.Pop();
                list.Add(node.data);
                Console.Write(node.data);
            }
        }

        // Time Complexity: O(n)
        // http://www.geeksforgeeks.org/inorder-tree-traversal-without-recursion/
        public void InorderTraversalWithStack (Node node, IList<int> list) // Inorder DepthFirstTraversalWithStack
        {
            if (root == null) return;
            Stack<Node> stack = new Stack<Node>();

            // First node to be visited will be the left one.
            while (node != null)
            {
                stack.Push(node);
                node = node.left;
            }

            // Traverse the tree.
            while (stack.Count > 0)
            {
                node = stack.Pop();
                Console.Write(node.data);
                list.Add(node.data);

                if (node.right != null)
                {
                    node = node.right;

                    // the next node to be visited is the leftmost
                    while (node != null)
                    {
                        stack.Push(node);
                        node = node.left;
                    }
                }
            }
        }
    }
}
