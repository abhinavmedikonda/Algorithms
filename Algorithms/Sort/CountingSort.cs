using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sort
{
    public class CountingSort
    {

        /*
         * counting sort, does not require comparison. Instead, you create an integer array
         * whose index range covers the entire range of values in your array to sort.
         * Each time a value occurs in the original array, you increment the counter at that index
         */

        public static List<int> countingSort(List<int> arr)
        {
            int[] arrCounter = new int[arr.Max() + 1];
            List<int> sortedList = new List<int>();

            foreach (var i in arr)
            {
                arrCounter[i]++;
            }

            for (int i = 0; i < arrCounter.Length; i++)
            {
                sortedList.AddRange(Enumerable.Repeat(i, arrCounter[i]).ToList());
            }

            return sortedList;
        }

/*
50
25 1 16 8 25 9 12 39 39 25 10 32 44 3 30 27 46 27 32 18 21 40 40 34 24 42 23 41 22 6 50 30 20 1 43 3 33 46 44 9 48 33 16 32 21 13 33 29 15 7
*/

        //public static void Main(string[] args)
        //{
        //    int n = Convert.ToInt32(Console.ReadLine().Trim());

        //    List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        //    List<int> result = CountingSort.countingSort(arr);

        //    Console.WriteLine(String.Join(" ", result));
        //    Console.Read();
        //}

    }
}