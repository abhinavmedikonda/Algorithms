using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Tuple
{
    public class IndexesOfTargetSum
    {
        /// find the indices of elements which sum up to a target m
        /// Complete the 'icecreamParlor' function below
        public static List<int> indexesOfTargetSum(int m, List<int> arr)
        {
            var tupleList = new List<Tuple<int, int>>();

            for (int i = 0; i < arr.Count; i++)
            {
                tupleList.Add(new Tuple<int, int>(arr[i], i));
            }

            var sortedlist = tupleList.OrderBy(x => x.Item1).ToList();


            int l = 0, r = arr.Count - 1;

            while (l < r)
            {
                if (sortedlist[l].Item1 + sortedlist[r].Item1 > m)
                {
                    r--;
                }
                else if (sortedlist[l].Item1 + sortedlist[r].Item1 < m)
                {
                    l++;
                }
                else
                {
                    break;
                }
            }

            var result = new List<int> { sortedlist[l].Item2, sortedlist[r].Item2 };
            result.Sort();
            return result;
        }

/*
2
200
7
150 24 79 50 88 345 3
8
8
2 1 9 4 4 56 90 3
*/
        //public static void Main(string[] args)
        //{
        //    int t = Convert.ToInt32(Console.ReadLine().Trim());

        //    for (int tItr = 0; tItr < t; tItr++)
        //    {
        //        int m = Convert.ToInt32(Console.ReadLine().Trim());

        //        int n = Convert.ToInt32(Console.ReadLine().Trim());

        //        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        //        List<int> result = indexesOfTargetSum(m, arr);

        //        Console.WriteLine(String.Join(" ", result));
        //    }

        //    Console.Read();
        //}
    }


}
