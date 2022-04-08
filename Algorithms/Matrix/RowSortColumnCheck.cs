using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Matrix
{
    public class RowSortColumnCheck
    {

        /*
         * rearrange elements of each row alphabetically, ascending.
         * Determine if the columns are also in ascending alphabetical order, top to bottom.
         * Return YES if they are or NO if they are not.
         */

        public static string rowSortColumnCheck(List<string> grid)
        {
            for (int i = 0; i < grid.Count; i++)
            {
                grid[i] = String.Concat(grid[i].OrderBy(c => c));
            }

            for (int i = 0; i < grid[0].Length; i++)
            {
                char c = 'a';
                for (int j = 0; j < grid.Count; j++)
                {
                    if (grid[j][i] < c)
                    {
                        return "NO";
                    }

                    c = grid[j][i];
                }
            }

            return "YES";
        }

        //public static void Main(string[] args)
        //{
        //    int t = Convert.ToInt32(Console.ReadLine().Trim());

        //    for (int tItr = 0; tItr < t; tItr++)
        //    {
        //        int n = Convert.ToInt32(Console.ReadLine().Trim());

        //        List<string> grid = new List<string>();

        //        for (int i = 0; i < n; i++)
        //        {
        //            string gridItem = Console.ReadLine();
        //            grid.Add(gridItem);
        //        }

        //        string result = RowSortColumnCheck.rowSortColumnCheck(grid);

        //        Console.WriteLine(result);
        //    }

        //    Console.Read();
        //}
    }

}