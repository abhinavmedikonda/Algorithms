using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Examples;

public class StringExamples
{
    private static void Method(){
        var str = string.Concat(Enumerable.Repeat('1', 10)); //repeat a characger
        Console.WriteLine(str);

        str = string.Concat(Enumerable.Repeat("123", 3)); //repeat a string
        Console.WriteLine(str);

        Console.Read();
    }

    // public static void Main(string[] args){
    //     Method();
    // }
}
