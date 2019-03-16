using KartRacingAnalyzer.Model;
using KartRacingAnalyzer.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KartRacingAnalyzer.Business
{
    public class KartBU
    {
        public void ExecutarCorrida(string fullFilePath)
        {
            List<CorridaResult> resultado = new List<CorridaResult>();

            Dictionary<string, List<CorridaData>> dataByRacer = new Dictionary<string, List<CorridaData>>();

            string[] lines = File.ReadAllLines(fullFilePath, Encoding.UTF8).Where(x => !string.IsNullOrEmpty(x.Trim())).ToArray();

            for (int i = 0; i < lines.Length; i++)
            {
                if (i == 0 || string.IsNullOrEmpty(lines[i]))
                    continue;

                CorridaDataParser parser = new CorridaDataParser();
                var item = parser.Parse(lines[i].Replace('\t', ' '));

                UpdateRacerData(ref dataByRacer, item);

                if (item.VoltaData.Numero == 4 || i == lines.Length - 1)
                {
                    VerificarPosicao(ref resultado, dataByRacer[item.PilotoData.Codigo]);
                }
            }
        }

        private void UpdateRacerData(ref Dictionary<string, List<CorridaData>> dataByPiloto, CorridaData data)
        {
            if (dataByPiloto.ContainsKey(data.PilotoData.Codigo))
            {
                dataByPiloto[data.PilotoData.Codigo].Add(data);
            }
            else
            {
                dataByPiloto[data.PilotoData.Codigo] = new List<CorridaData>() { data };
            }
        }

        private void VerificarPosicao(ref List<CorridaResult> resultado, List<CorridaData> dataRacer)
        {
            CorridaResultParser parser = new CorridaResultParser();

            var tempoTotal = new TimeSpan(dataRacer.Sum(x => x.VoltaData.Tempo.Ticks));
            var posicao = resultado.Count > 0 ? resultado.Last().PosicaoChegada + 1 : 1;

            var item = parser.Parse(dataRacer.Last(), posicao, tempoTotal);

            resultado.Add(item);
        }
    }
}
