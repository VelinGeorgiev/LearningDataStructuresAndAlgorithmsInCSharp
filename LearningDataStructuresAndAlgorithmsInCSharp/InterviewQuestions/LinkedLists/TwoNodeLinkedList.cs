using System;
using System.Collections.Generic;

namespace Learning.InterviewQuestions.LinkedLists
{
    // Linked List Node class
    
    public class TwoNode
    {
        public int data;
        public TwoNode next;
        public TwoNode down;

        //Node constructor
        public TwoNode(int value)
        {
            data = value;
            next = down = null;
        }
    }

    public class TwoNodeLinkedList
    {
        public TwoNode head;

        public void AddFirst(int data)
        {
            TwoNode node = new TwoNode(data);
            node.next = head;
            head = node;
        }

        public void Print(IDictionary<int, int> dict)
        {
            TwoNode temp = head;
            while (temp != null)
            {
                int down = temp.down?.data ?? -1;
                dict.Add(temp.data, down);
                Console.Write(temp.data + "," + down);
                temp = temp.next;
            }
        }

        // http://www.geeksforgeeks.org/flattening-a-linked-list/
        // Flattening a Linked List. See the url.
        public TwoNode Flatten(TwoNode node)
        {
            if (node == null || node.next == null) return node;
            node.next = Flatten(node.next);
            node = Merge(node, node.next);
            return node;
        }

        // An utility function to merge two sorted linked lists
        private TwoNode Merge(TwoNode a, TwoNode b)
        {
            if (a == null) return b;
            if (b == null) return a;
            TwoNode result;
            if (a.data < b.data)
            {
                result = a;
                result.down = Merge(a.down, b);
            }
            else
            {
                result = b;
                result.down = Merge(a, b.down);
            }
            return result;
        }

        // Actual clone method which returns node
        // reference of cloned linked list.
        // Clone a linked list with next and random pointer
        // http://www.geeksforgeeks.org/clone-linked-list-next-arbit-pointer-set-2/
        public TwoNodeLinkedList Clone()
        {
            // Initialize two references, one with original
            // list's node.
            TwoNode origCurr = this.head, cloneCurr = null;

            // Hash map which contains node to node mapping of
            // original and clone linked list.
            Dictionary<TwoNode, TwoNode> dict = new Dictionary<TwoNode, TwoNode>();

            // Traverse the original list and make a copy of that
            // in the clone linked list.
            while (origCurr != null)
            {
                cloneCurr = new TwoNode(origCurr.data);
                dict.Add(origCurr, cloneCurr);
                origCurr = origCurr.next;
            }

            // Adjusting the original list reference again.
            origCurr = head;

            // Traversal of original list again to adjust the next
            // and random references of clone list using hash map.
            while (origCurr != null)
            {
                cloneCurr = dict[origCurr];
                cloneCurr.next = origCurr.next;
                cloneCurr.down = origCurr.down;
                origCurr = origCurr.next;
            }

            //return the node reference of the clone list.
            var result = new TwoNodeLinkedList();
            result.head = dict[head];
            return result;
        }
    }
}
