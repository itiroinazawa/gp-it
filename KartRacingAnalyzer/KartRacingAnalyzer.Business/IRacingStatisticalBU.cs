using KartRacingAnalyzer.Model;
using System;
using System.Collections.Generic;

namespace KartRacingAnalyzer.Business
{
    public interface IRacingStatisticalBU
    {
        /// <summary>
        /// Get the best lap of the entire racing
        /// </summary>
        /// <param name="fullRaceData">full race data</param>
        /// <returns>Best race lap time</returns>
        TimeSpan GetBestLapRacing(List<RacingData> fullRaceData);

        /// <summary>
        /// Get the best lap of the racer 
        /// </summary>
        /// <param name="racerData">All the racer data in the racing</param>
        /// <returns>Best race lap time</returns>
        TimeSpan GetBestLapByRacer(List<RacingData> racerData);

        /// <summary>
        /// Get the average speed of the racer 
        /// </summary>
        /// <param name="racerData">All the racer data in the racing</param>
        /// <returns>Racer's average speed</returns>
        Double GetRacerAverageSpeed(List<RacingData> racerData);

        /// <summary>
        /// Get the finishig time after the winner last lap
        /// </summary>
        /// <param name="winnerTime">Winner last lap time</param>
        /// <param name="racerTime">Racer last lap time</param>
        /// <returns>Difference between winner and racer last lap</returns>
        TimeSpan GetFinishingTimeAfterWinner(TimeSpan winnerTime, TimeSpan racerTime);
    }
}
