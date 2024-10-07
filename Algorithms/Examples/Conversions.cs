using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Examples;

public class Conversions
{
    private static void Method(){
        string[] stringArray = Console.ReadLine().Split(' '); //string to array of strings
        stringArray.ToList().ForEach(x => Console.WriteLine(x));

        IEnumerable<int> genericList = Console.ReadLine().Split(' ').Select(int.Parse); //string to array of integers
        genericList.ToList().ForEach(x => Console.WriteLine(x));

        var str = "12345";
        /*char.GetNumericValue(c) returns double as it takes unicode character as parameter
          '¼' character returns 0.25 */
        var digit = char.GetNumericValue(str[0]);
        Console.WriteLine(digit);

        Console.Read();
    }

    // public static void Main(string[] args){
    //     Method();
    // }
}
