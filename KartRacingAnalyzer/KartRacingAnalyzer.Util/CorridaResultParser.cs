using KartRacingAnalyzer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace KartRacingAnalyzer.Util
{
    public class CorridaResultParser
    {
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
