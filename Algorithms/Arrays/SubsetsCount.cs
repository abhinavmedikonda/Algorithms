using System;
using System.Collections.Generic;
using System.Linq;


namespace Algorithms.Arrays;

public class SubsetsCount
{

	/*
	* given a list of weights and weight limit k
	* find how many no.of subsets can pass the criteria max(subset)-min(subset) <= k
	*/
	public static long countPossibleSegments(int k, List<int> weights)
	{
		var result = 0;

		for (int i = 0; i < weights.Count; i++)
		{
			int max = int.MinValue, min = int.MaxValue;

			for (int j = i; j < weights.Count; j++)
			{
				if (weights[j] > max) max = weights[j];
				if (weights[j] < min) min = weights[j];
				if (max - min <= k) result++;
			}
		}

		return result;
	}

	//public static long countPossibleSegments(int k, List<int> weights)
	//{
	//	var result = 0;

	//	for (int i = 0; i < weights.Count; i++)
	//	{
	//		for (int j = i; j < weights.Count; j++)
	//		{
	//			if (weights.GetRange(i, j - i + 1).Max() - weights.GetRange(i, j - i + 1).Min() <= k) result++;
	//		}
	//	}

	//	return result;
	//}

/*
3
3
1
5
4
*/

	//public static void Main(string[] args)
	//{
	//	int k = Convert.ToInt32(Console.ReadLine().Trim());

	//	int weightsCount = Convert.ToInt32(Console.ReadLine().Trim());

	//	List<int> weights = new List<int>();

	//	for (int i = 0; i < weightsCount; i++)
	//	{
	//		int weightsItem = Convert.ToInt32(Console.ReadLine().Trim());
	//		weights.Add(weightsItem);
	//	}

	//	long result = SubsetsCount.countPossibleSegments(k, weights);

	//	Console.WriteLine(result);

	//	Console.Read();
	//}
}
