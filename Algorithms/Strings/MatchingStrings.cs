using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Strings
{
    public class MatchingStrings
    {

        /*
         * determine no.of matching strings of list2 in list1 for each string
         */

        public static List<int> matchingStrings(List<string> strings, List<string> queries)
        {
            //sorting ascending
            strings.Sort((a, b) => string.Compare(a, b, StringComparison.OrdinalIgnoreCase));
            //sorting decending
            strings.Sort((a, b) => string.Compare(b, a, StringComparison.OrdinalIgnoreCase));

            int[] result = new int[queries.Count];
            Dictionary<string, int> hash = new Dictionary<string, int>();

            strings.ForEach(x =>
            {
                if (hash.ContainsKey(x))
                {
                    hash[x]++;
                }
                else
                {
                    hash.Add(x, 1);
                }
            });

            for (int i = 0; i < queries.Count; i++)
            {
                if (hash.ContainsKey(queries[i]))
                {
                    result[i] = hash[queries[i]];
                }
            }

            return result.ToList();
        }

        //public static void Main(string[] args)
        //{
        //    int stringsCount = Convert.ToInt32(Console.ReadLine().Trim());

        //    List<string> strings = new List<string>();

        //    for (int i = 0; i < stringsCount; i++)
        //    {
        //        string stringsItem = Console.ReadLine();
        //        strings.Add(stringsItem);
        //    }

        //    int queriesCount = Convert.ToInt32(Console.ReadLine().Trim());

        //    List<string> queries = new List<string>();

        //    for (int i = 0; i < queriesCount; i++)
        //    {
        //        string queriesItem = Console.ReadLine();
        //        queries.Add(queriesItem);
        //    }

        //    List<int> res = MatchingStrings.matchingStrings(strings, queries);

        //    Console.WriteLine(String.Join("\n", res));

        //    Console.Read();
        //}

    }
}