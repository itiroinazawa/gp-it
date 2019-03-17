using System;

namespace KartRacingAnalyzer.Model
{
    public class Lap
    {
        public int Number { get; set; }
        public TimeSpan Time { get; set; }
        public Double AverageSpeed { get; set; }
    }
}
