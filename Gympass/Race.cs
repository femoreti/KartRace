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
            Dictionary<int, Pilot> pilots = new Dictionary<int, Pilot>();

            foreach(string line in raceData)
            {
                string[] lineData = RaceDataReader.ClearLine(line);
                Pilot newPilot = RaceDataReader.GetPilot(lineData);

                if(pilots.ContainsKey(newPilot.GetId))
                {
                    pilots[newPilot.GetId].SetNewLap(RaceDataReader.GetLap(lineData));
                }
                else
                {
                    newPilot.SetNewLap(RaceDataReader.GetLap(lineData));
                    pilots.Add(newPilot.GetId, newPilot);
                }
            }
            
            results = pilots.Values.ToList().OrderBy(t => t.GetTotalTime).ToList();

            ShowRaceResult();
        }

        static void ShowRaceResult()
        {
            Console.WriteLine("####################################\n"+
            "###### Teste BackEnd GymPass #######\n"+
            "####################################\n"+
            "###### Felipe Nicolau Moreti #######\n"+
            "#### felipe.moreti7@gmail.com ######\n"+
            "######### (11)98030-4601 ###########\n"+
            "####################################\n"+
            "####################################\n"+
            "########## RACE RESULTS ############\n"+
            "Posição		código		Nome			Voltas		Tempo Total");

            for(int i = 0; i < results.Count; i++)
            {
                Pilot p = results[i];
                Console.WriteLine(string.Format("{0}\t\t{1}\t\t{2}\t\t\t{3}\t\t{4}", 
                i+1, p.GetId, p.GetName, p.GetTotalLaps, p.GetTotalTime));
            }
        }
    }
}
