using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Conversions;

public class Conversions
{
    private static void Method(){
        string[] stringArray = Console.ReadLine().Split(' '); //string to array of strings
        stringArray.ToList().ForEach(x => Console.WriteLine(x));

        IEnumerable<int> genericList = Console.ReadLine().Split(' ').Select(int.Parse); //string to array of integers
        genericList.ToList().ForEach(x => Console.WriteLine(x));

        Console.Read();
    }

    public static void Main(string[] args){
        Method();
    }
}
