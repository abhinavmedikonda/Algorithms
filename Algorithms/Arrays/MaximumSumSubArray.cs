using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Arrays
{
    //positive numbers maximum sum
    public class MaximumSumSubArray
    {

        /*
         * Return maxSumSubArray and maxSumSubSequence for given array.
         */

        public static List<int> maxSubarray(List<int> arr)
        {
            int subArrSum = 0, maxSubArrSum = int.MinValue, subSeqSum = 0, maxSubSeqSum = int.MinValue;

            for (int i = 0; i < arr.Count; i++)
            {
                subArrSum += arr[i];
                if (subArrSum > maxSubArrSum)
                {
                    maxSubArrSum = subArrSum;
                }
                if (subArrSum < 0)
                {
                    subArrSum = 0;
                }

                if (arr[i] > 0)
                {
                    subSeqSum = Math.Max(arr[i], subSeqSum + arr[i]);
                }
                else
                {
                    subSeqSum = Math.Max(arr[i], maxSubSeqSum);
                }

                maxSubSeqSum = subSeqSum;
            }

            return new List<int> { maxSubArrSum, maxSubSeqSum };
        }

/*
2 
4 
1 2 3 4
6
2 -1 2 3 4 -5
*/

        //public static void Main(string[] args)
        //{
        //    int t = Convert.ToInt32(Console.ReadLine().Trim());

        //    for (int tItr = 0; tItr < t; tItr++)
        //    {
        //        int n = Convert.ToInt32(Console.ReadLine().Trim());

        //        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        //        List<int> result = MaximumSumSubArray.maxSubarray(arr);

        //        Console.WriteLine(String.Join(" ", result));
        //    }

        //    Console.Read();
        //}
    }
}