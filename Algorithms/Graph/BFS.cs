using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Graph
{
    public class BFS
    {

        /// <summary>
        /// return levels of graph from root with weight of 6 per level
        /// </summary>
        /// <param name="n">no.of nodes</param>
        /// <param name="m">no.of edges</param>
        /// <param name="edges">edges as pairs</param>
        /// <param name="s">root node</param>
        /// <returns>list of weights without the root node</returns>

        public static List<int> bfs(int n, int m, List<List<int>> edges, int s)
        {
            Dictionary<int, List<int>> hashT = new Dictionary<int, List<int>>();

            foreach (var item in edges)
            {
                if (!hashT.ContainsKey(item[0]))
                {
                    hashT[item[0]] = new List<int>();
                }

                hashT[item[0]].Add(item[1]);
            }

            Queue<int> q = new Queue<int>();
            q.Enqueue(s);
            q.Enqueue(0);

            HashSet<int> visited = new HashSet<int>();
            int level = 0;
            List<int> weights = Enumerable.Repeat(-1, n).ToList();

            while (q.Count > 1)
            {
                var current = q.Dequeue();

                if (current == 0)
                {
                    q.Enqueue(0);
                    level += 6;
                    continue;
                }

                var currentList = hashT.ContainsKey(current) ? hashT[current] : new List<int>();

                weights[current - 1] = level;
                visited.Add(current);

                foreach (var i in currentList)
                {
                    if (visited.Contains(i))
                    {
                        continue;
                    }

                    q.Enqueue(i);
                }
            }

            weights.RemoveAt(s - 1);

            return weights;
        }

        //public static void Main(string[] args)
        //{
        //    int q = Convert.ToInt32(Console.ReadLine().Trim());

        //    for (int qItr = 0; qItr < q; qItr++)
        //    {
        //        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        //        int n = Convert.ToInt32(firstMultipleInput[0]);

        //        int m = Convert.ToInt32(firstMultipleInput[1]);

        //        List<List<int>> edges = new List<List<int>>();

        //        for (int i = 0; i < m; i++)
        //        {
        //            edges.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(edgesTemp => Convert.ToInt32(edgesTemp)).ToList());
        //        }

        //        int s = Convert.ToInt32(Console.ReadLine().Trim());

        //        List<int> result = BFS.bfs(n, m, edges, s);

        //        Console.WriteLine(String.Join(" ", result));
        //    }

        //    Console.Read();
        //}

    }
}