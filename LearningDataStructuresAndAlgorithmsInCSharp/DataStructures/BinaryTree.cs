using System;
using System.Collections.Generic;

namespace Learning.DataStructures
{
    public class Node
    {
        public int Data;
        public Node Left, Right;

        public Node(int item)
        {
            Data = item;
            Left = Right = null;
        }
    }

    /// <summary>
    /// BinaryTree with BSF and DFS.
    /// Modified from source: http://www.geeksforgeeks.org/618/
    /// </summary>
    public class BinaryTree
    {
        //Root of the Binary Tree
        public Node Root;

        public BinaryTree()
        {
            Root = null;
        }

        public void InorderDepthFirstTraversal(Node node, IList<Node> result)
        {
            if (node == null) return;

            // First recur on left child.
            InorderDepthFirstTraversal(node.Left, result);

            // Then print the data of node.
            // System.out.print(node.key);
            Console.Write(node.Data);
            result.Add(node);

            // Now recur on right child.
            InorderDepthFirstTraversal(node.Right, result);
        }

        public void PreorderDepthFirstTraversal(Node node, IList<Node> result)
        {
            if (node == null) return;

            // First print data of node.
            // System.out.print(node.key);
            Console.Write(node.Data);
            result.Add(node);

            // Then recur on left sutree.
            PreorderDepthFirstTraversal(node.Left, result);

            // Now recur on right subtree
            PreorderDepthFirstTraversal(node.Right, result);
        }

        public void PostorderDepthFirstTraversal(Node node, IList<Node> result)
        {
            if (node == null) return;

            // First recur on left subtree.
            PostorderDepthFirstTraversal(node.Left, result);

            // Then recur on right subtree.
            PostorderDepthFirstTraversal(node.Right, result);

            // Now deal with the node.
            // System.out.print(node.Data);
            Console.Write(node.Data);
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
