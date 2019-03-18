using KartRacingAnalyzer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace KartRacingAnalyzer.Util
{
    public class CorridaResultParser
    {
        /// <summary>
        /// Parse data from racing data and other info to a RacingResult object 
        /// </summary>
        /// <param name="item">Racing Data from a Racer</param>
        /// <param name="finishingPosition">Racer finishing position</param>
        /// <param name="totalTime">Racing Total Time</param>
        /// <returns>Racing Result parsed</returns>
        public RacingResult Parse(RacingData item, int finishingPosition, TimeSpan totalTime)
        {
            RacingResult model = new RacingResult
            {
                FinishingPosition = finishingPosition,
                CompletedLaps = item.LapData.Number,
                TotalRacingTime = totalTime
            };

            model.RacerData.Code = item.RacerData.Code;
            model.RacerData.Name = item.RacerData.Name;

            return model;
        }
    }
}
