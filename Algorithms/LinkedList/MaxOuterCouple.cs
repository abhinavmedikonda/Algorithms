using System;

namespace Algorithms.LinkedList
{
    public class MaxOuterCouple
    {
        class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
            }
        }

        class SinglyLinkedList
        {
            public SinglyLinkedListNode head;
            public SinglyLinkedListNode tail;

            public SinglyLinkedList()
            {
                this.head = null;
                this.tail = null;
            }

            public void InsertNode(int nodeData)
            {
                SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

                if (this.head == null)
                {
                    this.head = node;
                }
                else
                {
                    this.tail.next = node;
                }

                this.tail = node;
            }
        }

        class SinglyLinkedListPrintHelepr
        {
            public static void PrintList(SinglyLinkedListNode node, string sep)
            {
                while (node != null)
                {
                    Console.Write(node.data);

                    node = node.next;

                    if (node != null)
                    {
                        Console.Write(sep);
                    }
                }
            }
        }

        /*
         * given a even lengthed singleLinkedList, find the max of sum(first and last)
         * then digging inside till the center of linkedList
         */

        static int maxOuterCouple(SinglyLinkedListNode head)
        {
            var head1 = head;
            var half = count(head) / 2;

            for (int i = 0; i < half; i++)
            {
                head1 = head1.next;
            }

            var head2 = reverse(head1);

            int max = 0;
            head1 = head;
            for (int i = 0; i < half; i++)
            {
                max = head1.data + head2.data > max ? head1.data + head2.data : max;
                head1 = head1.next;
                head2 = head2.next;
            }

            return max;
        }

        private static int count(SinglyLinkedListNode head)
        {
            var count = 0;

            while (head != null)
            {
                head = head.next;
                count++;
            }

            return count;
        }

        private static SinglyLinkedListNode reverse(SinglyLinkedListNode head)
        {
            SinglyLinkedListNode last = null;

            while (head != null)
            {
                var temp = head.next;
                head.next = last;
                last = head;
                head = temp;
            }

            return last;
        }

/*
8
1
4
3
6
2
7
5
3
*/

        //public static void Main(string[] args)
        //{
        //    SinglyLinkedList head = new SinglyLinkedList();

        //    int headCount = Convert.ToInt32(Console.ReadLine().Trim());

        //    for (int i = 0; i < headCount; i++)
        //    {
        //        int headItem = Convert.ToInt32(Console.ReadLine().Trim());
        //        head.InsertNode(headItem);
        //    }

        //    int result = MaxOuterCouple.maxOuterCouple(head.head);

        //    Console.WriteLine(result);

        //    Console.Read();
        //}
    }
}