using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Examples;

public class ListOperations
{
    private static void Method(){
        var list = new List<int>{8, 5, 9};
        list.Remove(8); //remove element
        list.RemoveAll(x => x>10); //remove all matching
        var index = list.FindIndex(x => x == 8);
        if(index >= 0) list.RemoveAt(index); //remove element at index
        list.Clear(); //remove everything

        Console.Read();
    }

    // public static void Main(string[] args){
    //     Method();
    // }
}
