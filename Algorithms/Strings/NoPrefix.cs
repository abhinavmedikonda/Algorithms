using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Strings
{
    public class NoPrefix
    {
        //public static void noPrefix(List<string> words)
        //{
        //    for (int i = 0; i < words.Count; i++)
        //    {
        //        if (words.Where((s, index) => index != i).Where(s => words[i].StartsWith(s)).ToList().Count > 0)
        //        {
        //            Console.WriteLine("BAD SET");
        //            Console.WriteLine(words[i]);
        //            return;
        //        }
        //    }

        //    Console.WriteLine("GOOD SET");
        //}

        /// <summary>
        /// determine first string in the list which has a prefix of another string 
        /// </summary>
        /// <param name="words"></param>
        public static void noPrefix(List<string> words)
        {
            var hash = new Dictionary<string, int>();

            for (int i = 0; i < words.Count; i++)
            {
                if (!hash.ContainsKey(words[i]))
                {
                    hash.Add(words[i], i);
                }
            }

            words = words.Distinct().ToList();
            words.Sort();

            List<string> badList = new List<string>();

            for (int i = 0, j = 1; j < words.Count; j++)
            {
                if (words[j].StartsWith(words[i]))
                {
                    badList.Add(words[j]);
                }
                else if (j - i == 1)
                {
                    i++;
                }
                else
                {
                    i++;
                    j--;
                }
            }

            if (badList.Count == 0)
            {
                Console.WriteLine("GOOD SET");
            }
            else
            {
                Console.WriteLine("BAD SET");
                Console.WriteLine(badList.OrderBy(x => hash[x]).First());
            }
        }

/*
7
aab
defgab
abcde
aabcde
cedaaa
bbbbbbbbbb
jabjjjad
*/

        //public static void Main(string[] args)
        //{
        //    int n = Convert.ToInt32(Console.ReadLine().Trim());

        //    List<string> words = new List<string>();

        //    for (int i = 0; i < n; i++)
        //    {
        //        string wordsItem = Console.ReadLine();
        //        words.Add(wordsItem);
        //    }

        //    NoPrefix.noPrefix(words);

        //    Console.Read();
        //}

    }
}