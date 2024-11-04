using System;
using System.Collections.Generic;
using System.Linq;


namespace Algorithms.Arrays;

public class BinarySearchRotated
{

	/// <summary>
	/// binary search a number in a sorted rotated array
	/// </summary>
	public static int search(int n, List<int> arr)
	{
		int l=0, r=arr.Count-1;

		while(l <= r){
			var m = (l+r)/2;

			if(arr[m] == n){
				return m;
			}

			if(arr[l] < arr[m]){
				if(arr[l] <= n && n <= arr[m]){
					r = m-1;
				}
				else{
					l = m+1;
				}
			}
			else{
				if(arr[m] <= n && n <= arr[r]){
					l = m+1;
				}
				else{
					r = m-1;
				}
			}
		}

		return -1;
	}

/*
2
7
6
4 5 6 7 0 1 2
7
1
4 5 6 7 0 1 2
*/

	// public static void Main(string[] args)
	// {
	//	int t = Convert.ToInt32(Console.ReadLine().Trim());

	//	for (int tItr = 0; tItr < t; tItr++)
	//	{
	//		int m = Convert.ToInt32(Console.ReadLine().Trim());

	//		int n = Convert.ToInt32(Console.ReadLine().Trim());

	//		List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

	//		int result = BinarySearchRotated.search(n, arr);

	//		Console.WriteLine(result);
	//	}

	//	Console.Read();
	// }
}
