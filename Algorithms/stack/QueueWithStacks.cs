using System;
using System.Collections.Generic;
using System.Linq;
namespace Algorithms.stack
{
    public class QueueWithStacks
    {

/*
10
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
        static void Main(String[] args)
        {
            int operations = Convert.ToInt32(Console.ReadLine());

            Q q = new Q();

            for (int i = 0; i < operations; i++)
            {
                var operation = Console.ReadLine().Trim().Split(' ').Select(x => Convert.ToInt32(x)).ToList();

                switch (operation[0])
                {
                    case 1:
                        q.Enqueue(operation[1]);
                        break;
                    case 2:
                        q.Dequeue();
                        break;
                    case 3:
                        Console.WriteLine(q.Print());
                        break;
                }
            }

            Console.ReadLine();
        }

        class Q
        {
            Stack<int> primary = new Stack<int>(), secondary = new Stack<int>();

            public void Enqueue(int number)
            {
                primary.Push(number);
            }

            public void Dequeue()
            {
                migrate();
                secondary.Pop();
            }

            public int Print()
            {
                migrate();
                return secondary.Peek();
            }

            private void migrate()
            {
                if (secondary.Count == 0)
                {
                    while (primary.Count > 0)
                    {
                        secondary.Push(primary.Pop());
                    }
                }
            }
        }
    }
}