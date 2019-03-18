using System;
using System.Collections.Generic;
using System.Text;

namespace KartRacingAnalyzer.Util
{
    public static class TimeSpanUtil
    {
        /// <summary>
        /// Parse a string received from log information to a TimeSpan 
        /// </summary>
        /// <param name="timeString">Time string e.g.: (1:02.852)</param>
        /// <returns>Timespan parsed</returns>
        public static TimeSpan Parse(string timeString)
        {
            var arr = timeString.Split(":");

            var minutes = Convert.ToInt32(arr[0]);

            var arr2 = arr[1].Split('.');

            var seconds = Convert.ToInt32(arr2[0]);
            var milliseconds = Convert.ToInt32(arr2[1]);

            return new TimeSpan(0, 0, minutes, seconds, milliseconds);
        }
    }
}
