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