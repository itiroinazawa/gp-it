using KartRacingAnalyzer.Model;
using System;
using System.Linq;

namespace KartRacingAnalyzer.Util
{
    public class CorridaDataParser
    {
        /// <summary>
        /// Parse information from a string based on the log information to a RacingData object
        /// </summary>
        /// <param name="line">Information from log</param>
        /// <returns>Racing Data parsed</returns>
        public RacingData Parse(string line)
        {
            RacingData item = null;

            var arr = line.Split(' ').Where(x => !string.IsNullOrEmpty(x) && x != "–").ToArray();

            if (arr.Length >= 6)
            {
                var hour = Convert.ToDateTime(arr[0]);
                var racerCode = arr[1];
                var racerName = arr[2];
                var lap = Convert.ToInt32(arr[3]);
                var lapTime = TimeSpanUtil.Parse(arr[4]);
                var averageSpeed = Convert.ToDouble(arr[5].Replace(",", "."));

                item = new RacingData
                {
                    Hour = hour
                };

                item.RacerData.Code = racerCode;
                item.RacerData.Name = racerName;
                item.LapData.Number = lap;
                item.LapData.Time = lapTime;
                item.LapData.AverageSpeed = averageSpeed;
            }

            return item;
        }
    }
}
