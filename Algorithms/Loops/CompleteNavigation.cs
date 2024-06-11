using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Loops
{
    public class CompleteNavigation
    {

        /*
         * Suppose there is a circle and there are list of petrol petrol pumps.
         * given each pump fuel and distance to next pump, find the first point
         * from where circle can be completed
         */

        public static int completeNavigation(List<List<int>> petrolpumps)
        {
            for (int i = 0; i < petrolpumps.Count; i++)
            {
                int sum = 0;
                for (int j = 0; j < petrolpumps.Count; j++)
                {
                    var index = i + j < petrolpumps.Count ? i + j : i + j - petrolpumps.Count;
                    sum += petrolpumps[index][0] - petrolpumps[index][1];
                    if (sum < 0)
                    {
                        goto loop1; //go to specific code
                    }
                }

                return i;

            loop1:; //go to specific code
            }

            return 0;
        }

/*
3
1 5
10 3
3 4
*/

        //public static void Main(string[] args)
        //{
        //    int n = Convert.ToInt32(Console.ReadLine().Trim());

        //    List<List<int>> petrolpumps = new List<List<int>>();

        //    for (int i = 0; i < n; i++)
        //    {
        //        petrolpumps.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(petrolpumpsTemp => Convert.ToInt32(petrolpumpsTemp)).ToList());
        //    }

        //    int result = CompleteNavigation.completeNavigation(petrolpumps);

        //    Console.WriteLine(result);

        //    Console.Read();
        //}

    }
}