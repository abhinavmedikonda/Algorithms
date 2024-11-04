using System;
using System.Linq;

namespace Algorithms.Char
{
	public class FinalSumDigit
	{

		/*
		 * Find final 1 digit after sum of all digits after concatinating string k number of times
		 */

		public static int superDigit(string n, int k)
		{
			var str = Convert.ToInt32(superDigit(n)) * k;
			return Convert.ToInt32(superDigit(str.ToString()));
		}

		private static string superDigit(string n)
		{
			string sum = n.Select(c => c-'0').Sum().ToString();

			if (sum.Length > 1)
			{
				sum = superDigit(sum);
			}
			return sum;
		}

/*
9875 4
*/

		//public static void Main(string[] args)
		//{
		//	string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

		//	string n = firstMultipleInput[0];

		//	int k = Convert.ToInt32(firstMultipleInput[1]);

		//	int result = FinalSumDigit.superDigit(n, k);

		//	Console.WriteLine(result);
		//	Console.Read();
		//}

	}
}