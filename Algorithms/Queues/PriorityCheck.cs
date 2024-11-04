using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Queues;

public class PriorityCheck
{
	/// <summary>
	/// Given the sweetness of a number of cookies (A) and a cutoff sweetness (k), two cookies with the least sweetness are repeatedly mixed
	/// (1 * LeastSweetCookie + 2 * 2ndLeastSweetCookie) <= k. determine the minimum number of operations required
	/// If it is not possible, return -1.
	/// </summary>
	/// <param name="k"></param>
	/// <param name="A"></param>
	/// <returns></returns>
	public static int cookies(int k, List<int> A)
	{
		var q = new PriorityQueue<int, int>();
		var min = int.MaxValue;
		foreach(var item in A){
			if(item >= k){
				min = Math.Min(min, item);
				continue;
			}

			q.Enqueue(item, item);
		}

		var result = 0;
		while(q.Count > 0 && q.Peek() < k){
			if(q.Count == 1 && min == int.MaxValue) return -1;
			var first = q.Dequeue();
			var second = q.Count == 0 ? min : q.Dequeue();
			var sum = first + (2*second);
			if(sum >= k){
				min = Math.Min(min, sum);
			}
			else{
				q.Enqueue(sum, sum);
			}

			result++;
		}
		
		return result;
	}

/*
8 90
13 47 74 12 89 74 18 38
*/

	// public static void Main(string[] args)
	// {
	//	 string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

	//	 int n = Convert.ToInt32(firstMultipleInput[0]);

	//	 int k = Convert.ToInt32(firstMultipleInput[1]);

	//	 List<int> A = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList();

	//	 int result = PriorityCheck.cookies(k, A);

	//	 Console.WriteLine(result);

	//	 Console.Read();
	// }
}
