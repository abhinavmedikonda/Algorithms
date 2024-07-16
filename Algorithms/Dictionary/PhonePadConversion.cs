using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Dictionary;

public class PhonePadConversion
{
    private static readonly Dictionary<char, string> hash = new Dictionary<char, string>{
    { '2', "abc" }, { '3', "def" }, { '4', "ghi" }, { '5', "jkl" },
    { '6', "mno" }, { '7', "pqrs" }, { '8', "tuv" }, { '9', "wxyz" },
    };


    public static IList<string> LetterCombinations(string digits)
    {
        return LetterCombinationsRecurssive(string.Empty, digits);
    }

    private static IList<string> LetterCombinationsRecurssive(string letters, string digits)
    {
        if (string.IsNullOrEmpty(digits)) return new List<string> { letters };

        var result = new List<string>();
        foreach (var c in hash[digits[0]])
        {
            result.AddRange(LetterCombinationsRecurssive(letters + c, digits.Substring(1, digits.Length - 1)));
        }

        return result;
    }

/*
645
*/

    //public static void Main(string[] args)
    //{
    //    string str = Console.ReadLine().Trim();

    //    var response = PhonePadConversion.LetterCombinations(str);

    //    response.ToList().ForEach(x => Console.WriteLine(x));

    //    Console.Read();
    //}
}