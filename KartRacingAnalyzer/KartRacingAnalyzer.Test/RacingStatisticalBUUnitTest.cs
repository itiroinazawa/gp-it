using KartRacingAnalyzer.Business;
using KartRacingAnalyzer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace KartRacingAnalyzer.Test
{
    public class RacingStatisticalBUUnitTest
    {
        readonly IRacingStatisticalBU _stats;

        public RacingStatisticalBUUnitTest()
        {
            _stats = new RacingStatisticalBU();
        }

        [Fact]
        public void BestRacingLap_ShouldBe1Minute()
        {
            //Arrange
            var list = GetMockFullRacingData();

            //Act
            var result =_stats.GetBestLapRacing(list);

            //Assert
            Assert.Equal(TimeSpan.FromMinutes(1), result);            
        }

        [Fact]
        public void BestLapRacer002_ShouldBe2Minutes()
        {
            //Arrange
            var list = GetMockFullRacingData().Where(x => x.RacerData.Code == "002").ToList();

            //Act
            var result = _stats.GetBestLapByRacer(list);

            //Assert
            Assert.Equal(TimeSpan.FromMinutes(2), result);
        }

        [Fact]
        public void Racer001AverageSpeed_ShouldBe11()
        {
            //Arrange
            var list = GetMockFullRacingData().Where(x => x.RacerData.Code == "001").ToList();

            //Act
            var result = _stats.GetRacerAverageSpeed(list);

            //Assert
            Assert.Equal(11, result);
        }

        [Fact]
        public void TimeAfterWinner_ShouldBe1Minute()
        {
            //Arrange
            var winnerLastLapTime = GetMockFullRacingData().Where(x => x.RacerData.Code == "001").ToList().Last().LapData.Time;
            var otherLastLapTime = GetMockFullRacingData().Where(x => x.RacerData.Code == "002").ToList().Last().LapData.Time;

            //Act
            var result = _stats.GetFinishingTimeAfterWinner(winnerLastLapTime, otherLastLapTime);

            //Assert
            Assert.Equal(TimeSpan.FromMinutes(1), result);
        }

        private List<RacingData> GetMockFullRacingData()
        {
            List<RacingData> list = new List<RacingData>();

            list.Add(new RacingData()
            {
                Hour = new DateTime(2019, 3, 17, 10, 0, 0),
                LapData = new Lap() { AverageSpeed = 10, Number = 1, Time = TimeSpan.FromMinutes(1) },
                RacerData = new Racer() { Code = "001", Name = "Teste 1" }
            });

            list.Add(new RacingData()
            {
                Hour = new DateTime(2019, 3, 17, 10, 1, 0),
                LapData = new Lap() { AverageSpeed = 12, Number = 2, Time = TimeSpan.FromMinutes(2) },
                RacerData = new Racer() { Code = "001", Name = "Teste 1" }
            });

            list.Add(new RacingData()
            {
                Hour = new DateTime(2019, 3, 17, 10, 2, 0),
                LapData = new Lap() { AverageSpeed = 10, Number = 3, Time = TimeSpan.FromMinutes(3) },
                RacerData = new Racer() { Code = "001", Name = "Teste 1" }
            });

            list.Add(new RacingData()
            {
                Hour = new DateTime(2019, 3, 17, 10, 3, 0),
                LapData = new Lap() { AverageSpeed = 12, Number = 4, Time = TimeSpan.FromMinutes(4) },
                RacerData = new Racer() { Code = "001", Name = "Teste 1" }
            });



            list.Add(new RacingData()
            {
                Hour = new DateTime(2019, 3, 17, 10, 0, 0),
                LapData = new Lap() { AverageSpeed = 10, Number = 1, Time = TimeSpan.FromMinutes(2) },
                RacerData = new Racer() { Code = "002", Name = "Teste 2" }
            });

            list.Add(new RacingData()
            {
                Hour = new DateTime(2019, 3, 17, 10, 1, 10),
                LapData = new Lap() { AverageSpeed = 10, Number = 2, Time = TimeSpan.FromMinutes(3) },
                RacerData = new Racer() { Code = "002", Name = "Teste 2" }
            });

            list.Add(new RacingData()
            {
                Hour = new DateTime(2019, 3, 17, 10, 2, 20),
                LapData = new Lap() { AverageSpeed = 9, Number = 3, Time = TimeSpan.FromMinutes(4) },
                RacerData = new Racer() { Code = "002", Name = "Teste 2" }
            });

            list.Add(new RacingData()
            {
                Hour = new DateTime(2019, 3, 17, 10, 3, 10),
                LapData = new Lap() { AverageSpeed = 8, Number = 4, Time = TimeSpan.FromMinutes(5) },
                RacerData = new Racer() { Code = "002", Name = "Teste 2" }
            });

            return list;
        }
    }
}
