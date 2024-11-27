using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Recursion;

public class GroupSimilarSides
{
	/// <summary>
	/// given list of rectangle sides(length, breath)
	/// sides (a, b) and (c, d) are said to make similarRectangle if a/c equals b/d
	/// find total number of possible similarRectangles our of given set of sides
	/// </summary>
	public static long nearlySimilarRectangles(List<List<long>> sides)
    {
        var sets = new List<List<List<long>>>();
        sides.ForEach(x => sets.Add(new List<List<long>>{x}));
		groupSets(sets);
        
        var returns = 0;
        sets.ForEach(x => returns += Enumerable.Range(1, x.Count-1).Sum());
        
        return returns;
    }
    
    private static void groupSets(List<List<List<long>>> sets){
        if(sets.Count < 2){
            return;
        }

        for(int i=sets.Count; i>0; i--){
            for(int j=i-1; j>=0; j--){
                var a = sets[i].First();
                var b = sets[j].First();
                
                if((double)a[0]/(double)b[0] == (double)a[1]/(double)b[1]){
                    sets[j].AddRange(sets[i]);
                    sets.RemoveAt(i);
                    groupSets(sets);

					return;
                }
            }

			sets.RemoveAt(i);
        }
    }

/*
3
2
4 8
15 30
25 50


5
2
2 1
10 7
9 6
6 9
7 3
*/

	// public static void Main(string[] args)
    // {
    //     int sidesRows = Convert.ToInt32(Console.ReadLine().Trim());
    //     int sidesColumns = Convert.ToInt32(Console.ReadLine().Trim());

    //     List<List<long>> sides = new List<List<long>>();

    //     for (int i = 0; i < sidesRows; i++)
    //     {
    //         sides.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sidesTemp => Convert.ToInt64(sidesTemp)).ToList());
    //     }

    //     long result = GroupSimilarSides.nearlySimilarRectangles(sides);

    //     Console.WriteLine(result);
    // }
}
