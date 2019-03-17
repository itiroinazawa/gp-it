using System;

namespace KartRacingAnalyzer.Model
{
    public class RacingData
    {
        public DateTime Hour { get; set; }

        public Racer RacerData { get; set; }

        public Lap LapData { get; set; }

        public RacingData()
        {
            RacerData = new Racer();
            LapData = new Lap();
        }
    }
}
