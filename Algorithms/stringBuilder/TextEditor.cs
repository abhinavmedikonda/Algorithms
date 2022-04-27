using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.stringBuilder
{
    /// <summary>
    /// For n number of operations if
    /// 1. append string to the end
    /// 2. remove last specified number of characters
    /// 3. print character specified at index
    /// 4. undo last edit made
    /// </summary>
    public class TextEditor
    {

/*
8
1 abc
3 3
2 3
1 xy
3 2
4
4
3 1
*/

        //static void Main(String[] args)
        //{
        //    int doCount = Convert.ToInt32(Console.ReadLine().Trim());
        //    StringBuilder sb = new StringBuilder();
        //    Stack<string> stack = new Stack<string>();

        //    for (int i = 0; i < doCount; i++)
        //    {
        //        var operation = Console.ReadLine().Trim().Split(' ').ToList();

        //        switch (operation[0])
        //        {
        //            case "1":
        //                stack.Push(sb.ToString());
        //                sb.Append(operation[1]);
        //                break;
        //            case "2":
        //                stack.Push(sb.ToString());
        //                sb.Remove(sb.Length - Convert.ToInt32(operation[1]), Convert.ToInt32(operation[1]));
        //                break;
        //            case "3":
        //                Console.WriteLine(sb.ToString().Substring(Convert.ToInt32(operation[1]) - 1, 1));
        //                break;
        //            case "4":
        //                sb.Clear();
        //                sb.Append(stack.Pop());
        //                break;
        //        }
        //    }

        //    Console.Read();
        //}
    }
}