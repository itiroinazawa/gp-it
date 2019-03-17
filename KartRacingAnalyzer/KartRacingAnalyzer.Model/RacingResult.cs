using System;

namespace KartRacingAnalyzer.Model
{
    public class RacingResult
    {
        public int FinishingPosition { get; set; }

        public Racer RacerData { get; set; }

        public int CompletedLaps { get; set; }

        public TimeSpan TotalRacingTime { get; set; }

        public RacingResult()
        {
            RacerData = new Racer();
        }
    }
}
