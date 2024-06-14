using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Arrays;

//positive numbers maximum sum
public class MaximumSumSubArray
{

    /*
    * Return maxSumSubArray and maxSumSubSequence for given array.
    */

    public static List<int> maxSumSubArray(List<int> arr)
    {
        int sum = 0, max = int.MinValue, sequenceMax = 0;
    
        for(int i=0; i<arr.Count; i++){
            sequenceMax = Math.Max(sequenceMax, sequenceMax+arr[i]);
            sum += arr[i];
            max = Math.Max(max, sum);
            if(sum < 0){
                sum = 0;
            }
        }
        
        if(arr.All(x => x<0)){
            sequenceMax = arr.Max();
        }
        
        return new List<int>{max, sequenceMax};
    }

/*
2 
4 
1 2 3 4
6
2 -1 2 3 4 -5
*/

    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            List<int> result = MaximumSumSubArray.maxSumSubArray(arr);

            Console.WriteLine(String.Join(" ", result));
        }

        Console.Read();
    }
}
