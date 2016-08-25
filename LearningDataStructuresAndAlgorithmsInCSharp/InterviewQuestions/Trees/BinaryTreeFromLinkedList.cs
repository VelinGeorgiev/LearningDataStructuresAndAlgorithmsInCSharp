using System.Collections.Generic;
using Learning.DataStructures;
using LinkedListNode = Learning.DataStructures.LinkedList.Node;

namespace Learning.InterviewQuestions.Trees
{
    // http://www.geeksforgeeks.org/given-linked-list-representation-of-complete-tree-convert-it-to-linked-representation/
    // Time Complexity: Time complexity of the above solution is O(n) where n is the number of nodes.
    public class BinaryTreeFromLinkedList : BinaryTree
    {
        // converts a given linked list representing a complete binary tree into the
        // linked representation of binary tree.
        public void ConvertList2Binary(LinkedListNode head, Node node)
        {
            // queue to store the parent nodes
            Queue<Node> q = new Queue<Node>();

            if (head == null)
            {
                root = null; // Note that root is passed by reference
                return;
            }

            // 1.) The first node is always the root node, and add it to the queue
            root = new Node(head.data);
            q.Enqueue(root);

            // advance the pointer to the next node
            head = head.next;

            // until the end of linked list is reached, do the following steps
            while (head != null)
            {
                // 2.a) take the parent node from the q and remove it from q
                Node parent = q.Dequeue();

                // 2.c) take next two nodes from the linked list. We will add
                // them as children of the current parent node in step 2.b. Push them
                // into the queue so that they will be parents to the future nodes
                Node leftChild = null;
                Node rightChild = null;
                leftChild = new Node(head.data);
                q.Enqueue(leftChild);

                head = head.next;
                if (head != null)
                {
                    rightChild = new Node(head.data);
                    q.Enqueue(rightChild);
                    head = head.next;
                }

                // 2.b) assign the left and right children of parent
                parent.left = leftChild;
                parent.right = rightChild;
            }
        }
    }
}
