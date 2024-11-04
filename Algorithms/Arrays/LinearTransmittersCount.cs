using System;
using System.Collections.Generic;
using System.Linq;


namespace Algorithms.Arrays;

public class LinearTransmittersCount
{

	/*
	* consider a liner city, given list of house indices in the array.
	* how many radio tranmitters of range k are needed to cover all the houses
	* if transmitter can only be installed on the houses
	*/ 
	public static int hackerlandRadioTransmitters(List<int> x, int k)
	{
		x.Sort();
		int expectedTransmitter = 0, range = 0, result = 0;
		bool inRange = false;

		for (int i = 0; i < x.Count; i++)
		{
			if (inRange && x[i] > expectedTransmitter)
			{
				range = x[i-1]+k;
				inRange = !inRange;
			}
			if (!inRange && x[i] > range)
			{
				result++;
				expectedTransmitter = x[i]+k;
				inRange = !inRange;
			}
		}

		return result;
	}

/*
7 2
9 5 4 2 6 15 12
*/

	//public static void Main(string[] args)
	//{
	//	string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

	//	int n = Convert.ToInt32(firstMultipleInput[0]);

	//	int k = Convert.ToInt32(firstMultipleInput[1]);

	//	List<int> x = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(xTemp => Convert.ToInt32(xTemp)).ToList();

	//	int result = LinearTransmittersCount.hackerlandRadioTransmitters(x, k);

	//	Console.WriteLine(result);

	//	Console.Read();
	//}
}
