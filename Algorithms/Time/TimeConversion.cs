using System;
using System.IO;

namespace Algorithms.Time
{
    public class TimeConversion
    {

        /*
         * Given a time in 12-hour AM/PM format, convert it to military (24-hour) time.
         * Note: - 12:00:00AM on a 12-hour clock is 00:00:00 on a 24-hour clock.
         * - 12:00:00PM on a 12-hour clock is 12:00:00 on a 24-hour clock. 
         */

        public static string timeConversion(string s)
        {
            if (s.Substring(8) == "AM" && s.Substring(0, 2) == "12")
            {
                return $"00{s.Substring(2, 6)}";
            }
            if (s.Substring(8) == "AM")
            {
                return s.Substring(0, 8);
            }
            if (s.Substring(8) == "PM" && s.Substring(0, 2) == "12")
            {
                return $"12{s.Substring(2, 6)}";
            }

            return $"{12 + Convert.ToInt32(s.Substring(0, 2))}{s.Substring(2, 6)}";
        }

        //public static void Main(string[] args)
        //{
        //    string s = Console.ReadLine();

        //    string result = TimeConversion.timeConversion(s);

        //    Console.WriteLine(result);
        //    Console.Read();
        //}

    }
}
