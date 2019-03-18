using KartRacingAnalyzer.Model;
using System;
using System.Collections.Generic;

namespace KartRacingAnalyzer.Business
{
    public interface IKartBU
    {
        /// <summary>
        /// Execute race and retrieves all data information for each racer and the racing result ordered 
        /// </summary>
        /// <param name="fullFilePath">kart racing log</param>
        /// <returns>Racing results and information by racer</returns>
        Tuple<List<RacingResult>, Dictionary<string, List<RacingData>>> ExecuteRace(string fullFilePath);
    }
}
