using System;
using System.Collections.Generic;

namespace Learning.DataStructures.LinkedList
{
    public class Node
    {
        public int data { get; set; }
        public Node next { get; set; }

        public Node(int d)
        {
            data = d;
            next = null;
        }
    }

    /// <summary>
    /// This LinkedList is created only for learning purposes. 
    /// You should you the .NET LinkedList object in production.
    /// LinkedList is double linked.
    /// See also Circular Linked List: http://www.tutorialspoint.com/data_structures_algorithms/circular_linked_list_algorithm.htm
    /// </summary>
    public class SinglyLinkedList
    {
        public Node head;
        public IList<int> output;

        public SinglyLinkedList()
        {
            output = new List<int>();
        }

        public void Push(int value)
        {
            // Allocate the Node & Put in the data
            Node newNode = new Node(value);

            // Make next of new Node as head
            newNode.next = head;

            // Move the head to point to new Node
            head = newNode;
        }

        public void PushLast(int value)
        {
            // Allocate the Node & Put in the data
            Node node = new Node(value);
            if (head == null)
            {
                head = node;
            }
            else
            {
                var current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = node; //new head
            }
        }

        // This function prints contents of linked list starting from  the given node */
        public IList<int> PrintList()
        {
            Node tnode = head;
            IList<int> list = new List<int>();

            while (tnode != null)
            {
                Console.Write(tnode.data + "->");
                list.Add(tnode.data);
                tnode = tnode.next;
            }
            Console.Write("null");
            return list;
        }

        public void Remove(Node node)
        {
            if (head == null) return;

            if (head == node)
            {
                head = head.next;
                node.next = null;
            }

            var current = head;
            while (current?.next != null)
            {
                if (current.next == node)
                {
                    current.next = node.next;
                }

                current = current.next;
            }
        }

        public void Reverse()
        {
            Node prev = null;
            var current = head;

            if (current == null)
                return;

            while (current != null)
            {
                var next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }

            head = prev;
        }

        public void ReverseRecurisve()
        {
            ReverseRecurive(head, null);
        }

        private void ReverseRecurive(Node current, Node prev)
        {
            if (current.next == null)
            {
                head = current;
                head.next = prev;
                return;
            }

            var next = current.next;
            current.next = prev;
            ReverseRecurive(next, current);
        }
    }
}
