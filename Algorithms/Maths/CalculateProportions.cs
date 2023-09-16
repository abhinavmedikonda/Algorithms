using System;
using System.Linq;

namespace Algorithms.Maths
{
    public static class CalculateProportions
    {
        /*
         * calculate portortions of positive, 0s, negative numbers in the list with 5 decimal values
         */

        private static void calculateProportions()
        {
            int[] array = new int[] { 3, 5, 1, 1, 3, 4, 9, 2, 8, 4, -1 };

            print(Convert.ToSingle(array.Count()), array.Where(x => x > 0).Count());
            print(Convert.ToSingle(array.Count()), array.Where(x => x == 0).Count());
            print(Convert.ToSingle(array.Count()), array.Where(x => x < 0).Count());
        }

        private static void print(float total, int count)
        {
            float x = count / total;
            var intPart = Math.Truncate(x);
            var decPart = Math.Truncate((x - intPart) * 100000).ToString();
            Console.WriteLine($"{intPart}.{new string('0', 5 - decPart.Length)}{decPart}");
        }



        //static void Main(string[] args)
        //{
        //    CalculateProportions.calculateProportions();

        //    Console.Read();
        //}
    }
}
