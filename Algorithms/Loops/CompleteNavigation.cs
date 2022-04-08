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
                int pumpsCovered = 0;
                int fuel = 0;
                while (pumpsCovered < petrolpumps.Count)
                {
                    int pumpIndex = i + pumpsCovered >= petrolpumps.Count ? i + pumpsCovered - petrolpumps.Count : i + pumpsCovered;
                    pumpsCovered++;
                    fuel += petrolpumps[pumpIndex][0] - petrolpumps[pumpIndex][1];
                    if (fuel < 0)
                    {
                        goto loop1;
                    }
                }

                return i;

            loop1:;
            }

            return 0;
        }

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