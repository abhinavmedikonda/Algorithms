using System;

namespace Algorithms.LinkedList
{
    public class ReverseDoublyLinkedList
    {

        class DoublyLinkedListNode
        {
            public int data;
            public DoublyLinkedListNode next;
            public DoublyLinkedListNode prev;

            public DoublyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
                this.prev = null;
            }
        }

        class DoublyLinkedList
        {
            public DoublyLinkedListNode head;
            public DoublyLinkedListNode tail;

            public DoublyLinkedList()
            {
                this.head = null;
                this.tail = null;
            }

            public void InsertNode(int nodeData)
            {
                DoublyLinkedListNode node = new DoublyLinkedListNode(nodeData);

                if (this.head == null)
                {
                    this.head = node;
                }
                else
                {
                    this.tail.next = node;
                    node.prev = this.tail;
                }

                this.tail = node;
            }
        }

        static void PrintDoublyLinkedList(DoublyLinkedListNode node, string sep)
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

        /*
            * Complete the 'reverse' function below.
            *
            * The function is expected to return an INTEGER_DOUBLY_LINKED_LIST.
            * The function accepts INTEGER_DOUBLY_LINKED_LIST llist as parameter.
            */

        /*
            * For your reference:
            *
            * DoublyLinkedListNode
            * {
            *     int data;
            *     DoublyLinkedListNode next;
            *     DoublyLinkedListNode prev;
            * }
            *
            */

        static DoublyLinkedListNode reverse(DoublyLinkedListNode llist)
        {
            DoublyLinkedListNode left = null;

            while (llist != null)
            {
                var temp = llist.next;
                llist.next = llist.prev;
                llist.prev = temp;
                left = llist;
                llist = temp;
            }

            return left;
        }

/*
1
5
1
2
3
4
5
*/

        //static void Main(string[] args)
        //{
        //    int t = Convert.ToInt32(Console.ReadLine());

        //    for (int tItr = 0; tItr < t; tItr++)
        //    {
        //        DoublyLinkedList llist = new DoublyLinkedList();

        //        int llistCount = Convert.ToInt32(Console.ReadLine());

        //        for (int i = 0; i < llistCount; i++)
        //        {
        //            int llistItem = Convert.ToInt32(Console.ReadLine());
        //            llist.InsertNode(llistItem);
        //        }

        //        DoublyLinkedListNode llist1 = ReverseDoublyLinkedList.reverse(llist.head);

        //        PrintDoublyLinkedList(llist1, " ");
        //        Console.WriteLine();
        //    }

        //    Console.Read();
        //}
    }
}