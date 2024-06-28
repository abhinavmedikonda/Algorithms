using System;
using System.Collections.Generic;
using System.Linq;
using element = (int value, int index);

namespace Algorithms.Examples;

public class Anonymous
{

    private static void Method(){
        var elements = new List<element>{new element{value = 7, index = 0}, new element{value = 4, index = 1}};
        var test = elements.Where(x => x.value>10);

        Console.Read();
    }

    // public static void Main(string[] args){
    //     Method();
    // }

}
