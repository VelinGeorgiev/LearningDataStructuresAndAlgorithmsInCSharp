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
        private Node _head;

        public Node First => _head;

        public void Push(int value)
        {
            // Allocate the Node & Put in the data
            Node newNode = new Node(value);

            // Make next of new Node as head
            newNode.next = _head;

            // Move the head to point to new Node
            _head = newNode;
        }

        public void PushLast(int value)
        {
            // Allocate the Node & Put in the data
            Node node = new Node(value);
            if (_head == null)
            {
                _head = node;
            }
            else
            {
                var current = _head;
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
            Node tnode = _head;
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
            if (_head == null) return;

            if (_head == node)
            {
                _head = _head.next;
                node.next = null;
            }

            var current = _head;
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
            var current = _head;

            if (current == null)
                return;

            while (current != null)
            {
                var next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }

            _head = prev;
        }

        public void ReverseRecurisve()
        {
            ReverseRecurive(_head, null);
        }

        private void ReverseRecurive(Node current, Node prev)
        {
            if (current.next == null)
            {
                _head = current;
                _head.next = prev;
                return;
            }

            var next = current.next;
            current.next = prev;
            ReverseRecurive(next, current);
        }
    }
}
