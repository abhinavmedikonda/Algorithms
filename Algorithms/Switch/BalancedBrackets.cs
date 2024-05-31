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
            var stack = new Stack<char>();
            var map = new Dictionary<char, char>{ {')', '('}, {']', '['}, {'}', '{'} };
        
            foreach(var c in s){
                switch(c){
                    case '(': case '[': case '{':
                        stack.Push(c);
                        break;
                    case ')': case ']': case '}':
                        if(stack.Count == 0 || map[c] != stack.Pop()){
                            return "NO";
                        }
                    
                        break;
                    default:
                        return "NO";
                }
            }
        
            return stack.Count == 0 ? "YES" : "NO";
        }

/*
3
{(([])[])[]}
{(([])[])[]]}
{(([])[])[]}[]
*/

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