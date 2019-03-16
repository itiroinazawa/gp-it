using KartRacingAnalyzer.Model;
using System;
using System.Linq;

namespace KartRacingAnalyzer.Util
{
    public class CorridaDataParser
    {
        public CorridaData Parse(string line)
        {
            CorridaData item = null;

            var arr = line.Split(' ').Where(x => !string.IsNullOrEmpty(x) && x != "–").ToArray();

            if (arr.Length >= 6)
            {
                var hora = Convert.ToDateTime(arr[0]);
                var codigoPiloto = arr[1];
                var nomePiloto = arr[2];
                var volta = Convert.ToInt32(arr[3]);
                var tempoVolta = TimeSpanUtil.Parse(arr[4]);
                var velocidadeMedia = Convert.ToDouble(arr[5]);

                item = new CorridaData
                {
                    Hora = hora
                };

                item.PilotoData.Codigo = codigoPiloto;
                item.PilotoData.Nome = nomePiloto;
                item.VoltaData.Numero = volta;
                item.VoltaData.Tempo = tempoVolta;
                item.VoltaData.VelocidadeMedia = velocidadeMedia;
            }

            return item;
        }
    }
}
