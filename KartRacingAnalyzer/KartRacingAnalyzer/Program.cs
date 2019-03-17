using KartRacingAnalyzer.Business;
using System;
using System.Linq;

namespace KartRacingAnalyzer
{
    class Program
    {
        const string RESULTADO = "Posição Chegada: {0} - Código Piloto: {1} - Nome Piloto: {2} - Qtde Voltas Completadas: {3} - Tempo Total de Prova: {4}";

        public Program()
        {

        }

        static void Main(string[] args)
        {
            var file = @"C:\Users\itiro\Desktop\Job-Tests\Gympass\github\gp-it\Files\kart-racing.log";

            IKartBU kart = new KartBU();
            IRacingStatisticalBU statistics = new RacingStatisticalBU();

            var tupleResult = kart.ExecuteRace(file);

            foreach (var item in tupleResult.Item1)
            {
                Console.WriteLine(string.Format(RESULTADO, item.FinishingPosition, item.RacerData.Code, item.RacerData.Name, item.CompletedLaps, item.TotalRacingTime));
            }

            Console.WriteLine("");

            TimeSpan bestLap;

            foreach (var item in tupleResult.Item2)
            {
                bestLap = statistics.GetBestLapByRacer(item.Value);
                Console.WriteLine(string.Format("Piloto: {0} - Melhor volta: {1}", item.Value[0].RacerData.Name, bestLap));
            }

            Console.WriteLine("");

            var fullRaceData = tupleResult.Item2.SelectMany(x => x.Value).ToList();
            var bestRacingLap = statistics.GetBestLapRacing(fullRaceData);

            Console.WriteLine(string.Format("A melhor volta da corrida foi de: {0}", bestRacingLap));

            Console.WriteLine("");

            foreach (var item in tupleResult.Item2)
            {
                var averageSpeed = statistics.GetRacerAverageSpeed(item.Value);
                Console.WriteLine(string.Format("Piloto: {0} - Velocidade Media: {1}", item.Value[0].RacerData.Name, averageSpeed));
            }

            Console.WriteLine("");

            var winnerCode = tupleResult.Item1[0].RacerData.Code;
            var winnerLastLap = tupleResult.Item2[winnerCode].Last().LapData.Time;            

            for (int i = 1; i < tupleResult.Item1.Count; i++)
            {
                var racerLastLap = tupleResult.Item2[tupleResult.Item1[i].RacerData.Code].Last().LapData.Time;
                var racerName = tupleResult.Item2[tupleResult.Item1[i].RacerData.Code].Last().RacerData.Name;
                var timeAfterWinner = statistics.GetFinishingTimeAfterWinner(winnerLastLap, racerLastLap);

                Console.WriteLine(string.Format("Piloto: {0} - Tempo após o vencedor: {1}", racerName, timeAfterWinner));
            }

        }
    }
}
