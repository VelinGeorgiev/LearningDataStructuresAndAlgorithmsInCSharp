using System;
using System.Collections.Generic;
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

        // Find n’th node from the end of a Linked List
        // http://www.geeksforgeeks.org/nth-node-from-the-end-of-a-linked-list/
        /* Function to get the nth node from the last of a
       linked list */
        public void PrintNthFromLast(int n, IList<int> list)
        {
            int len = 0;
            Node temp = head;

            // 1) count the number of nodes in Linked List
            while (temp != null)
            {
                temp = temp.next;
                len++;
            }

            // check if value of n is not more than length of
            // the linked list
            if (len < n) return;
            temp = head;

            // 2) get the (n-len+1)th node from the begining
            for (int i = 1; i < len - n + 1; i++)
                temp = temp.next;

            Console.Write(temp.data);
            list.Add(temp.data);
        }

        // Intersection of two sorted Linked lists
        // http://www.practice.geeksforgeeks.org/problem-page.php?pid=700191
        // Time Complexity: O(m+n) where m and n are number of nodes in first and second linked lists respectively.
        public SinglyLinkedList IntersectionOfSortedLists(Node a, Node b)
        {
            var intersect = new SinglyLinkedList();

            // Once one or the other list runs out -- we're done
            while (a != null && b != null)
              {
                if (a.data == b.data)
                {
                   intersect.PushFirst(a.data);
                   a = a.next;
                   b = b.next;
                }
                else if (a.data < b.data)
                {
                    // advance the smaller list
                    a = a.next;
                }
                else
                {
                    b = b.next;
                }
              }
              return intersect;
        }

        // Merge two sorted linked lists
        // http://www.geeksforgeeks.org/merge-two-sorted-linked-lists/
        // Takes two lists sorted in increasing order, and splices
        // their nodes together to make one big sorted list which
        // is returned. 
        //public Node MergeTwoSortedLinkedLists(Node a, Node b)
        //{
        //    /* a dummy first node to hang the result on */
        //    Node dummy = new Node(0);
 
        //    /* tail points to the last result node  */
        //    Node tail = dummy;
 
        //    /* so tail.next is the place to add new nodes to the result. */
        //    dummy.next = null;
        //    while (true)
        //    {
        //        if (a == null)
        //        {
        //            // if either list runs out, use the other list
        //            tail.next = b;
        //            break;
        //        }

        //        if (b == null)
        //        {
        //            tail.next = a;
        //            break;
        //        }

        //        if (a.data <= b.data)
        //            MoveNode(&(tail.next), &a);
        //        else
        //            MoveNode(&(tail.next), &b);
 
        //        tail = tail.next;
        //    }

        //    return(dummy.next);
        //}

        // Merge two sorted linked lists
        // http://www.geeksforgeeks.org/merge-two-sorted-linked-lists/
        // Takes two lists sorted in increasing order, and splices
        // their nodes together to make one big sorted list which
        // is returned. 
        public Node MergeTwoSortedLinkedListsRecursion(Node a, Node b)
        {
            if (a == null) return b;
            if (b == null) return a;
            Node result;

            if (a.data < b.data)
            {
                result = a;
                result.next = MergeTwoSortedLinkedListsRecursion(a.next, b);
            }
            else
            {
                result = b;
                result.next = MergeTwoSortedLinkedListsRecursion(a, b.next);
            }

            return result;
        }

        // To sort a linked list by actual values.
        // The list is assumed to be sorted by absolute
        // values.
        // O(n) time
        // http://www.geeksforgeeks.org/sort-linked-list-already-sorted-absolute-values/
        public Node SortedListAbsoluteValues(Node node)
        {
            // Initialize previous and current nodes
            Node prev = node;
            Node curr = node.next;

            // Traverse list
            while (curr != null)
            {
                // If curr is smaller than prev, then
                // it must be moved to node
                if (curr.data < prev.data)
                {
                    // Detach curr from linked list
                    prev.next = curr.next;

                    // Move current node to beginning
                    curr.next = node;
                    node = curr;

                    // Update current
                    curr = prev;
                }

                // Nothing to do if current element
                // is at right place
                else
                    prev = curr;

                // Move current
                curr = curr.next;
            }
            return node;
        }

        // Write a program function to detect loop in a linked list
        // http://www.geeksforgeeks.org/write-a-c-function-to-detect-loop-in-a-linked-list/
        // Floyd’s Cycle-Finding Algorithm
        // Move one pointer by one and other pointer by two.  
        // If these pointers meet at some node then there is a loop.
        // Time Complexity: O(n), Auxiliary Space: O(1)
        public bool DetectLoop()
        {
            Node slowP = head, fastP = head;
            while (slowP != null && fastP != null && fastP.next != null)
            {
                slowP = slowP.next;
                fastP = fastP.next.next;
                if (slowP == fastP) return true;
            }
            return false;
        }

        // Rearrange a linked list such that all even and odd positioned nodes are together
        // The important thing in this question is to make sure that all below cases are handled
        // 1) Empty linked list
        // 2) A linked list with only one node
        // 3) A linked list with only two nodes
        // 4) A linked list with odd number of nodes
        // 5) A linked list with even number of nodes
        // Rearranges given linked list such that all even
        // positioned nodes are before odd positioned.
        // Returns new head of linked List.
        public Node RearrangeEvenOdd(Node node)
        {
            if (node == null) return null;

            // Initialize first nodes of even and odd lists
            Node odd = node;
            Node even = node.next;

            // Remember the first node of even list so
            // that we can connect the even list at the
            // end of odd list.
            Node evenFirst = even;

            while (true)
            {
                // If there are no more nodes, then connect
                // first node of even list to the last node
                // of odd list
                if (odd ==null || even==null || even.next==null)
                {
                    odd.next = evenFirst;
                    break;
                }

                // Connecting odd nodes
                odd.next = even.next;
                odd = even.next;

                // If there are NO more even nodes after
                // current odd.
                if (odd.next == null)
                {
                    even.next = null;
                    odd.next = evenFirst;
                    break;
                }

                // Connecting even nodes
                even.next = odd.next;
                even = odd.next;
            }

            return node;
        }

    }
}
