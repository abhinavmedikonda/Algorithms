using System;
using System.Collections.Generic;

namespace Algorithms.Arrays
{
    public class HourglassSum
    {

        /*
         * Complete the 'hourglassSum' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY arr as parameter.
         */

        public static int hourglassSum(List<List<int>> arr)
        {
            int max = int.MinValue;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    max = Math.Max(max, Sum(arr, i, j));
                }
            }

            return max;
        }

        private static int Sum(List<List<int>> arr, int x, int y)
        {
            int sum = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!(i == 1 && (j == 0 || j == 2)))
                    {
                        sum += arr[x + i][y + j];
                    }
                }
            }

            return sum;
        }

        public static void Main(string[] args)
        {
            List<List<int>> arr = new List<List<int>> {
                new List<int> { -1, -1, 0, -9, -2, -2 },
                new List<int> { -2, -1, -6, -8, -2, -5 },
                new List<int> { -1, -1, -1, -2, -3, -4 },
                new List<int> { -1, -9, -2, -4, -4, -5 },
                new List<int> { -7, -3, -3, -2, -9, -9 },
                new List<int> { -1, -3, -1, -2, -4, -5 }
            };

            //for (int i = 0; i < 6; i++)
            //{
            //    arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
            //}

            int result = HourglassSum.hourglassSum(arr);

            Console.WriteLine(result);
            Console.Read();
        }

    }
}