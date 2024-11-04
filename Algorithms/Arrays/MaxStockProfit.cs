using System;
using System.Collections.Generic;
using System.Linq;


namespace Algorithms.Arrays;

public class MaxStockProfit
{

	/// <summary>
	/// Find maximum profit earned by buying and selling shares any number of times.
	/// </summary>
	public static List<int> maxStockProfit(List<int> arr)
	{
		int profit = 0;

		for (int i = 1; i < arr.Count; i++)
		{
			// profit = Math.Max(profit, profit+arr[i]-arr[i-1]);

			var change = arr[i]-arr[i-1];
			profit = change > 0 ? profit+change : profit;
		}

		return new List<int> { profit };
	}

/*
2 
8 
1 5 2 3 7 6 4 5
6
10 8 6 5 4 2
*/

	// public static void Main(string[] args)
	// {
	//	int t = Convert.ToInt32(Console.ReadLine().Trim());

	//	for (int tItr = 0; tItr < t; tItr++)
	//	{
	//		int n = Convert.ToInt32(Console.ReadLine().Trim());

	//		List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

	//		List<int> result = MaxStockProfit.maxStockProfit(arr);

	//		Console.WriteLine(String.Join(" ", result));
	//	}

	//	Console.Read();
	// }
}
