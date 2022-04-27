using System;
using System.Collections.Generic;
using System.Linq;
namespace Algorithms.Switch
{
    public class QueueWithStacks
    {

/*
 * 10
1 42
2
1 14
3
1 28
3
1 60
1 78
2
2
*/
        //static void Main(String[] args)
        //{
        //    int operations = Convert.ToInt32(Console.ReadLine());

        //    Q q = new Q();

        //    for (int i = 0; i < operations; i++)
        //    {
        //        var operation = Console.ReadLine().Trim().Split(' ').Select(x => Convert.ToInt32(x)).ToList();

        //        switch (operation[0])
        //        {
        //            case 1:
        //                q.Enqueue(operation[1]);
        //                break;
        //            case 2:
        //                q.Dequeue();
        //                break;
        //            case 3:
        //                Console.WriteLine(q.Print());
        //                break;
        //        }
        //    }

        //    Console.ReadLine();
        //}

        class Q
        {
            Stack<int> front = new Stack<int>();
            Stack<int> back = new Stack<int>();

            public void Enqueue(int i)
            {
                while (front.Count > 0)
                {
                    back.Push(front.Pop());
                }

                back.Push(i);
            }

            public int Dequeue()
            {
                while (back.Count > 0)
                {
                    front.Push(back.Pop());
                }

                return front.Pop();
            }

            public int Print()
            {
                while (back.Count > 0)
                {
                    front.Push(back.Pop());
                }

                return front.Peek();
            }
        }
    }
}