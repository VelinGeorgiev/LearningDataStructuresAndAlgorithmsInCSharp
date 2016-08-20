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
    }
}
