using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Stacks
{
	public class EqualStackHeight
	{

		/*
		 * given lists representing 3 stacks with item heights sequencing bottom to top
		 * return the height when all 3 stacks are equal
		 */

		public static int EqualStacks(List<int> h1, List<int> h2, List<int> h3)
		{
			int h1Sum = h1.Sum(), h2Sum = h2.Sum(), h3Sum = h3.Sum();
		
			while(h1Sum!=h2Sum || h2Sum!=h3Sum){
				var min = Math.Min(h1Sum,Math.Min(h2Sum, h3Sum));
				
				if(h1Sum > min){
					h1Sum -= h1[0];
					h1.RemoveAt(0);
				}
				if(h2Sum > min){
					h2Sum -= h2[0];
					h2.RemoveAt(0);
				}
				if(h3Sum > min){
					h3Sum -= h3[0];
					h3.RemoveAt(0);
				}
			}
			
			return h1Sum;
		}

/*
5 3 4
3 2 1 1 1
4 3 2
1 1 4 1
*/

		// public static void Main(string[] args)
		// {
		//	string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

		//	int n1 = Convert.ToInt32(firstMultipleInput[0]);

		//	int n2 = Convert.ToInt32(firstMultipleInput[1]);

		//	int n3 = Convert.ToInt32(firstMultipleInput[2]);

		//	List<int> h1 = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(h1Temp => Convert.ToInt32(h1Temp)).ToList();

		//	List<int> h2 = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(h2Temp => Convert.ToInt32(h2Temp)).ToList();

		//	List<int> h3 = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(h3Temp => Convert.ToInt32(h3Temp)).ToList();

		//	int result = EqualStackHeight.EqualStacks(h1, h2, h3);

		//	Console.WriteLine(result);

		//	Console.Read();
		// }
	}
}