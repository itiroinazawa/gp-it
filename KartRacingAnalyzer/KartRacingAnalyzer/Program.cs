using KartRacingAnalyzer.Business;
using System;

namespace KartRacingAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {

            var file = @"C:\Users\itiro\Desktop\Job-Tests\Gympass\github\gp-it\Files\kart-racing.log";

            KartBU business = new KartBU();
            business.ExecutarCorrida(file);
        }
    }
}
