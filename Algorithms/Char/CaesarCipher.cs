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
            StringBuilder sb = new StringBuilder(s);
            k %= 26;
            
            for(int i=0; i<sb.Length; i++){
                if(char.IsLetter(sb[i])){
                    var a = char.IsLower(sb[i]) ? 'a'+0 : 'A'+0;
                    var index = sb[i]+k-a < 26 ? sb[i]+k : sb[i]+k-26;
                    sb[i] = Convert.ToChar(index);
                }
            }
            
            return sb.ToString();
        }

        ///
        // using ascii numbers to identify chars
        ///
        //public static string caesarCipher(string s, int k)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    int shift = k % 26;

        //    foreach (var c in s)
        //    {
        //        if (c >= 'a' && c <= 'z')
        //        {
        //            sb.Append((char)(c + shift > 'z' ? c + shift - 26 : c+ shift));
        //        }
        //        else if (c >= 'A' && c <= 'Z')
        //        {
        //            sb.Append((char)(c + shift > 'Z' ? c + shift - 26 : c + shift));
        //        }
        //        else
        //        {
        //            sb.Append(c);
        //        }
        //    }

        //    return sb.ToString();
        //}

/*
11
middle-Outz
2
*/

        public static void Main(string[] args)
        {
           int n = Convert.ToInt32(Console.ReadLine().Trim());

           string s = Console.ReadLine();

           int k = Convert.ToInt32(Console.ReadLine().Trim());

           string result = CaesarCipher.caesarCipher(s, k);

           Console.WriteLine(result);
           Console.Read();
        }

    }
}