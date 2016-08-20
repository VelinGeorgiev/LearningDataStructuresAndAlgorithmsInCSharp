using System.Collections.Generic;

namespace Learning.InterviewQuestions.LinkedLists
{
    public class QNode
    {
        public int data { get; set; }
        public QNode next { get; set; }

        public QNode(int value)
        {
            data = value;
            next = null;
        }
    }

    public class QueueLinkedListImplementation
    {
        public QNode head { get; private set; }
        public QNode tail { get; private set; }

        public IList<int> list { get; set; }

        public QueueLinkedListImplementation()
        {
            head = null;
            tail = null;
            list = new List<int>();
        }

        public void Enqueue(int data)
        {
            QNode temp = new QNode(data);

            if (head == null)
            {
                head = tail = temp;
            }
            else
            {
                tail.next = temp;
                tail = temp;
            }
        }

        public QNode Dequeue()
        {
            if (head == null) return null;

            QNode temp = head;

            head = head.next;
            if (head == null)  tail = null;

            return temp;
        }

        public IList<int> PrintQueue()
        {
            QNode temp = head;
            list = new List<int>();

            while (temp != null)
            {
                list.Add(temp.data);
                temp = temp.next;
            }
            return list;
        }
    }
}
