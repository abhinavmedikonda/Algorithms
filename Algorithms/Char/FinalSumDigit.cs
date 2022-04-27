using System;

namespace Algorithms.Char
{
    public class FinalSumDigit
    {

        /*
         * Find final 1 digit after sum of all digits after concatinating string k number of times
         */

        public static int superDigit(string n, int k)
        {
            long sum = 0;
            foreach (var c in n)
            {
                sum += c - '0';
            }

            return superDigit(sum * k);
        }

        private static int superDigit(long n)
        {
            if (n.ToString().Length == 1)
            {
                return (int)n;
            }

            long sum = 0;
            foreach (var c in n.ToString())
            {
                sum += c - '0';
            }

            return superDigit(sum);
        }

/*
9875 4
*/

        //public static void Main(string[] args)
        //{
        //    string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        //    string n = firstMultipleInput[0];

        //    int k = Convert.ToInt32(firstMultipleInput[1]);

        //    int result = FinalSumDigit.superDigit(n, k);

        //    Console.WriteLine(result);
        //    Console.Read();
        //}

    }
}