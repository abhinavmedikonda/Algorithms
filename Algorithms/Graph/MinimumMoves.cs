using System;
using System.Collections.Generic;
using System.Linq;


namespace Algorithms.Graph;

public class MinimumMoves
{

	public static int minimumMoves(List<string> grid, int startX, int startY, int goalX, int goalY)
    {
        List<List<bool>> visited = new();
        for(int i=0; i<grid.Count; i++){
            visited.Add(new());
            for(int j=0; j<grid[0].Length; j++){
                visited[i].Add(false);
            }
        }

        int theReturn=0;
        Queue<Tuple<int, int, List<Tuple<int, int>>>> q = new();
        var invLen = grid.Count-1;
        if(grid[invLen-startY][startX] == 'X'){
            return -1;
        }

        q.Enqueue(new(startX, invLen-startY, new()));
        q.Enqueue(null);
        
        while(q.Count > 1){
            var item = q.Dequeue();
            if(item == null){
                q.Enqueue(null);
                theReturn++;
                continue;
            }
            
            if(item.Item1==goalX && item.Item2==invLen-goalY){
                item.Item3.Add(new(item.Item1, item.Item2));
                foreach (var trace in item.Item3)
                {
                    Console.WriteLine($"{trace.Item1} {invLen-trace.Item2}");
                }
                
                return theReturn;
            }

            if(visited[item.Item2][item.Item1])
            {
                continue;
            }
            
            addChildren(grid, item, q);
            visited[item.Item2][item.Item1] = true;
        }
        
        return -1;
    }

	private static void addChildren(List<string> grid, Tuple<int, int, List<Tuple<int, int>>> item, Queue<Tuple<int, int, List<Tuple<int, int>>>> q){
        var x = item.Item1;
        var y = item.Item2;
        List<Tuple<int, int>> trace = new(item.Item3);
        trace.Add(new(x, y));

        for(int i=x+1; i<grid[0].Length; i++){
            if(i==grid[0].Length || grid[y][i]=='X'){
                break;
            }

            q.Enqueue(new(i, y, trace));
        }
    
        for(int i=x-1; i>=0; i--){
            if(i<0 || grid[y][i]=='X'){
                break;
            }

            q.Enqueue(new(i, y, trace));
        }

        for(int i=y+1; i<grid.Count; i++){
            if(i==grid.Count || grid[i][x]=='X'){
                break;
            }

            q.Enqueue(new(x, i, trace));
        }

        for(int i=y-1; i>=0; i--){
            if(i<0 || grid[i][x]=='X'){
                break;
            }

            q.Enqueue(new(x, i, trace));
        }
    }

	/*
3
.X.
.X.
...
2 2 0 2

10
..X.XX...X
X......X..
.X..XXX..X
...X......
..X.X..XX.
.X...XX...
.....X..XX
.....XXX..
..........
.....X..XX
1 0 6 3

3
...
.X.
.X.
2 0 0 0
*/

    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> grid = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string gridItem = Console.ReadLine();
            grid.Add(gridItem);
        }

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int startX = Convert.ToInt32(firstMultipleInput[0]);

        int startY = Convert.ToInt32(firstMultipleInput[1]);

        int goalX = Convert.ToInt32(firstMultipleInput[2]);

        int goalY = Convert.ToInt32(firstMultipleInput[3]);

        int result = MinimumMoves.minimumMoves(grid, startX, startY, goalX, goalY);

        Console.WriteLine(result);
    }

}
