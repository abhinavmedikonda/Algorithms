using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Examples;

public class SortedOperations
{
    private static void Method(){
        var list = new List<int>{8, 5, 9};
        var sList = new SortedList<int, int>();
        foreach(var item in list){
            if(sList.ContainsKey(item)){
                sList[item]++;
            }
            else{
                sList.Add(item, 1);
            }
        }

        Console.WriteLine(sList.First().Value);
        sList.Remove(sList.First().Key);
        sList[sList.First().Key]--;

        var sSet = new SortedSet<int>(list);
        Console.WriteLine(sSet.First());
        sSet.Remove(sSet.First());

        Console.Read();
    }

    // public static void Main(string[] args){
    //     Method();
    // }
}
