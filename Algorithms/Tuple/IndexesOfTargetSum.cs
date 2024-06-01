using System;
using System.Collections.Generic;
using System.Linq;
using item = (int value, int index); //annonymous entity

namespace Algorithms.Tuple
{
    public class IndexesOfTargetSum
    {
        /// find the indices of elements which sum up to a target m
        /// Complete the 'icecreamParlor' function below
        public static List<int> indexesOfTargetSum(int m, List<int> arr)
        {
            var itemsList = new List<item>();
        
            for(int i=1; i<=arr.Count; i++){
                itemsList.Add(new item{value = arr[i-1], index = i});
            }
            
            itemsList.Sort((a, b) => a.value < b.value ? -1 : 1);
            // itemsList = itemsList.OrderBy(x => x.value).ToList();
            
            int l=0, r=itemsList.Count-1;
            
            while(l<r){
                if(itemsList[l].value+itemsList[r].value < m) l++;
                else if(itemsList[l].value+itemsList[r].value > m) r--;
                else break;
            }

            var result = new List<int>{itemsList[l].index, itemsList[r].index};
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
        // public static void Main(string[] args)
        // {
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
        // }
    }


}
