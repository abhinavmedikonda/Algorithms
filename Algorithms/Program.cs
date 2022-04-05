using System;
using System.Collections.Generic;

namespace Algorithms
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Program program = new Program();

        //    //program.manageInstances(40, new List<int> { 1, 3, 5, 10, 80});
        //    program.CountGroups(new List<string> { "110", "110", "001" });
        //}

        private void manageInstances(int instances, List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < 25 && instances > 1)
                {
                    if (instances % 2 == 0)
                    {
                        instances /= 2;
                    }
                    else
                    {
                        instances /= 2;
                        instances++;
                    }

                    i += 10;
                }
                else if (list[i] > 60 && instances * 2 > 2 * Math.Pow(10, 8))
                {
                    instances *= 2;
                    i += 10;
                }
            }

            Console.Write(instances);
        }

        private void CountGroups(List<string> theStrings)
        {
            List<HashSet<int>> hashSetList = new List<HashSet<int>>();
            for (int i = 0; i < theStrings.Count; i++)
                hashSetList.Add(new HashSet<int> { i });

            for (int i = 0; i < theStrings.Count; i++)
            {
                for (int j = 0; j < theStrings[i].Length; j++)
                {
                    if (i == j)
                        continue;
                    if (theStrings[i][j] == '1')
                    {
                        int iIndex = 0;
                        int jIndex = 0;
                        for (int k = 0; k < hashSetList.Count; k++)
                        {
                            if (hashSetList[k].Contains(i))
                                iIndex = k;
                            if (hashSetList[k].Contains(j))
                                jIndex = k;
                        }

                        if (iIndex != jIndex)
                        {
                            hashSetList[iIndex].UnionWith(hashSetList[jIndex]);
                            hashSetList.RemoveAt(jIndex);
                        }
                    }
                }
            }

            Console.Write(hashSetList.Count);
        }
    }
}
