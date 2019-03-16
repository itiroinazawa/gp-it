using System;

namespace KartRacingAnalyzer.Model
{
    public class CorridaResult
    {
        public int PosicaoChegada { get; set; }

        public Piloto Piloto { get; set; }

        public int QuantidadeVoltasCompletadas { get; set; }

        public TimeSpan TempoTotalProva { get; set; }

        public CorridaResult()
        {
            Piloto = new Piloto();
        }
    }
}
