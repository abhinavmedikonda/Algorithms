using System;


namespace Algorithms.Strings
{
    public class PalindromeIndex
    {

        /*
         * find the index removing which string will be a palindrome.
         */

        public static int palindromeIndex(string s)
        {
            int left = 0, right = s.Length - 1;

            while (left < right)
            {
                if (s[left] != s[right])
                {
                    if (isPalindrome(s.Remove(left, 1)))
                    {
                        return left;
                    }
                    else if (isPalindrome(s.Remove(right, 1)))
                    {
                        return right;
                    }
                    else
                    {
                        return -1;
                    }
                }

                left++;
                right--;
            }

            return -1;
        }

        private static bool isPalindrome(string s)
        {
            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return false;
                }

                left++;
                right--;
            }

            return true;
        }

        //public static void Main(string[] args)
        //{
        //    int q = Convert.ToInt32(Console.ReadLine().Trim());

        //    for (int qItr = 0; qItr < q; qItr++)
        //    {
        //        string s = Console.ReadLine();

        //        int result = PalindromeIndex.palindromeIndex(s);

        //        Console.WriteLine(result);
        //    }

        //    Console.Read();
        //}

    }
}