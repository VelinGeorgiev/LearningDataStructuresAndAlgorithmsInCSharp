using System;
using System.Collections.Generic;
using Learning.DataStructures;

namespace Learning.InterviewQuestions.Trees
{
    /// <summary>
    /// http://www.geeksforgeeks.org/binary-tree-to-binary-search-tree-conversion/
    /// </summary>
    public class BinaryTreeToBst : BinaryTree
    {
        public void Convert(Node node)
        {
            if(node == null) return;

            int count = CountNodes(node);
            int[] array = new int[count];
            StoreInorder(node, array);
            Array.Sort(array); // Modified quicksort worst O(n2)
            ArrayToBst(node, array);
        }

        private int _abIndex = 0;
        private void ArrayToBst(Node node, int[] array)
        {
            if(node == null) return;
            ArrayToBst(node.left, array);
            node.data = array[_abIndex];
            _abIndex++;
            ArrayToBst(node.right, array);
        }

        private int _siIndex = 0;
        public void StoreInorder(Node node, int[] array)
        {
            if(node == null) return;
            StoreInorder(node.left, array);
            array[_siIndex] = node.data;
            _siIndex++;
            StoreInorder(node.right, array);
        }

        private int CountNodes(Node node)
        {
            if (node == null) return 0;
            return CountNodes(node.left) + CountNodes(node.right) + 1;
        }

        /* Utility function to print inorder traversal of Binary Tree */
        public void PrintInorder(Node node, IList<int> list)
        {
            if (node == null) return;

            /* first recur on left child */
            PrintInorder(node.left, list);

            /* then print the data of node */
            Console.WriteLine(node.data);
            list.Add(node.data);

            /* now recur on right child */
            PrintInorder(node.right, list);
    }
}
}
