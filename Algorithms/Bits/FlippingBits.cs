using System;
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
            long num = n;
            int length = 0;

            var sb = new StringBuilder();

            while (num > 0)
            {
                sb.Insert(0, num % 2);
                num /= 2;
                length++;
            }

            sb.Replace('0', ' ');
            sb.Replace('1', '0');
            sb.Replace(' ', '1');

            sb.Insert(0, new string('1', 32 - length));

            num = 0;
            long power = 1;
            for (int i = 31; i >= 0; i--)
            {
                if (sb[i] == '1')
                {
                    num += power;
                }

                power *= 2;
            }

            return num;
        }

        //public static void Main(string[] args)
        //{
        //    int q = Convert.ToInt32(Console.ReadLine().Trim());

        //    for (int qItr = 0; qItr < q; qItr++)
        //    {
        //        long n = Convert.ToInt64(Console.ReadLine().Trim());

        //        long result = FlippingBits.flippingBits(n);

        //        Console.WriteLine(result);
        //    }

        //    Console.Read();
        //}

    }
}