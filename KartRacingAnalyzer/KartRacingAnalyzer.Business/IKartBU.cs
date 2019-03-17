using KartRacingAnalyzer.Model;
using System;
using System.Collections.Generic;

namespace KartRacingAnalyzer.Business
{
    public interface IKartBU
    {
        Tuple<List<RacingResult>, Dictionary<string, List<RacingData>>> ExecuteRace(string fullFilePath);
    }
}
