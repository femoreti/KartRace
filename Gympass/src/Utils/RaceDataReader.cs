using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Models;

namespace Utils
{
    public static class RaceDataReader
    {
        public static List<string> OnReadRaceLog(string path)
        {
            try{
                List<string> lines = File.ReadAllLines(path).OfType<string>().ToList();
                lines.RemoveAt(0);
                return lines;
            }catch(Exception e)
            {
                Console.WriteLine(string.Format("File Not Found: {0}", e.Message));
                return new List<string>();
            }
        }

        public static string[] ClearLine(string line)
        {
            string newLine = line.Replace('\t', ' ');
            newLine = newLine.Replace('–', ' ');
            string[] s = newLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return s;
        }

        public static Pilot GetPilot(string[] clearedLine)
        {
            int id = int.Parse(clearedLine[1]);
            string name = clearedLine[2];

            Pilot newPilot = new Pilot(id, name);

            return newPilot;
        }

        public static Lap GetLap(string[] clearedLine)
        {
            int currentLap = int.Parse(clearedLine[3]);
            string name = clearedLine[2];
            string timeTotal = string.Format("00:{0}", clearedLine[4]);
            float averageSpeed = float.Parse(clearedLine[5]);

            return new Lap(currentLap, clearedLine[0], timeTotal, averageSpeed);
        }
    }
}