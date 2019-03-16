using System;

namespace KartRacingAnalyzer.Model
{
    public class CorridaData
    {
        public DateTime Hora { get; set; }

        public Piloto PilotoData { get; set; }

        public Volta VoltaData { get; set; }

        public CorridaData()
        {
            PilotoData = new Piloto();
            VoltaData = new Volta();
        }
    }
}
