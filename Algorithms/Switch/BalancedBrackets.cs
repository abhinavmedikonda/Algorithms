using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Switch
{
    public class BalancedBrackets
    {

        /*
         * determine whether each sequence of brackets is balanced.
         */

        public static string balancedBrackets(string s)
        {
            Stack<char> stack = new Stack<char>();

            foreach (var c in s)
            {
                if (new char[] { '(', '[', '{' }.Contains(c))
                {
                    stack.Push(c);
                    continue;
                }
                else
                {
                    char balance = '0';

                    switch (c)
                    {
                        case ')':
                            balance = '(';
                            break;
                        case ']':
                            balance = '[';
                            break;
                        case '}':
                            balance = '{';
                            break;
                    }

                    if (stack.Count == 0 || balance != stack.Pop())
                    {
                        return "NO";
                    }
                }
            }

            return stack.Count == 0 ? "YES" : "NO";
        }

        //public static void Main(string[] args)
        //{
        //    int t = Convert.ToInt32(Console.ReadLine().Trim());

        //    for (int tItr = 0; tItr < t; tItr++)
        //    {
        //        string s = Console.ReadLine();

        //        string result = BalancedBrackets.balancedBrackets(s);

        //        Console.WriteLine(result);
        //    }

        //    Console.Read();
        //}

    }
}