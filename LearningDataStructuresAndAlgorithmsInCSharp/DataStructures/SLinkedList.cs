using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning
{
    public class Node
    {
        public Node Next;
        public Object data;
    }

    class SLinkedList
    {
        private Node head;

        public void printAllNodes()
        {
            Node cur = head;
            while (cur.Next != null)
            {
                Console.WriteLine(cur.data);
                cur = cur.Next;
            }
        }

        public void Add(Object data)
        {
            Node toAdd = new Node();
            toAdd.data = data;
            Node current = head;
            // traverse all nodes (see the print all nodes method for an example)
            current.Next = toAdd;
        }
    }
}
