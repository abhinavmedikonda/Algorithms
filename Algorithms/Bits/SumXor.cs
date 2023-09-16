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

        /*
        5
        */

        //public static void Main(string[] args)
        //{
        //    long n = Convert.ToInt64(Console.ReadLine().Trim());

        //    long result = SumXor.sumXor(n);

        //    Console.WriteLine(result);

        //    Console.Read();
        //}

        /// <summary>
        /// not part of above algorithm, just general bitwise XOR of 2 integers
        /// </summary>
        private static int bitwiseXorTwoIntegers(int a, int b)
        {
            var sba = new StringBuilder();
            var sbb = new StringBuilder();

            while (a > 0 || b > 0)
            {
                if (a == 0 || a % 2 == 0)
                {
                    sba.Insert(0, 0);
                }
                else
                {
                    sba.Insert(0, 1);
                }

                if (b == 0 || b % 2 == 0)
                {
                    sbb.Insert(0, 0);
                }
                else
                {
                    sbb.Insert(0, 1);
                }

                a /= 2;
                b /= 2;
            }

            int twoMultiple = 1, result = 0;

            for (int i = sba.Length - 1; i >= 0; i--)
            {
                if (sba[i] != sbb[i])
                {
                    result += twoMultiple;
                }

                twoMultiple *= 2;
            }

            return result;
        }

        /// <summary>
        /// not part of above algorithm, just general bitwise XOR of 2 strings
        /// </summary>
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

    }
}