using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Dictionary
{
    public class NoOfCharacters
    {

        /*
         * all characters of the string appear the same number of times
         * It is also valid if just 1 character at 1 index is removed
         */

        public static string isValid(string s)
        {
            var hash = new Dictionary<char, int>();

            foreach (var c in s)
            {
                if (hash.ContainsKey(c))
                {
                    hash[c]++;
                }
                else
                {
                    hash.Add(c, 1);
                }
            }

            if (hash.GroupBy(x => x.Value).Count() > 2)
            {
                return "NO";
            }

            if (hash.Where(x => x.Value == hash.Min(y => y.Value)).Count() == 1 &&
                hash.Min(y => y.Value) == 1)
            {
                return "YES";
            }

            if (hash.Max(x => x.Value) - hash.Min(x => x.Value) > 1)
            {
                return "NO";
            }

            if (hash.Max(x => x.Value) - hash.Min(x => x.Value) == 1 &&
                (hash.Where(x => x.Value == hash.Min(y => y.Value)).Count() > 1 &&
                hash.Where(x => x.Value == hash.Max(y => y.Value)).Count() > 1))
            {
                return "NO";
            }

            return "YES";
        }

        // public static string isValid(string s)
        // {
        //     if(s.Length < 4) return "YES";

        //     var hash = new Dictionary<char, int>();
            
        //     foreach(var item in s){
        //         if(!hash.ContainsKey(item)){
        //             hash.Add(item, 0);
        //         }
                
        //         hash[item]++;
        //     }
            
        //     var groups = new SortedList<int, int>();
        //     foreach(var item in hash){
        //         if(!groups.ContainsKey(item.Value)){
        //             groups.Add(item.Value, 0);
        //         }
                
        //         groups[item.Value]++;
        //     }
            
        //     if(groups.Count <= 1) return "YES";
        //     if(groups.Count==2 && groups.Last().Key-groups.First().Key==1 && groups.Last().Value==1){
        //         return "YES";
        //     }
        //     if(groups.Count==2 && groups.First().Key==1 && groups.First().Value==1){
        //         return "YES";
        //     }
            
        //     return "NO";
        // }

/*
abcdefghhgfedecba
*/

        //public static void Main(string[] args)
        //{
        //    string s = Console.ReadLine();

        //    string result = NoOfCharacters.isValid(s);

        //    Console.WriteLine(result);

        //    Console.Read();
        //}

    }
}