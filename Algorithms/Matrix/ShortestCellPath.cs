using System;
using System.Collections.Generic;

namespace Algorithms.Matrix
{
    public class ShortestCellPath
    {
        /// <summary>
        /// given indexes of start and end of binary grid
        /// find the sortest path distance hopping through 1s
        /// </summary>
        public static int shortestCellPath(List<string> grid, int sr, int sc, int er, int ec)
        {
            var visited = new HashSet<string>();

            //var t = (x: 1, y: 1);
            var q = new Queue<(int x, int y)?>(new List<(int, int)?> { (sr, sc), null });
            //var q = new Queue<Tuple<int, int>>(new List<Tuple<int, int>> { Tuple.Create<int, int>(sr, sc), null });

            int length = 0;
            int cr = 0, cc = sc;

            while (q.Count > 1)
            {
                var t = q.Dequeue();

                if (t == null)
                {
                    q.Enqueue(null);
                    length++;
                    continue;
                }

                cr = t?.x ?? 0;
                cc = t?.y ?? 0;

                if (cr == er && cc == ec) return length;

                if (visited.Contains($"{cr},{cc}")) continue;
                else visited.Add($"{cr},{cc}");

                if (grid[cr][cc] == '1')
                {
                    if (cr+1 < grid.Count && !visited.Contains($"{cr+1},{cc}")) q.Enqueue((cr+1, cc));
                    if (cr-1 >= 0 && !visited.Contains($"{cr-1},{cc}")) q.Enqueue((cr-1, cc));
                    if (cc+1 < grid[0].Length && !visited.Contains($"{cr},{cc+1}")) q.Enqueue((cr, cc+1));
                    if (cc-1 >= 0 && !visited.Contains($"{cr},{cc-1}")) q.Enqueue((cr, cc-1));
                }

            }

            return -1;
        }

/*
0 0 3 7
4
1111010110
0101011101
1111110100
0000100100
*/

        //public static void Main(string[] args)
        //{
        //    string[] coordinates = Console.ReadLine().TrimEnd().Split(' ');

        //    int sr = Convert.ToInt32(coordinates[0]);
        //    int sc = Convert.ToInt32(coordinates[1]);
        //    int er = Convert.ToInt32(coordinates[2]);
        //    int ec = Convert.ToInt32(coordinates[3]);

        //    List<string> grid = new List<string>();

        //    int rows = Convert.ToInt32(Console.ReadLine().Trim());
        //    for (int i = 0; i < rows; i++)
        //    {
        //        string gridItem = Console.ReadLine();
        //        grid.Add(gridItem);
        //    }

        //    Console.WriteLine();

        //    var result = ShortestCellPath.shortestCellPath(grid, sr, sc, er, ec);

        //    Console.WriteLine(result);

        //    Console.Read();
        //}

    }
}
