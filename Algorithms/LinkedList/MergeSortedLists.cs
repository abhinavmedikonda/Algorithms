using System;

namespace Algorithms.LinkedList
{
	public class MergeSortedLists
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
		 *
		 */
		static SinglyLinkedListNode mergeSortedLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
		{
			var result = new SinglyLinkedListNode(default);
			var node = result;
			
			while(head1 != null && head2 != null){
				if(head1.data < head2.data){
					node.next = head1;
					head1 = head1.next;
				}
				else{
					node.next = head2;
					head2 = head2.next;
				}
				
				node = node.next;
			}

			if(head1 != null){
				node.next = head1;
			}
			else{
				node.next = head2;
			}
			
			return result.next;
		}

/*
1
3
1
2
3
2
3
4
*/

		// static void Main(string[] args)
		// {
		//	int tests = Convert.ToInt32(Console.ReadLine());

		//	for (int testsItr = 0; testsItr < tests; testsItr++)
		//	{
		//		SinglyLinkedList llist1 = new SinglyLinkedList();

		//		int llist1Count = Convert.ToInt32(Console.ReadLine());

		//		for (int i = 0; i < llist1Count; i++)
		//		{
		//			int llist1Item = Convert.ToInt32(Console.ReadLine());
		//			llist1.InsertNode(llist1Item);
		//		}

		//		SinglyLinkedList llist2 = new SinglyLinkedList();

		//		int llist2Count = Convert.ToInt32(Console.ReadLine());

		//		for (int i = 0; i < llist2Count; i++)
		//		{
		//			int llist2Item = Convert.ToInt32(Console.ReadLine());
		//			llist2.InsertNode(llist2Item);
		//		}

		//		SinglyLinkedListNode llist3 = mergeSortedLists(llist1.head, llist2.head);

		//		PrintSinglyLinkedList(llist3, " ");
		//		Console.WriteLine();
		//	}

		//	Console.Read();
		// }
	}
}