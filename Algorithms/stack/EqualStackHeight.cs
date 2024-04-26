using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Stack
{
    public class EqualStackHeight
    {

        /*
         * given lists representing 3 stacks with item heights sequencing bottom to top
         * return the height when all 3 stacks are equal
         */

        public static int EqualStacks(List<int> h1, List<int> h2, List<int> h3)
        {
            Stack<int> s1 = new Stack<int>(new List<int> { 0 }), s2 = new Stack<int>(new List<int> { 0 }), s3 = new Stack<int>(new List<int> { 0 });

            for (int i = h1.Count - 1; i >= 0; i--) s1.Push(s1.Peek() + h1[i]);
            for (int i = h2.Count - 1; i >= 0; i--) s2.Push(s2.Peek() + h2[i]);
            for (int i = h3.Count - 1; i >= 0; i--) s3.Push(s3.Peek() + h3[i]);

            while (Math.Max(s1.Peek(), Math.Max(s2.Peek(), s3.Peek())) != Math.Min(s1.Peek(), Math.Min(s2.Peek(), s3.Peek())))
            {
                if (s1.Peek() > s2.Peek() || s1.Peek() > s3.Peek()) s1.Pop();
                if (s2.Peek() > s1.Peek() || s2.Peek() > s3.Peek()) s2.Pop();
                if (s3.Peek() > s1.Peek() || s3.Peek() > s2.Peek()) s3.Pop();
            }

            return s1.Pop();
        }

/*
5 3 4
3 2 1 1 1
4 3 2
1 1 4 1
*/

        // public static void Main(string[] args)
        // {
        //    string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        //    int n1 = Convert.ToInt32(firstMultipleInput[0]);

        //    int n2 = Convert.ToInt32(firstMultipleInput[1]);

        //    int n3 = Convert.ToInt32(firstMultipleInput[2]);

        //    List<int> h1 = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(h1Temp => Convert.ToInt32(h1Temp)).ToList();

        //    List<int> h2 = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(h2Temp => Convert.ToInt32(h2Temp)).ToList();

        //    List<int> h3 = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(h3Temp => Convert.ToInt32(h3Temp)).ToList();

        //    int result = EqualStackHeight.EqualStacks(h1, h2, h3);

        //    Console.WriteLine(result);

        //    Console.Read();
        // }
    }
}