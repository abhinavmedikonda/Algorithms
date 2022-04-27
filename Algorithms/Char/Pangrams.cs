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
                if (c > 64 && c < 91 && !hash.Contains(c))
                {
                    hash.Add(c);
                }
                else if (c > 96 && c < 123 && !hash.Contains((char)(c - 32)))
                {
                    hash.Add((char)(c - 32));
                }
            }

            return hash.Count == 26 ? "pangram" : "not pangram";
        }

/*
We promptly judged antique ivory buckles for the next prize
*/

        //public static void Main(string[] args)
        //{
        //    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        //    string s = Console.ReadLine();

        //    string result = Result.pangrams(s);

        //    textWriter.WriteLine(result);

        //    textWriter.Flush();
        //    textWriter.Close();
        //}

    }
}