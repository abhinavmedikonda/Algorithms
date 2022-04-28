using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Arrays
{
    public class SumIndicies
    {

        /*
         * return indicies of sum of 2 numbers equal to m
         */

        public static List<int> sumIndicies(int m, List<int> arr)
        {
            Dictionary<int, int> hash1 = new Dictionary<int, int>(), hash2 = new Dictionary<int, int>();

            //foreach with index
            foreach (var (item, i) in arr.Select((x, i) => (x, i)))
            {
                if (!hash1.ContainsKey(item))
                {
                    hash1[item] = i + 1;
                }
                else if (!hash2.ContainsKey(item))
                {
                    hash2[item] = i + 1;
                }
            }
            arr.Sort();

            for (int i = 0, j = arr.Count - 1; i < j;)
            {
                if (arr[i] + arr[j] == m)
                {
                    if (arr[i] == arr[j])
                    {
                        return new List<int> { hash1[arr[i]], hash2[arr[j]] };
                    }
                    else if (hash1[arr[i]] < hash1[arr[j]])
                    {
                        return new List<int> { hash1[arr[i]], hash1[arr[j]] };
                    }
                    else
                    {
                        return new List<int> { hash1[arr[j]], hash1[arr[i]] };
                    }
                }
                else if (arr[i] + arr[j] > m)
                {
                    j--;
                }
                else
                {
                    i++;
                }
            }

            return null;
        }

/*
2
4
5
1 4 5 3 2
4
4
2 2 4 3
*/

        //public static void Main(string[] args)
        //{
        //    int t = Convert.ToInt32(Console.ReadLine().Trim());

        //    for (int tItr = 0; tItr < t; tItr++)
        //    {
        //        int m = Convert.ToInt32(Console.ReadLine().Trim());

        //        int n = Convert.ToInt32(Console.ReadLine().Trim());

        //        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        //        List<int> result = SumIndicies.sumIndicies(m, arr);

        //        Console.WriteLine(String.Join(" ", result));
        //    }

        //    Console.Read();
        //}
    }
}