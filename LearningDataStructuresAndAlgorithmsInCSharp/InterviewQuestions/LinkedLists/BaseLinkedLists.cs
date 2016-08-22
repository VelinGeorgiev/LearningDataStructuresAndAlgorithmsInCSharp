using System;
using Learning.DataStructures.LinkedList;

namespace Learning.InterviewQuestions.LinkedLists
{
    public class BaseLinkedLists : SinglyLinkedList
    {
        // Function to print middle of linked list
        // http://www.geeksforgeeks.org/write-a-c-function-to-print-the-middle-of-the-linked-list/
        public void PrintMiddle()
        {
            Node slowPtr = head;
            Node fastPtr = head;
            if (head == null) return;
            
            while (fastPtr != null && fastPtr.next != null)
            {
                fastPtr = fastPtr.next.next;
                slowPtr = slowPtr.next;
            }
            output.Add(slowPtr.data);
            Console.Write(slowPtr.data);
        }

        // Remove every k'th node
        // A simple problem just iterate and maintain a count and delete nodes at k distance 
        // till the end of linked list .You need to take care of some corner cases . 
        // ie when linked list has only one element or when k=1.
        // http://www.practice.geeksforgeeks.org/problem-page.php?pid=700297
        // http://www.devsplanet.com/question/36003015
        public Node RemoveKthNode(Node node, int k)
        {
            if (node == null || k == 1) return null;
            Node prev = node;
            Node curr = node.next;
            int index = 2;

            while (curr != null)
            {
                if (index % k == 0)
                {
                    // remove current node and advance pointers
                    prev.next = curr.next;
                    curr = curr.next;
                }    
                else
                {
                    // otherwise just advance pointers
                    prev = curr;
                    curr = curr.next;
                }
                ++index;
            }
            return node;
        }
    }
}
