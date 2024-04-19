using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Matrix
{
    public class DiagonalDifference
    {

        /*
         * Given a square matrix, calculate the absolute difference between the sums of its diagonals. 
         */

        public static int diagonalDifference(List<List<int>> arr)
        {
            int lr=0, rl=0;
        
            for(int i=0; i<arr.Count/2; i++){
                lr += arr[0+i][0+i] + arr[arr.Count-1-i][arr.Count-1-i];
                rl += arr[arr.Count-1-i][0+i] + arr[0+i][arr.Count-1-i];
            }
            
            return Math.Abs(lr-rl);
        }

/*
3
11 2 4
4 5 6
10 8 -12
*/

        // public static void Main(string[] args)
        // {
        //    int n = Convert.ToInt32(Console.ReadLine().Trim());

        //    List<List<int>> arr = new List<List<int>>();

        //    for (int i = 0; i < n; i++)
        //    {
        //        arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        //    }

        //    int result = DiagonalDifference.diagonalDifference(arr);

        //    Console.WriteLine(result);
        //    Console.Read();
        // }

    }

}