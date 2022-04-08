using System;
using System.Text;

namespace Algorithms.Char
{
    public class CaesarCipher
    {

        /*
         * Caesar's cipher shifts each letter by a number of letters.
         * If the shift takes you past the end of the alphabet,
         * just rotate back to the front of the alphabet
         */

        public static string caesarCipher(string s, int k)
        {
            StringBuilder sb = new StringBuilder();
            int shift = k % 26;

            foreach (var c in s)
            {
                if (c >= 'a' && c <= 'z')
                {
                    sb.Append((char)(c + shift > 'z' ? c + shift - 26 : c+ shift));
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    sb.Append((char)(c + shift > 'Z' ? c + shift - 26 : c + shift));
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        //public static void Main(string[] args)
        //{
        //    int n = Convert.ToInt32(Console.ReadLine().Trim());

        //    string s = Console.ReadLine();

        //    int k = Convert.ToInt32(Console.ReadLine().Trim());

        //    string result = CaesarCipher.caesarCipher(s, k);

        //    Console.WriteLine(result);
        //    Console.Read();
        //}

    }
}