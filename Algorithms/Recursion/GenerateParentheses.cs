using System;
using System.Collections.Generic;

namespace Algorithms.Recursion
{
    public class GenerateParentheses
    {
        public static void generateParentheses(int n)
        {
            var list = recursiveGenerateParentheses(n, string.Empty, 0);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(list.Count);
        }

        private static List<string> recursiveGenerateParentheses(int n, string str, int left)
        {
            List<string> list = new List<string>();
            if (n > 0)
            {
                list.AddRange(recursiveGenerateParentheses(n - 1, str + '(', left + 1));
            }
            if (left > 0)
            {
                list.AddRange(recursiveGenerateParentheses(n, str + ')', left - 1));
            }
            if (n == 0 && left == 0)
            {
                list.Add(str);
            }

            return list;
        }

/*
6
*/

        //public static void Main(string[] args)
        //{
        //    int n = Convert.ToInt32(Console.ReadLine().Trim());

        //    GenerateParentheses.generateParentheses(n);

        //    Console.Read();
        //}
    }
}
