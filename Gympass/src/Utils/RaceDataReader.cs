using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Models;

namespace Utils
{
    public static class RaceDataReader
    {
        /**
            Carrega o Log e o separa por linhas
         */
        public static List<string> OnReadRaceLog(string path)
        {
            try{
                List<string> lines = File.ReadAllLines(path).OfType<string>().ToList();
                lines.RemoveAt(0); //Remove a primeira linha de cabecalho

                return lines;
            } catch(Exception e)
            {
                Console.WriteLine(string.Format("File Not Found: {0}", e.Message));

                return new List<string>();
            }
        }

        /**
        * Remove os espaços em brancos e o traco e retorna apenas os valores uteis
         */
        private static string[] ClearLine(string line)
        {
            string newLine = line.Replace('\t', ' ');
            newLine = newLine.Replace('–', ' ');

            return newLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }

        //Utiliza o log carregado e gera os dados da corrida
        public static Dictionary<int,Pilot> GenerateRacePilots(List<string> data)
        {
            Dictionary<int, Pilot> pilots = new Dictionary<int, Pilot>();

            foreach(string line in data)
            {
                string[] lineData = RaceDataReader.ClearLine(line); //Limpa uma linha do log e separa em dados
                Pilot newPilot = RaceDataReader.GetPilot(lineData); //decodifica os dados para gerar um piloto

                if(pilots.ContainsKey(newPilot.GetId)) //Se o dicionario ja contem um piloto adiciona apenas a volta
                {
                    pilots[newPilot.GetId].SetNewLap(RaceDataReader.GetLap(lineData)); //Adiciona uma nova volta
                }
                else //Se o dicionario nao contem um piloto cria um piloto e o adiciona
                {
                    newPilot.SetNewLap(RaceDataReader.GetLap(lineData)); //Adiciona a primeira volta
                    pilots.Add(newPilot.GetId, newPilot);
                }
            }

            return pilots;
        }

        //Converte os valores uteis em um Piloto
        private static Pilot GetPilot(string[] clearedLine)
        {
            int id = int.Parse(clearedLine[1]);
            string name = clearedLine[2];

            return new Pilot(id, name);
        }

        //Converte os valores uteis em uma Volta
        private static Lap GetLap(string[] clearedLine)
        {
            int currentLap = int.Parse(clearedLine[3]);
            string name = clearedLine[2];
            string timeTotal = string.Format("00:{0}", clearedLine[4]);
            float averageSpeed = float.Parse(clearedLine[5]);

            return new Lap(currentLap, clearedLine[0], timeTotal, averageSpeed);
        }
    }
}