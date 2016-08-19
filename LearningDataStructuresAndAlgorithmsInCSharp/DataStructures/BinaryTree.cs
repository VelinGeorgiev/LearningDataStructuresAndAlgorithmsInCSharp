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

        public void BreadthFirstTraversal(Node node)
        {
            
        }

        public void DepthFirstTraversalWithStack()
        {

        }
    }
}
