using System;
using System.Collections.Generic;
using System.Linq;


namespace Algorithms.Intervals;

public static class MergeOverlaps
{

	/// <summary>
	/// Merge overlapping intervals
	/// </summary>
	public static List<List<int>> mergeOverlaps(List<List<int>> arr)
	{
		arr.Sort((a, b) => a[0] < b[0] ? -1 : 1);

		for(int i=0; i<arr.Count-1; i++){
			if(arr[i][1] > arr[i+1][0]){
				arr[i][1] = arr[i+1][1];
				arr.RemoveAt(i+1);
			}
		}

		return arr;
	}

/*
4
1 3
8 10
2 6
15 18
*/

	// public static void Main(string[] args)
	// {
	// 	int n = Convert.ToInt32(Console.ReadLine().Trim());
	// 	var intervals = new List<List<int>>();
	// 	for(int i=0; i<n; i++){
	// 			intervals.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
	// 	}

	// 	Console.WriteLine();
	// 	foreach (var item in MergeOverlaps.mergeOverlaps(intervals))
	// 	{
	// 		Console.WriteLine(string.Join(' ', item));
	// 	}
	// }

}
