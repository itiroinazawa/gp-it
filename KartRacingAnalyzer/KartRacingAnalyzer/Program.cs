using KartRacingAnalyzer.Business;
using System;
using System.Linq;

namespace KartRacingAnalyzer
{
    class Program
    {
        const string RESULTADO = "Posição Chegada: {0} - Código Piloto: {1} - Nome Piloto: {2} - Qtde Voltas Completadas: {3} - Tempo Total de Prova: {4}";
        const string BEST_LAP_RACER = "Piloto: {0} - Melhor volta: {1}";
        const string BEST_RACING_LAP = "A melhor volta da corrida foi de: {0}";
        const string RACER_AVERAGE_SPEED = "Piloto: {0} - Velocidade Media: {1}";
        const string TIME_AFTER_WINNER_RACER = "Piloto: {0} - Tempo após o vencedor: {1}";

        const string LABEL_FINAL_RESULT = "RESULTADOS FINAIS";
        const string LABEL_BEST_LAP_BY_RACER = "MELHOR VOLTA POR CORREDOR";
        const string LABEL_BEST_RACING_LAP = "MELHOR VOLTA DA CORRIDA";
        const string LABEL_AVERAGE_SPEED_BY_RACER = "VELOCIDADE MEDIA POR CORREDOR";
        const string LABEL_TIME_AFTER_WINNER = "TEMPO APÓS O VENCEDOR";
        
        static void Main(string[] args)
        {
            //var file = @"C:\Users\itiro\Desktop\Job-Tests\Gympass\github\gp-it\Files\kart-racing.log";
            var file = args[0];

            IKartBU kart = new KartBU();
            IRacingStatisticalBU statistics = new RacingStatisticalBU();

            var tupleResult = kart.ExecuteRace(file);

            Console.WriteLine(LABEL_FINAL_RESULT);

            foreach (var item in tupleResult.Item1)
            {
                Console.WriteLine(string.Format(RESULTADO, item.FinishingPosition, item.RacerData.Code, item.RacerData.Name, item.CompletedLaps, item.TotalRacingTime));
            }

            Console.WriteLine(string.Empty);
            Console.WriteLine(LABEL_BEST_LAP_BY_RACER);

            TimeSpan bestLap;

            foreach (var item in tupleResult.Item2)
            {
                bestLap = statistics.GetBestLapByRacer(item.Value);
                Console.WriteLine(string.Format(BEST_LAP_RACER, item.Value[0].RacerData.Name, bestLap));
            }

            Console.WriteLine(string.Empty);
            Console.WriteLine(LABEL_BEST_RACING_LAP);

            var fullRaceData = tupleResult.Item2.SelectMany(x => x.Value).ToList();
            var bestRacingLap = statistics.GetBestLapRacing(fullRaceData);

            Console.WriteLine(string.Format(BEST_RACING_LAP, bestRacingLap));

            Console.WriteLine(string.Empty);
            Console.WriteLine(LABEL_AVERAGE_SPEED_BY_RACER);

            foreach (var item in tupleResult.Item2)
            {
                var averageSpeed = statistics.GetRacerAverageSpeed(item.Value);
                Console.WriteLine(string.Format(RACER_AVERAGE_SPEED, item.Value[0].RacerData.Name, averageSpeed));
            }

            Console.WriteLine(string.Empty);
            Console.WriteLine(LABEL_TIME_AFTER_WINNER);

            var winnerCode = tupleResult.Item1[0].RacerData.Code;
            var winnerLastLap = tupleResult.Item2[winnerCode].Last().LapData.Time;            

            for (int i = 1; i < tupleResult.Item1.Count; i++)
            {
                var racerLastLap = tupleResult.Item2[tupleResult.Item1[i].RacerData.Code].Last().LapData.Time;
                var racerName = tupleResult.Item2[tupleResult.Item1[i].RacerData.Code].Last().RacerData.Name;
                var timeAfterWinner = statistics.GetFinishingTimeAfterWinner(winnerLastLap, racerLastLap);

                Console.WriteLine(string.Format(TIME_AFTER_WINNER_RACER, racerName, timeAfterWinner));
            }

        }
    }
}
