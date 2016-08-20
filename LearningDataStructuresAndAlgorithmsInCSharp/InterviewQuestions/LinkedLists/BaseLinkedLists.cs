using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.DataStructures;

namespace Learning.InterviewQuestions.LinkedLists
{
    public class BaseLinkedLists
    {
        // Function to print middle of linked list
        // http://www.geeksforgeeks.org/write-a-c-function-to-print-the-middle-of-the-linked-list/
        public void PrintMiddle()
        {
            Node slow_ptr = head;
            Node fast_ptr = head;
            if (head != null)
            {
                while (fast_ptr != null && fast_ptr.next != null)
                {
                    fast_ptr = fast_ptr.next.next;
                    slow_ptr = slow_ptr.next;
                }
                System.out.println("The middle element is [" +
                                    slow_ptr.data + "] \n");
            }
        }
    }
}
