using KartRacingAnalyzer.Model;
using KartRacingAnalyzer.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KartRacingAnalyzer.Business
{
    public class KartBU : IKartBU
    {
        private readonly IRacingStatisticalBU racingStatisticalBU;

        /// <summary>
        /// Constructor
        /// </summary>
        public KartBU()
        {
            racingStatisticalBU = new RacingStatisticalBU();
        }

        /// <inheritdoc />
        public Tuple<List<RacingResult>, Dictionary<string, List<RacingData>>> ExecuteRace(string fullFilePath)
        {
            List<RacingResult> finalResultList = new List<RacingResult>();

            Dictionary<string, List<RacingData>> dataByRacer = new Dictionary<string, List<RacingData>>();

            string[] lines = File.ReadAllLines(fullFilePath, Encoding.UTF8).Where(x => !string.IsNullOrEmpty(x.Trim())).ToArray();

            for (int i = 0; i < lines.Length; i++)
            {
                if (i == 0 || string.IsNullOrEmpty(lines[i]))
                    continue;

                CorridaDataParser parser = new CorridaDataParser();
                var item = parser.Parse(lines[i].Replace('\t', ' '));

                UpdateRacerData(ref dataByRacer, item);

                if (item.LapData.Number == 4 || i == lines.Length - 1)
                {
                    VerifyRacerPosition(ref finalResultList, dataByRacer[item.RacerData.Code]);
                }
            }

            return Tuple.Create(finalResultList, dataByRacer);
        }

        /// <summary>
        /// Update the racer information in the collection
        /// </summary>
        /// <param name="dataByRacer">Collection of data by racer</param>
        /// <param name="lapData">Current lap information</param>
        private void UpdateRacerData(ref Dictionary<string, List<RacingData>> dataByRacer, RacingData lapData)
        {
            if (dataByRacer.ContainsKey(lapData.RacerData.Code))
            {
                dataByRacer[lapData.RacerData.Code].Add(lapData);
            }
            else
            {
                dataByRacer[lapData.RacerData.Code] = new List<RacingData>() { lapData };
            }
        }

        /// <summary>
        /// Add racer information in the ranking collection
        /// </summary>
        /// <param name="finalResultList">ranking collection</param>
        /// <param name="dataRacer">racer information</param>
        private void VerifyRacerPosition(ref List<RacingResult> finalResultList, List<RacingData> dataRacer)
        {
            CorridaResultParser parser = new CorridaResultParser();

            var totalTime = new TimeSpan(dataRacer.Sum(x => x.LapData.Time.Ticks));
            var position = finalResultList.Count > 0 ? finalResultList.Last().FinishingPosition + 1 : 1;

            var item = parser.Parse(dataRacer.Last(), position, totalTime);

            finalResultList.Add(item);
        }
    }
}
