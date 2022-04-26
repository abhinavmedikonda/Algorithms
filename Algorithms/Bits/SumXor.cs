using System;
using System.Text;

namespace Algorithms.Bits
{
    public class SumXor
    {

        /*
         * determine total number of numbers for a number whose normal sum is equal ot XOR sum
         */

        public static long sumXor(long n)
        {
            var nBits = getBits(n);
            long result = 0;

            for (long l = 0; l <= n; l++)
            {
                if (Convert.ToInt64(xorSum(nBits, getBits(l, nBits.Length))) == n + l)
                {
                    result++;
                }
            }

            return result;
        }

        private static long xorSum(string nBits, string lBits)
        {
            var xorBits = new StringBuilder();
            long result = 0, calc = 1;

            for (int i = 0; i < nBits.Length; i++)
            {
                if (nBits[i] == lBits[i])
                {
                    xorBits.Append(0);
                }
                else
                {
                    xorBits.Append(1);
                }
            }

            for (int i = xorBits.Length - 1; i >= 0; i--)
            {
                if (xorBits[i] == '1')
                {
                    result += calc;
                }

                calc *= 2;
            }

            return result;
        }

        private static string getBits(long n, int? length = null)
        {
            var sb = new StringBuilder();

            while (n > 0)
            {
                sb.Insert(0, n % 2);
                n /= 2;
            }

            if (length != null)
            {
                sb.Insert(0, new string('0', length.Value - sb.Length));
            }

            return sb.ToString();
        }

        //public static void Main(string[] args)
        //{
        //    long n = Convert.ToInt64(Console.ReadLine().Trim());

        //    long result = SumXor.sumXor(n);

        //    Console.WriteLine(result);

        //    Console.Read();
        //}

    }
}