using System;
using System.Collections.Generic;
using Learning.DataStructures;

namespace Learning.InterviewQuestions.Trees
{
    // Time Complexity: O(n) where n is the number of nodes in binary tree.
    // http://www.geeksforgeeks.org/boundary-traversal-of-binary-tree/
    // TODO: Clockwise
    public class BinaryTreeBoundary : BinaryTree
    {
        public IList<int> Output = new List<int>();
        // A simple function to print leaf nodes of a binary tree
        void PrintLeaves(Node node)
        {
            if (node == null) return;

            PrintLeaves(node.left);
            
            if (node.left == null && node.right == null) // Print it if it is a leaf node
            {
                Console.Write(node.data + " ");
                Output.Add(node.data);
            }

            PrintLeaves(node.right);
        }

        // A function to print all left boundry nodes, except a leaf node.
        // Print the nodes in TOP DOWN manner
        void PrintBoundaryLeft(Node node)
        {
            if (node == null) return;
            
            if (node.left != null)
            {
                // to ensure top down order, print the node
                // before calling itself for left subtree
                Console.Write(node.data + " ");
                Output.Add(node.data);
                PrintBoundaryLeft(node.left);
            }
            else if (node.right != null)
            {
                Console.Write(node.data + " ");
                Output.Add(node.data);
                PrintBoundaryLeft(node.right);
            }

            // do nothing if it is a leaf node, this way we avoid
            // duplicates in output
        }

        // A function to print all right boundry nodes, except a leaf node
        // Print the nodes in BOTTOM UP manner
        void PrintBoundaryRight(Node node)
        {
            if (node == null) return;
            
            if (node.right != null)
            {
                // to ensure bottom up order, first call for right
                //  subtree, then print this node
                PrintBoundaryRight(node.right);
                Console.Write(node.data + " ");
                Output.Add(node.data);
            }
            else if (node.left != null)
            {
                PrintBoundaryRight(node.left);
                Console.Write(node.data + " ");
                Output.Add(node.data);
            }
            // do nothing if it is a leaf node, this way we avoid
            // duplicates in output
        }

        // A function to do boundary traversal of a given binary tree
        public void PrintBoundary(Node node)
        {
            if (node == null) return;
            
            Console.Write(node.data + " "); // Print root
            Output.Add(node.data);
           
            PrintBoundaryLeft(node.left);  // Print the left boundary in top-down manner.
            
            PrintLeaves(node.left); // Print all leaf nodes
            PrintLeaves(node.right); // Print all leaf nodes

            PrintBoundaryRight(node.right); // Print the right boundary in bottom-up manner
        }
    }
}
