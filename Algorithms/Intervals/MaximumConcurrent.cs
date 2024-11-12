using System;
using System.Collections.Generic;
using System.Linq;


namespace Algorithms.Intervals;

public static class MaximumConcurrent
{

	/// <summary>
	/// Find the maximum concurrent intervals
	/// </summary>
	public static int maximumConcurrent(List<List<int>> arr)
	{
		var start = arr;
		var end = arr;
		start.Sort((a, b) => a[0] < b[0] ? -1 : 1);
		end.Sort((a, b) => a[1] < b[1] ? -1 : 1);

		int returns=0, concurrent=0;
		// var q = new Queue<int>(end.Select(x => x[1]));
		// for(int i=0; i<arr.Count-1; i++){
		// 	concurrent++;
		// 	returns = Math.Max(returns, concurrent);
		// 	while(q.Peek() <= start[i][0]){
		// 		concurrent--;
		// 		q.Dequeue();
		// 	}
		// }

		int l=0, r=0;
		while(l<start.Count){
			if(start[l][0] <= end[r][1]){
				concurrent++;
				l++;
			}
			else{
				concurrent--;
				r++;
			}

			returns = Math.Max(returns, concurrent);
		}

		return returns;
	}

/*
6
1 5
4 7
2 6
4 5
6 8
5 6
*/

	// public static void Main(string[] args)
	// {
	// 	int n = Convert.ToInt32(Console.ReadLine().Trim());
	// 	var intervals = new List<List<int>>();
	// 	for(int i=0; i<n; i++){
	// 			intervals.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
	// 	}

	// 	Console.WriteLine(MaximumConcurrent.maximumConcurrent(intervals));
	// }

}
