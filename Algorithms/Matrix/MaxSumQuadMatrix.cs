using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Matrix
{
    public class MaxSumQuadMatrix
    {

        /*
         * given a 2n/2n matrix, find the max sum of top left quad sub matrix after 
         * reversing rows and columns any number of times.
         */

        public static int flippingMatrix(List<List<int>> matrix)
        {
            int sum = 0;
            for (int i = 0; i < matrix.Count / 2; i++)
            {
                for (int j = 0; j < matrix.Count / 2; j++)
                {
                    sum += Math.Max(matrix[i][j],
                        Math.Max(matrix[matrix.Count - 1 - i][matrix.Count - 1 - j],
                        Math.Max(matrix[matrix.Count - 1 - i][j], matrix[i][matrix.Count - 1 - j])));
                }
            }

            return sum;
        }

        //public static void Main(string[] args)
        //{
        //    int q = Convert.ToInt32(Console.ReadLine().Trim());

        //    for (int qItr = 0; qItr < q; qItr++)
        //    {
        //        int n = Convert.ToInt32(Console.ReadLine().Trim());

        //        List<List<int>> matrix = new List<List<int>>();

        //        for (int i = 0; i < 2 * n; i++)
        //        {
        //            matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
        //        }

        //        int result = MaxSumQuadMatrix.flippingMatrix(matrix);

        //        Console.WriteLine(result);
        //    }

        //    Console.Read();
            //}

        }

}