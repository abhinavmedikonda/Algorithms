using System;
using System.Collections.Generic;
using System.Linq;


namespace Algorithms.Arrays;

public class Pairs
{

    /*
    * determine the number of pairs that have a difference equal to a target value
    */
    public static int pairs(int k, List<int> arr)
    {
        arr.Sort();
        int count = 0, front = 0, back = 1;

        while (back < arr.Count)
        {
            if (arr[back] - arr[front] == k)
            {
                count++;
                back++;
                front++;
            }
            else if (arr[back] - arr[front] < k)
            {
                back++;
            }
            else
            {
                front++;
            }
        }

        return count;
    }

/*
5 2
1 5 3 4 2
*/

    //public static void Main(string[] args)
    //{
    //    string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

    //    int n = Convert.ToInt32(firstMultipleInput[0]);

    //    int k = Convert.ToInt32(firstMultipleInput[1]);

    //    List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

    //    int result = Pairs.pairs(k, arr);

    //    Console.WriteLine(result);
    //    Console.Read();
    //}

}
