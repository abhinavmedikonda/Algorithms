using System;
using System.Collections.Generic;
using System.Linq;


namespace Algorithms.Intervals;

public static class FindIntersections
{

	/// <summary>
	/// Find the intersecting intervals in the 2 list of intervals
	/// Note: items in each intervalsList are not overlapping
	/// </summary>
	public static List<List<int>> findIntersections(List<List<int>> intervalsA, List<List<int>> intervalsB)
	{
		intervalsA.Sort((a, b) => a[0] < b[0] ? -1 : 1);
		intervalsB.Sort((a, b) => a[0] < b[0] ? -1 : 1);

		int indexA=0, indexB=0;
		var returns = new List<List<int>>();
		while(indexA<intervalsA.Count && indexB<intervalsB.Count){
			if(intervalsA[indexA][0] > intervalsB[indexB][1]){
				indexB++;
			}
			else if(intervalsB[indexB][0] > intervalsA[indexA][1]){
				indexA++;
			}
			else{
				returns.Add(new List<int>{
					Math.Max(intervalsA[indexA][0], intervalsB[indexB][0]),
					Math.Min(intervalsA[indexA][1], intervalsB[indexB][1])
				});

				if(intervalsA[indexA][1] < intervalsB[indexB][1]){
					indexA++;
				}
				else{
					indexB++;
				}
			}
		}

		return returns;
	}

/*
4
0 2
5 10
13 23
24 25
4
1 5
8 12
15 24
25 26
*/

	// public static void Main(string[] args)
	// {
	// 	int m = Convert.ToInt32(Console.ReadLine().Trim());
	// 	var intervalsA = new List<List<int>>();
	// 	for(int i=0; i<m; i++){
	// 			intervalsA.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
	// 	}

	// 	int n = Convert.ToInt32(Console.ReadLine().Trim());
	// 	var intervalsB = new List<List<int>>();
	// 	for(int i=0; i<n; i++){
	// 			intervalsB.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
	// 	}

	// 	Console.WriteLine();
	// 	foreach (var item in FindIntersections.findIntersections(intervalsA, intervalsB))
	// 	{
	// 		Console.WriteLine(string.Join(' ', item));
	// 	}
	// }

}
