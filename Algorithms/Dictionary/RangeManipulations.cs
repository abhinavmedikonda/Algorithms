using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Dictionary;

public class RangeManipulations
{
    public static long Manipulate(int n, List<List<int>> queries)
    {
        var hash = new Dictionary<int, long>();
        
        foreach(var item in queries){
            Manipulate(hash, item);
        }
        
        var max = 0L;
        var sum = 0L;
        for(int i=1; i<=n+1; i++){
            if(hash.ContainsKey(i)){
                sum += hash[i];
                max = Math.Max(max, sum);
            }
        }
        
        return max;
    }
    
    private static void Manipulate(Dictionary<int, long> hash, List<int> query)
    {
        if(hash.ContainsKey(query[0])){
            hash[query[0]] += query[2];
        }
        else{
            hash[query[0]] = query[2];
        }
        
        if(hash.ContainsKey(query[1]+1)){
            hash[query[1]+1] -= query[2];
        }
        else{
            hash[query[1]+1] = query[2]*-1;
        }
    }

/*
10 4
2 6 8
3 5 7
1 8 1
5 9 15
*/

    // public static void Main(string[] args)
    // {
    //    string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

    //     int n = Convert.ToInt32(firstMultipleInput[0]);

    //     int m = Convert.ToInt32(firstMultipleInput[1]);

    //     List<List<int>> queries = new List<List<int>>();

    //     for (int i = 0; i < m; i++)
    //     {
    //         queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
    //     }

    //     long result = RangeManipulations.Manipulate(n, queries);

    //     Console.WriteLine(result);

    //     Console.Read();
    // }
}
