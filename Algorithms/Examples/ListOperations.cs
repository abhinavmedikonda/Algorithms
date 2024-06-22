using System;
using System.Collections.Generic;

namespace Algorithms.Examples;

public class ListOperations
{
    private static void Method(){
        var list = new List<int>{8, 5, 9};
        list.Remove(8); //remove element
        var index = list.FindIndex(x => x == 8);
        if(index >= 0) list.RemoveAt(index); //remove element at index

        Console.Read();
    }

    // public static void Main(string[] args){
    //     Method();
    // }
}
