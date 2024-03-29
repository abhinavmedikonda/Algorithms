﻿using System;
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
            int diag1 = 0, diag2 = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                diag1 += arr[i][i];
                diag2 += arr[i][arr.Count - 1 - i];
            }

            return Math.Abs(diag1 - diag2);
        }

/*
3
11 2 4
4 5 6
10 8 -12
*/

        //public static void Main(string[] args)
        //{
        //    int n = Convert.ToInt32(Console.ReadLine().Trim());

        //    List<List<int>> arr = new List<List<int>>();

        //    for (int i = 0; i < n; i++)
        //    {
        //        arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        //    }

        //    int result = DiagonalDifference.diagonalDifference(arr);

        //    Console.WriteLine(result);
        //    Console.Read();
        //}

    }

}