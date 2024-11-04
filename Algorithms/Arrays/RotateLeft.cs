using System;
using System.Collections.Generic;
using System.Linq;


namespace Algorithms.Arrays;

public class RotateLeft
{

	/*
	* left rotation operation on an array shifts each of the array's elements to the left
	*/
	public static List<int> rotLeft(List<int> a, int d)
	{
		List<int> result = new List<int>();
		for (int i = 0; i < a.Count; i++)
		{
			result.Add(a[i + d >= a.Count ? i + d - a.Count : i + d]);
		}

		return result;
	}

/*
5 4
1 2 3 4 5
*/

	//public static void Main(string[] args)
	//{
	//	string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

	//	int n = Convert.ToInt32(firstMultipleInput[0]);

	//	int d = Convert.ToInt32(firstMultipleInput[1]);

	//	List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

	//	List<int> result = RotateLeft.rotLeft(a, d);

	//	Console.WriteLine(String.Join(" ", result));
	//	Console.Read();
	//}

}
