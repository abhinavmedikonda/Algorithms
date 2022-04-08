using System;

namespace Algorithms.Strings
{
    public class FixPalindrome
    {

        /*
         * determine the index of a character that can be removed to make the string a palindrome
         */

        public static int palindromeIndex(string s)
        {
            int start = 0, end = s.Length-1;
            bool noMatch = false;
            int? index = null;

            while (start < end)
            {
                if (noMatch)
                {
                    if (s[start] == s[end + 1])
                    {
                        end++;
                        index = start-1;
                    }
                    else if (s[start - 1] == s[end])
                    {
                        start--;
                        index = end + 1;
                    }
                    else {
                        return -1;
                    }
                }
                if (s[start] != s[end])
                {
                    if (index != null || noMatch)
                    {
                        return -1;
                    }

                    noMatch = true;
                }

                start++;
                end--;
            }

            if (index == null && noMatch)
            {
                if(s.Length % 2 == 1)
                {
                    if (s[start] == s[end + 1])
                    {
                        return start - 1;
                    }
                    else if (s[start - 1] == s[end])
                    {
                        return end + 1;
                    }
                }
                return start;
            }
            return index ?? -1;
        }

        //public static void Main(string[] args)
        //{
        //    int q = Convert.ToInt32(Console.ReadLine().Trim());

        //    for (int qItr = 0; qItr < q; qItr++)
        //    {
        //        string s = Console.ReadLine();

        //        int result = FixPalindrome.palindromeIndex(s);

        //        Console.WriteLine(result);
        //    }

        //    Console.Read();
        //}

    }
}