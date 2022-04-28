using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Maths
{
    public class DivisibleByPrime
    {

        /*
         * return given list of numbers in thir prime number divisible sequence
         */

        public static List<int> divisibleByPrimeSequence(List<int> numbers, int q)
        {
            int ind = 0;
            var result = new List<int>();
            var primeNumbers = new Queue<int>(getPrimeNumbers(q));

            while (ind < q)
            {
                var primeNumber = primeNumbers.Dequeue();
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] % primeNumber == 0)
                    {
                        result.Add(numbers[i]);
                        numbers.RemoveAt(i);
                        i--;
                    }
                }
                ind++;
            }

            result.AddRange(numbers);
            return result;
        }

        private static List<int> getPrimeNumbers(int count)
        {
            var result = new List<int>();
            int number = 2;

            for (int i = 0; i < count; i++)
            {
                while (result.Count <= i)
                {
                    if (isPrimeNumber(number)) result.Add(number);

                    number++;
                }
            }

            return result;
        }

        private static bool isPrimeNumber(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;

            for (int i = 2; i <= (int)Math.Round(Math.Sqrt(number)); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

/*
6 3
3 7 4 6 5 2
*/

        //public static void Main(string[] args)
        //{
        //    string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        //    int n = Convert.ToInt32(firstMultipleInput[0]);

        //    int q = Convert.ToInt32(firstMultipleInput[1]);

        //    List<int> number = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(numberTemp => Convert.ToInt32(numberTemp)).ToList();

        //    List<int> result = DivisibleByPrime.divisibleByPrimeSequence(number, q);

        //    Console.WriteLine(String.Join("\n", result));

        //    Console.Read();
        //}
    }
}