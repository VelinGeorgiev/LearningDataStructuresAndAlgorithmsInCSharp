using System;
using System.Collections.Generic;
using Learning.DataStructures;

namespace Learning.InterviewQuestions.Trees
{
    public class BinaryTreeLeftRightView : BinaryTree
    {
        private int _visitedLevel;

        // Recursive function to print left view.
        // http://www.geeksforgeeks.org/print-left-view-binary-tree/
        // Time Complexity: The function does a simple traversal of the tree, so the complexity is O(n).
        public void LeftView(Node node, int level, IList<int> list)
        {
            if (node == null) return;

            // If this is the first node of its level.
            if (_visitedLevel < level)
            {
                Console.Write(node.data + " ");
                list.Add(node.data);

                _visitedLevel = level;
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
            if (_visitedLevel < level)
            {
                Console.Write(node.data + " ");
                list.Add(node.data);

                _visitedLevel = level;
            }
            RightView(node.right, level + 1, list);
            RightView(node.left, level + 1, list);
        }


        // Method that prints the bottom view.
        // http://www.geeksforgeeks.org/bottom-view-binary-tree/
        //
        public void BottomView(HorizontalNode node, IDictionary<int, int> result)
        {
            if (node == null) return;

            // Initialize a variable 'hd' with 0
            // for the node element.
            int hd = 0;

            // Queue to store tree nodes in level
            // order traversal
            Queue<HorizontalNode> q = new Queue<HorizontalNode>();

            // Assign initialized horizontal distance
            // value to node node and add it to the queue.
            node.HorizontalDistanceOfNode = hd;
            q.Enqueue(node);

            // Loop until the queue is empty (standard
            // level order loop)
            while (q.Count > 0)
            {
                HorizontalNode temp = q.Dequeue();

                // Extract the horizontal distance value
                // from the dequeued tree node.
                hd = temp.HorizontalDistanceOfNode;

                // Put the dequeued tree node to TreeMap
                // having key as horizontal distance. Every
                // time we find a node having same horizontal
                // distance we need to replace the data in
                // the map.
                result[hd] = temp.data;

                // If the dequeued node has a left child add
                // it to the queue with a horizontal distance hd-1.
                if (temp.left != null)
                {
                    temp.left.HorizontalDistanceOfNode = hd - 1;
                    q.Enqueue(temp.left);
                }

                // If the dequeued node has a left child add
                // it to the queue with a horizontal distance
                // hd+1.
                if (temp.right != null)
                {
                    temp.right.HorizontalDistanceOfNode = hd + 1;
                    q.Enqueue(temp.right);
                }
            }
        }
    }

    public class HorizontalNode : Node
    {
        public int HorizontalDistanceOfNode;
        public HorizontalNode left;
        public HorizontalNode right;

        public HorizontalNode(int data) : base(data)
        {
            HorizontalDistanceOfNode = 0;
            left = right = null;
        }
    }
}
