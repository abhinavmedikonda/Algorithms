using System;

namespace Algorithms.LinkedList
{
	public class InsertNodeAtPosition
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

		static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep)
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
			* Complete the 'insertNodeAtPosition' function below.
			*
			* The function is expected to return an INTEGER_SINGLY_LINKED_LIST.
			* The function accepts following parameters:
			*  1. INTEGER_SINGLY_LINKED_LIST llist
			*  2. INTEGER data
			*  3. INTEGER position
			*/

		/*
			* For your reference:
			*
			* SinglyLinkedListNode
			* {
			*	 int data;
			*	 SinglyLinkedListNode next;
			* }
			*
			*/

		static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode llist, int data, int position)
		{
			var result = llist;

			for (int i = 0; llist != null && i < position - 1; ++i)
			{
				llist = llist.next;
			}

			if (llist != null)
			{
				var temp = llist.next;
				llist.next = new SinglyLinkedListNode(data);
				llist.next.next = temp;
			}

			return result;
		}

/*
4
1
2
3
4
9
2
*/

		//static void Main(string[] args)
		//{
		//	SinglyLinkedList llist = new SinglyLinkedList();

		//	int llistCount = Convert.ToInt32(Console.ReadLine());

		//	for (int i = 0; i < llistCount; i++)
		//	{
		//		int llistItem = Convert.ToInt32(Console.ReadLine());
		//		llist.InsertNode(llistItem);
		//	}

		//	int data = Convert.ToInt32(Console.ReadLine());

		//	int position = Convert.ToInt32(Console.ReadLine());

		//	SinglyLinkedListNode llist_head = InsertNodeAtPosition.insertNodeAtPosition(llist.head, data, position);

		//	PrintSinglyLinkedList(llist_head, " ");
		//	Console.WriteLine();

		//	Console.Read();
		//}
	}
}