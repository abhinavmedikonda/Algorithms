using System;
using System.Collections.Generic;
using System.IO;

namespace Algorithms.Char
{
    public class Pangrams
    {

        /*
         * check if a string is pangram or not.
         */
        public static string pangrams(string s)
        {
            var hash = new HashSet<char>();

            foreach (var c in s)
            {

                if(char.IsLetter(c)){
                    if(!hash.Contains(char.ToUpper(c)))
                        hash.Add(char.ToUpper(c));
                }
                // if (c > 64 && c < 91 && !hash.Contains(c))
                // {
                //     hash.Add(c);
                // }
                // else if (c > 96 && c < 123 && !hash.Contains((char)(c - 32)))
                // {
                //     hash.Add((char)(c - 32));
                // }
            }

            return hash.Count == 26 ? "pangram" : "not pangram";
        }

/*
We promptly judged antique ivory buckles for the next prize
*/

        // public static void Main(string[] args)
        // {
        //    string s = Console.ReadLine();

        //    string result = Pangrams.pangrams(s);

        //    Console.WriteLine(result);
        //    Console.Read();
        // }

    }
}