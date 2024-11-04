using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Bits
{
	public class FlippingBits
	{

		/*
		 * Return the 32-bit integer after flipping the bits of input
		 */

		public static long flippingBits(long n)
		{
			List<int> bits = new List<int>(Enumerable.Repeat(1, 32));
			int iteration = 0;
			while(n > 0){
				long remainder = n%2;
				n /= 2;
				bits[iteration] = remainder == 0 ? 1 : 0;
				iteration++;
			}
			
			long stage = 1;
			foreach(var item in bits){   
				n += stage*item;
				stage *= 2;
			}
			
			return n;
		}

/*
3
2147483647
1
0
*/

		//public static void Main(string[] args)
		//{
		//	int q = Convert.ToInt32(Console.ReadLine().Trim());

		//	for (int qItr = 0; qItr < q; qItr++)
		//	{
		//		long n = Convert.ToInt64(Console.ReadLine().Trim());

		//		long result = FlippingBits.flippingBits(n);

		//		Console.WriteLine(result);
		//	}

		//	Console.Read();
		//}

	}
}