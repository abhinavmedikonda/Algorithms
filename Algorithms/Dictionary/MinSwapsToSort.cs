using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Dictionary;

/// <summary>
/// Find the minimum swaps required to sort a given list(ascending or decending)
/// </summary>
class MinSwapsToSort
{
	public static int minSwapsToSort(List<int> arr)
	{
		var ascending = new List<int>(arr);
		ascending.Sort();
		var decending = new List<int>(ascending);
		decending.Reverse();

		var aCount = countSwaps(arr, ascending);
		var dCount = countSwaps(arr, decending);

		return Math.Min(aCount, dCount);
	}

	private static int countSwaps(List<int> arr, List<int> sorted){
		var result = 0;
		var hash = new Dictionary<int, int>();
		for(int i=0; i<arr.Count; i++){
			hash.Add(arr[i], i);
		}

		for(int i=0; i<arr.Count; i++){
			if(arr[i] != sorted[i]){
				var swapIndex = hash[sorted[i]];
				var temp = arr[i];
				arr[i] = arr[swapIndex];
				arr[swapIndex] = temp;
				temp = hash[arr[i]];
				hash[arr[i]] = hash[arr[swapIndex]];
				hash[arr[swapIndex]] = temp;
				result++;
			}
		}
		
		return result;
	}

/*
5
3 4 2 5 1
*/

	// public static void Main(string[] args)
	// {
	//	 int n = Convert.ToInt32(Console.ReadLine().Trim());

	//	 List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

	//	 int result = MinSwapsToSort.minSwapsToSort(arr);

	//	 Console.WriteLine(result);

	//	 Console.Read();
	// }
}
