using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Recursion
{
    public class LegoWall
    {
        public static int legoBlocks(int n, int m)
        {
            List<int> lego = new List<int> { 0 };

            return recursiveLegoBlocks1Row(m, lego);
        }

        private static int recursiveLegoBlocks1Row(int m, List<int> lego)
        {
            int filled = lego[lego.Count - 1];
            int total = 0;

            for (int size = 1; size <= m - filled && size <= 4; size++)
            {

                if (filled + size == m)
                {
                    return total + 1;
                }

                lego.Add(filled + size);
                total += recursiveLegoBlocks1Row(m, lego);
                lego.RemoveAt(lego.Count - 1);
            }

            return total;
        }

        //public static int legoBlocks(int n, int m)
        //{
        //    List<List<int>> lego = new List<List<int>>();
        //    for (int i = 0; i < n; i++)
        //    {
        //        lego.Add(new List<int> { 0 });
        //    }
        //    return recursiveLegoBlocks(n, m, lego);
        //}

//{
//    List<List<int>> lego = new List<List<int>>();
//    l.ForEach(x => lego.Add(new List<int>(x)));

//    int total = 0;

//    for (int i = 0; i < n; i++)
//    {
//        int filled = lego[i][lego[i].Count - 1];
//        bool change = false;
//        for (int size = 1; size <= m - filled && size <= 4; size++)
//        {

//            if (filled + size == m && i == n - 1)
//            {
//                return total + 1;
//            }
//            if (i == n-1 && lego.Take(n-1).All(x => x.Contains(filled+size)))
//            {
//                continue;
//            }

//            change = true;
//            lego[i].Add(filled + size);
//            total += recursiveLegoBlocks(n, m, lego);
//            lego[i].RemoveAt(lego[i].Count-1);
//        }

//        if (change)
//        {
//            return total;
//        }
//    }

//    return total;
//}

/*
6
4 5
4 6
4 7
5 4
6 4
7 4
*/

        //public static void Main(string[] args)
        //{
        //    int t = Convert.ToInt32(Console.ReadLine().Trim());

        //    for (int tItr = 0; tItr < t; tItr++)
        //    {
        //        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        //        int n = Convert.ToInt32(firstMultipleInput[0]);

        //        int m = Convert.ToInt32(firstMultipleInput[1]);

        //        //LegoWall legoWall = new LegoWall();
        //        int result = LegoWall.legoBlocks(n, m);

        //        Console.WriteLine(result);
        //    }

        //    Console.Read();
        //}

    }
}