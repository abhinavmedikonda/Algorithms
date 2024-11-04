using System;

namespace Algorithms.LinkedList
{
	public class ReverseSinglyLinkedList
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
			* Complete the 'reverse' function below.
			*
			* The function is expected to return an INTEGER_SINGLY_LINKED_LIST.
			* The function accepts INTEGER_SINGLY_LINKED_LIST llist as parameter.
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

		static SinglyLinkedListNode reverse(SinglyLinkedListNode llist)
		{
			SinglyLinkedListNode left = null;

			while (llist != null)
			{
				var temp = llist.next;
				llist.next = left;
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
		//	int tests = Convert.ToInt32(Console.ReadLine());

		//	for (int testsItr = 0; testsItr < tests; testsItr++)
		//	{
		//		SinglyLinkedList llist = new SinglyLinkedList();

		//		int llistCount = Convert.ToInt32(Console.ReadLine());

		//		for (int i = 0; i < llistCount; i++)
		//		{
		//			int llistItem = Convert.ToInt32(Console.ReadLine());
		//			llist.InsertNode(llistItem);
		//		}

		//		SinglyLinkedListNode llist1 = ReverseSinglyLinkedList.reverse(llist.head);

		//		PrintSinglyLinkedList(llist1, " ");
		//		Console.WriteLine();
		//	}

		//	Console.Read();
		//}
	}
}