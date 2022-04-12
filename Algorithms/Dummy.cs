using System;
using System.Collections.Generic;
using System.Linq;

class Result
{

    /*
     * Complete the 'matchingStrings' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. STRING_ARRAY strings
     *  2. STRING_ARRAY queries
     */

    public static List<int> matchingStrings(List<string> strings, List<string> queries)
    {
        int[] result = new int[queries.Count];
        Dictionary<string, int> hash = new Dictionary<string, int>();

        strings.ForEach(x =>
        {
            if (hash.ContainsKey(x))
            {
                hash.Add(x, 1);
            }
            else
            {
                hash[x]++;
            }
        });

        for (int i = 0; i < queries.Count; i++)
        {
            if (hash.ContainsKey(queries[i]))
            {
                result[i] = hash[queries[i]];
            }

            //while (beginIndex < endIndex)
            //{
            //    int midIndex = (beginIndex + endIndex) / 2;
            //    if (strings[midIndex] == queries[i])
            //    {
            //        result[hash[queries[i]]]++;
            //        break;
            //    }
            //    else if (string.Compare(strings[midIndex], queries[i], new CultureInfo("en-US"), CompareOptions.IgnoreCase) < 0)
            //    {
            //        beginIndex = midIndex;
            //    }
            //    else
            //    {
            //        endIndex = midIndex;
            //    }
            //}
        }

        return result.ToList();
    }

    public static void Main(string[] args)
    {
        int stringsCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> strings = new List<string>();

        for (int i = 0; i < stringsCount; i++)
        {
            string stringsItem = Console.ReadLine();
            strings.Add(stringsItem);
        }

        int queriesCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> queries = new List<string>();

        for (int i = 0; i < queriesCount; i++)
        {
            string queriesItem = Console.ReadLine();
            queries.Add(queriesItem);
        }

        List<int> res = Result.matchingStrings(strings, queries);

        Console.WriteLine(String.Join("\n", res));

        Console.Read();
    }

}
