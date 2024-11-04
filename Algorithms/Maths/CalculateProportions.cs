using System;
using System.Collections.Generic;
using System.Linq;


namespace Algorithms.Maths;

public static class CalculateProportions
{

	/// <summary>
	/// calculate portortions of positive, 0s, negative numbers in the list with 5 decimal values
	/// </summary>
	public static void calculateProportions(List<int> arr)
	{
		float positive = 0, negative = 0, zeros = 0;
		foreach(var item in arr){
			if(item > 0) positive++;
			else if(item < 0) negative++;
			else zeros++;
		}
		
		//float formatting
		Console.WriteLine((positive/arr.Count).ToString("0.000000"));
		Console.WriteLine((negative/arr.Count).ToString("0.000000"));
		Console.WriteLine((zeros/arr.Count).ToString("0.000000"));
	}

/*
6
-4 3 -9 0 4 1
*/

	// public static void Main(string[] args)
	// {
	//	 int n = Convert.ToInt32(Console.ReadLine().Trim());
	//	 List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
	//	 CalculateProportions.calculateProportions(arr);
	// }
}
