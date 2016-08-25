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
                if (odd == null || even == null || even.next == null)
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

        // Add two numbers represented by linked lists
        // http://www.geeksforgeeks.org/add-two-numbers-represented-by-linked-lists/
        //Input:
        //  First List: 5.6.3  // represents number 365
        //  Second List: 8.4.2 //  represents number 248
        //Output
        //  Resultant list: 3.1.6  // represents number 613
        // Time Complexity: O(m + n) where m and n are number of nodes in first and second lists respectively.
        public Node AddTwoLists(Node first, Node second)
        {
            Node res = null; // res is head node of the resultant list
            Node prev = null;
            Node temp = null;
            int carry = 0, sum;

            while (first != null || second != null) //while both lists exist
            {
                // Calculate value of next digit in resultant list.
                // The next digit is sum of following things
                // (i)  Carry
                // (ii) Next digit of first list (if there is a next digit)
                // (ii) Next digit of second list (if there is a next digit)
                sum = carry + (first != null ? first.data : 0)
                        + (second != null ? second.data : 0);

                // update carry for next calulation
                carry = (sum >= 10) ? 1 : 0;

                // update sum if it is greater than 10
                sum = sum % 10;

                // Create a new node with sum as data
                temp = new Node(sum);

                // if this is the first node then set it as head of
                // the resultant list
                if (res == null)
                {
                    res = temp;
                }
                else // If this is not the first node then connect it to the rest.
                {
                    prev.next = temp;
                }

                // Set prev for next insertion
                prev = temp;

                // Move first and second pointers to next nodes
                if (first != null)
                {
                    first = first.next;
                }
                if (second != null)
                {
                    second = second.next;
                }
            }

            if (carry > 0)
            {
                temp.next = new Node(carry);
            }

            // return head of the resultant list
            return res;
        }

        // Add two numbers represented by linked lists
        // http://www.geeksforgeeks.org/sum-of-two-linked-lists/
        //Input:
        //  First List: 5.6.3  // represents number 563
        //  Second List: 8.4.2 //  represents number 842
        //Output
        //  Resultant list: 1.4.0.5  // represents number 1405
        // TODO: later, too much code here

        // Given a linked list of 0s, 1s and 2s, sort it.
        // http://www.geeksforgeeks.org/sort-a-linked-list-of-0s-1s-or-2s/


        // http://www.geeksforgeeks.org/sort-a-linked-list-of-0s-1s-or-2s/
        // Sort a linked list of 0s, 1s and 2s
        // Time Complexity: O(n) where n is number of nodes in linked list, Auxiliary Space: O(1)
        public void SortListOf012()
        {
            // initialise count of 0 1 and 2 as 0
            int[] count = { 0, 0, 0 };

            Node ptr = head;

            /* count total number of '0', '1' and '2'
             * count[0] will store total number of '0's
             * count[1] will store total number of '1's
             * count[2] will store total number of '2's  */
            while (ptr != null)
            {
                count[ptr.data]++;
                ptr = ptr.next;
            }

            int i = 0;
            ptr = head;

            /* Let say count[0] = n1, count[1] = n2 and count[2] = n3
             * now start traversing list from head node,
             * 1) fill the list with 0, till n1 > 0
             * 2) fill the list with 1, till n2 > 0
             * 3) fill the list with 2, till n3 > 0  */
            while (ptr != null)
            {
                if (count[i] == 0)
                    i++;
                else
                {
                    ptr.data = i;
                    --count[i];
                    ptr = ptr.next;
                }
            }
        }


        /* Function to pairwise swap elements of a linked list */
        public void PairWiseSwap(Node node)
        {
            Node temp = node;

            /* Traverse further only if there are at-least two nodes left */
            while (temp != null && temp.next != null)
            {
                // Swap data of node with its next node's data
                // Swap the node's data with data of next node
                int t = temp.data;
                temp.data = temp.next.data;
                temp.next.data = t;
                /* Move temp by 2 for the next pair */
                temp = temp.next.next;
            }
        }

        // Recursive function to pairwise swap elements of a linked list
        public void PairWiseSwapRecursion(Node node)
        {
            /* There must be at-least two nodes in the list */
            if (node != null && node.next != null)
            {
                // Swap the node's data with data of next node
                int temp = node.data;
                node.data = node.next.data;
                node.next.data = temp;

                // Call pairWiseSwap() for rest of the list
                PairWiseSwapRecursion(node.next.next);
            }
        }

        // Function to skip m nodes and then delete N nodes of the linked list.
        // http://www.geeksforgeeks.org/delete-n-nodes-after-m-nodes-of-a-linked-list/
        // Time Complexity: O(n) where n is number of nodes in linked list.
        public void SkipMDeleteN(Node head, int m, int n)
        {
            Node curr = head, t;
            int count;

            // The main loop that traverses through the whole list
            while (curr != null)
            {
                // Skip m nodes
                for (count = 1; count < m && curr != null; count++)
                    curr = curr.next;

                // If we reached end of list, then return
                if (curr == null) return;

                // Start from next node and delete N nodes
                t = curr.next;
                for (count = 1; count <= n && t != null; count++)
                {
                    Node temp = t;
                    t = t.next;
                }
                curr.next = t; // Link the previous list with remaining nodes

                // Set current pointer for next iteration
                curr = t;
            }
        }

        // Merge K sorted linked lists
        // http://www.geeksforgeeks.org/merge-k-sorted-linked-lists/
        // On2
        public Node MergeKLists(Node[] arr, int last)
        {
            while (last != 0)
            {
                int i = 0, j = last;

                // (i, j) forms a pair
                while (i < j)
                {
                    // merge List i with List j and store
                    // merged list in List i
                    arr[i] = SortedMerge(arr[i], arr[j]);

                    // consider next pair
                    i++; j--;

                    // If all pairs are merged, update last
                    if (i >= j)
                        last = j;
                }
            }

            return arr[0];
        }

        /* Takes two lists sorted in increasing order, and merge
   their nodes together to make one big sorted list. Below
   function takes O(Log n) extra space for recursive calls,
   but it can be easily modified to work with same time and
   O(1) extra space  */
        Node SortedMerge(Node a, Node b)
        {
            Node result = null;
            if (a == null) return b;
            if (b == null) return a;

            /* Pick either a or b, and recur */
            if (a.data <= b.data)
            {
                result = a;
                result.next = SortedMerge(a.next, b);
            }
            else
            {
                result = b;
                result.next = SortedMerge(a, b.next);
            }

            return result;
        }

    }
}
