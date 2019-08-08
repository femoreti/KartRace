using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Utils;

namespace Gympass
{
    class Race
    {
        static List<Pilot> results;

        static void Main(string[] args)
        {
            List<string> raceData = RaceDataReader.OnReadRaceLog(@"data/log.txt");

            if(raceData.Count == 0)
            {
                Console.WriteLine("Não foi possível carregar o log");
                return;
            }
            
            //Ordena os pilotos pelo menor tempo, decidindo assim a posicao no podio
            results = RaceDataReader.GenerateRacePilots(raceData).Values.ToList().OrderBy(t => t.GetTotalTime).ToList();

            ShowRaceResult(); //Exibe os resultados
        }

        static void ShowRaceResult()
        {
            Console.WriteLine("####################################\n"+
            "###### Teste Back-End GymPass #######\n"+
            "####################################\n"+
            "###### Felipe Nicolau Moreti #######\n"+
            "#### felipe.moreti7@gmail.com ######\n"+
            "######### (11)98030-4601 ###########\n"+
            "####################################\n"+
            "####################################\n"+
            "########## RACE RESULTS ############\n\n"+
            "Posição\tcódigo\t\tNome\t\tVoltas\t\tTempo Total\t\t\tBest Lap - Best Lap Time\t\tAverage Velocity\t\ttempo atrás");

            for(int i = 0; i < results.Count; i++)
            {
                Pilot p = results[i];

                Lap winnerLastLap = results[0].GetLaps[results[0].GetLaps.Count-1];
                Lap lastLap = p.GetLaps[p.GetLaps.Count-1];
                TimeSpan timeAfterFirst = (lastLap.LapInitialTime + lastLap.LapTotalTime) - (winnerLastLap.LapInitialTime + winnerLastLap.LapTotalTime);

                Console.WriteLine(string.Format("{0}\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5} - {6}\t\t{7}\t\t+{8}", 
                i+1, p.GetId, p.GetName, p.GetTotalLaps, p.GetTotalTime, p.GetBestLap, p.GetBestLapTime, p.GetAverageVelocity, timeAfterFirst));
            }

            Console.WriteLine("\n#### Best Lap of the race ####\n");
            Pilot faster = results.OrderBy(p => p.GetBestLapTime).First();
            Console.WriteLine(string.Format("{0} - {1}\n", faster.GetName, faster.GetBestLapTime));
        }
    }
}
