using System;
using System.Collections.Generic;

namespace Models
{
    public class Pilot
    {
        private int id;
        private string name;
        private List<Lap> laps;

        public Pilot(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int GetId{
            get{
                return id;
            }
        }

        public string GetName{
            get{
                return name;
            }
        }

        public void SetNewLap(Lap newLap)
        {
            if(laps == null)
                laps = new List<Lap>();

            laps.Add(newLap);
        }

        public int GetTotalLaps{
            get
            {
                return laps.Count;
            }
        }

        public TimeSpan GetTotalTime
        {
            get{
                TimeSpan sumTotalTime = TimeSpan.Zero;

                foreach(Lap l in laps)
                {
                    if(sumTotalTime == TimeSpan.Zero)
                    {
                        sumTotalTime = l.LapTotalTime;
                        continue;
                    }

                    sumTotalTime += l.LapTotalTime;
                }
                return sumTotalTime;
            }
        }
    }
}