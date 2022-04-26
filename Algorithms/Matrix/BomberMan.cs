using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Matrix
{
    public class BomberMan
    {

        /*
         * 1. Initially, Bomberman arbitrarily plants bombs in some of the cells, the initial state.
         * 2. After one more second, Bomberman plants bombs in all cells without bombs, thus filling the whole grid with bombs. No bombs detonate at this point.
         * 3. After one more second, then Bomerman detonates all bombs.
         * 4. Bomberman then repeats steps 2 and 3 indefinitely.
         * return the state of grid after n seconds
         */

        public static List<string> bomberMan(int n, List<string> grid)
        {
            if (n % 2 == 0)
            {
                return new List<string>(Enumerable.Repeat<string>(new string('O', grid[0].Length), grid.Count));
            }

            var gridBuilder = new List<StringBuilder>();
            grid.ForEach(x => gridBuilder.Add(new StringBuilder(x)));

            for (int i = 0; i <= (n-2)%4; i++)
            {
                if (i % 2 != 0)
                {
                    detonate(gridBuilder);
                    Console.WriteLine(String.Join("\n", gridBuilder) + "\n");
                }
            }

            grid.Clear();
            gridBuilder.ForEach(x => grid.Add(x.ToString()));

            return grid;
        }

        private static void detonate(List<StringBuilder> grid)
        {
            for (int i = 0; i < grid.Count; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 'O')
                    {
                        grid[i][j] = '.';
                        if (i - 1 >= 0)
                        {
                            grid[i - 1] = grid[i - 1].Remove(j, 1).Insert(j, ".");
                        }
                        if (i + 1 < grid.Count && grid[i + 1][j] == '.')
                        {
                            grid[i + 1] = grid[i + 1].Remove(j, 1).Insert(j, "*");
                        }
                        if (j - 1 >= 0)
                        {
                            grid[i] = grid[i].Remove(j - 1, 1).Insert(j - 1, ".");
                        }
                        if (j + 1 < grid[0].Length && grid[i][j + 1] == '.')
                        {
                            grid[i] = grid[i].Remove(j + 1, 1).Insert(j + 1, "*");
                        }
                    }
                    else if (grid[i][j] == '.')
                    {
                        grid[i] = grid[i].Remove(j, 1).Insert(j, "O");
                    }
                    else
                    {
                        grid[i] = grid[i].Remove(j, 1).Insert(j, ".");
                    }
                }
            }
        }

//6 7 5
//.......
//...O.O.
//....O..
//..O....
//OO...OO
//OO.O...

        //public static void Main(string[] args)
        //{
        //    string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        //    int r = Convert.ToInt32(firstMultipleInput[0]);
        //    int c = Convert.ToInt32(firstMultipleInput[1]);
        //    int n = Convert.ToInt32(firstMultipleInput[2]);

        //    List<string> grid = new List<string>();

        //    for (int i = 0; i < r; i++)
        //    {
        //        string gridItem = Console.ReadLine();
        //        grid.Add(gridItem);
        //    }

        //    Console.WriteLine();

        //    List<string> result = BomberMan.bomberMan(n, grid);

        //    Console.WriteLine(String.Join("\n", result));

        //    Console.Read();
        //}

    }
}