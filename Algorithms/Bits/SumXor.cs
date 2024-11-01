using System;
using System.Linq;
using System.Text;

namespace Algorithms.Bits
{
    public class SumXor
    {

        /*
         * determine total number of numbers for a number whose normal sum is equal ot XOR sum
         */

        public static long sumXor(long n)
        {
            var result = 0L;
            
            var nBits = getBits(n);
            
            for(long i=0; i<=n; i++){
                if(n+i==xor(nBits, i)){
                    result++;
                }
            }
            
            return result;
        }
        
        private static string getBits(long n){
            var sb = new StringBuilder();
            
            while(n > 0){
                sb.Append(n%2);
                n /= 2;
            }
            
            return sb.ToString();
        }

        private static long xor(string a, long bLong){
            var b = getBits(bLong);
            
            var sb = new StringBuilder();
            for(int i=0; i<b.Length; i++){
                sb.Append(a[i]==b[i] ? 0 : 1);
            }
            
            sb.Append(a.Substring(b.Length));
            
            long result = 0;
            long twoPower = 1;
            
            for(int i=0; i<sb.Length; i++){
                result += twoPower*Convert.ToInt32(char.GetNumericValue(sb[i]));
                twoPower *= 2;
            }
            
            return result;
        }

/*
5
*/

        // public static void Main(string[] args)
        // {
        //    long n = Convert.ToInt64(Console.ReadLine().Trim());

        //    long result = SumXor.sumXor(n);

        //    Console.WriteLine(result);

        //    Console.Read();
        // }

    }
}