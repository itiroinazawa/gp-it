using KartRacingAnalyzer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace KartRacingAnalyzer.Util
{
    public class CorridaResultParser
    {
        public CorridaResult Parse(CorridaData item, int posicao, TimeSpan tempoTotal)
        {
            CorridaResult model = new CorridaResult
            {
                PosicaoChegada = posicao,
                QuantidadeVoltasCompletadas = item.VoltaData.Numero,
                TempoTotalProva = tempoTotal
            };

            model.Piloto.Codigo = item.PilotoData.Codigo;
            model.Piloto.Nome = item.PilotoData.Nome;

            return model;
        }
    }
}
