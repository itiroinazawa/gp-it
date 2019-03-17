using KartRacingAnalyzer.Model;
using System;
using System.Collections.Generic;

namespace KartRacingAnalyzer.Business
{
    public interface IRacingStatisticalBU
    {
        TimeSpan GetBestLapRacing(List<RacingData> fullRaceData);

        TimeSpan GetBestLapByRacer(List<RacingData> racerData);

        Double GetRacerAverageSpeed(List<RacingData> racerData);

        TimeSpan GetFinishingTimeAfterWinner(TimeSpan winnerTime, TimeSpan racerTime);
    }
}
