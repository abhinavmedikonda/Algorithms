using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Arrays
{
    public class MaxStockProfit
    {

        /*
         * Find maximum profit earned by buying and selling shares any number of times.
         */

        public static List<int> maxStockProfit(List<int> arr)
        {
            int lastMin = arr[0], last = arr[0], profit = 0;

            for (int i = 1; i < arr.Count; i++)
            {
                if(arr[i] < arr[i-1])
                {
                    profit += arr[i - 1] - lastMin;
                    lastMin = arr[i];
                }

                last = arr[i];

                if(i == arr.Count - 1)
                {
                    profit += arr[i] - lastMin;
                }
            }

            return new List<int> { profit };
        }

/*
2 
8 
1 5 2 3 7 6 4 5
6
10 8 6 5 4 2
*/

        //public static void Main(string[] args)
        //{
        //    int t = Convert.ToInt32(Console.ReadLine().Trim());

        //    for (int tItr = 0; tItr < t; tItr++)
        //    {
        //        int n = Convert.ToInt32(Console.ReadLine().Trim());

        //        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        //        List<int> result = MaxStockProfit.maxStockProfit(arr);

        //        Console.WriteLine(String.Join(" ", result));
        //    }

        //    Console.Read();
        //}
    }
}