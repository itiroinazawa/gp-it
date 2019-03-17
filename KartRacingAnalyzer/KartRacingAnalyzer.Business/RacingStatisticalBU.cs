using KartRacingAnalyzer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KartRacingAnalyzer.Business
{
    public class RacingStatisticalBU : IRacingStatisticalBU
    {
        public TimeSpan GetBestLapRacing(List<RacingData> fullRaceData)
        {
            return fullRaceData.Min(x => x.LapData.Time);
        }

        public TimeSpan GetBestLapByRacer(List<RacingData> racerData)
        {
            return racerData.Min(x => x.LapData.Time);
        }

        public Double GetRacerAverageSpeed(List<RacingData> racerData)
        {
            return racerData.Average(x => x.LapData.AverageSpeed);
        }

        public TimeSpan GetFinishingTimeAfterWinner(TimeSpan winnerTime, TimeSpan racerTime)
        {
            return racerTime - winnerTime;
        }
    }
}
