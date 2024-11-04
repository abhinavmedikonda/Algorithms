using System;
using System.Collections.Generic;


namespace Algorithms.Sort
{
	public class BigSorting
	{

		/*
		 * sort big numbers in string format.
		 */

		public static List<string> bigSorting(List<string> unsorted)
		{
			//unsorted.Sort((a, b) =>
			//{
			//	if(a.Length == b.Length)
			//	{
			//		return string.Compare(a, b);
			//	}
			//	else if(a.Length > b.Length)
			//	{
			//		return 1;
			//	}
			//	else
			//	{
			//		return -1;
			//	}
			//});

			unsorted.Sort((b, a) => {
				return string.Compare(new string('0', a.Length - b.Length > 0 ? a.Length - b.Length : 0) + b,
				new string('0', b.Length - a.Length > 0 ? b.Length - a.Length : 0) + a);
			});

			return unsorted;
		}

/*
6
31415926535897932384626433832795829347400152829207326584
174293629304872
3
10
3
5
*/

		//public static void Main(string[] args)
		//{
		//	int n = Convert.ToInt32(Console.ReadLine().Trim());

		//	List<string> unsorted = new List<string>();

		//	for (int i = 0; i < n; i++)
		//	{
		//		string unsortedItem = Console.ReadLine();
		//		unsorted.Add(unsortedItem);
		//	}

		//	List<string> result = BigSorting.bigSorting(unsorted);

		//	Console.WriteLine("\n"+String.Join("\n", result));

		//	Console.Read();
		//}
	}
}