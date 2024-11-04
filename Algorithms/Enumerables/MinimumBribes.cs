using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Enumerables
{
	public class MinimumBribes
	{
		/// <summary>
		/// people are in line for the Wonderland rollercoaster ride.
		/// Each person wears a sticker indicating their initial position in the queue from 1 to n.
		/// Any person can bribe the person directly in front of them to swap positions,
		/// but they still wear their original sticker. One person can bribe at most two others.
		/// Determine the minimum number of bribes that took place to get to a given queue order.
		/// Print the number of bribes, or, if anyone has bribed more than two people, print Too chaotic
		/// </summary>
		/// <param name="q"></param>
		public static void minimumBribes(List<int> q)
		{
			var result = 0;
			var sSet = new SortedSet<int>(Enumerable.Range(1, q.Count));

			for(int i=1; i<=q.Count(); i++){
				var diff = q[i-1]-i;
				
				if(diff > 2){
					Console.WriteLine("Too chaotic");
					return;
				}
				else if(diff > 0){
					result += diff;
				}
				else if(q[i-1] != sSet.First()){
					result++;
				}

				sSet.Remove(q[i-1]);
			}
			
			Console.WriteLine(result);
		}

/*
2
8
5 1 2 3 7 8 6 4
8
1 2 5 3 7 8 6 4
*/

		// public static void Main(string[] args)
		// {
		//	 int t = Convert.ToInt32(Console.ReadLine().Trim());

		//	 for (int tItr = 0; tItr < t; tItr++)
		//	 {
		//		 int n = Convert.ToInt32(Console.ReadLine().Trim());

		//		 List<int> q = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(qTemp => Convert.ToInt32(qTemp)).ToList();

		//		 MinimumBribes.minimumBribes(q);
		//	 }
		// }

	}
}
