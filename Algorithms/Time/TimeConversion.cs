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
            int hour = Convert.ToInt32(s.Substring(0, 2));
        
            if(s.Substring(8, 2).ToUpper().Equals("AM"))
                hour = hour == 12 ? hour-12 : hour;
            else
                hour = hour == 12 ? hour : hour+12;

            return $"{hour.ToString("00")}:{s.Substring(3, 5)}";
        }

/*
07:05:45PM
*/

        // public static void Main(string[] args)
        // {
        //    string s = Console.ReadLine();

        //    string result = TimeConversion.timeConversion(s);

        //    Console.WriteLine(result);
        //    Console.Read();
        // }

    }
}
