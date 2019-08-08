using System;
using System.Collections.Generic;
using System.Linq;

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

        //Id do piloto
        public int GetId {
            get{
                return id;
            }
        }

        //Nome do piloto
        public string GetName {
            get{
                return name;
            }
        }

        //Adiciona uma volta nova
        public void SetNewLap(Lap newLap) {
            if(laps == null)
                laps = new List<Lap>();

            laps.Add(newLap);
        }

        //Retorna a quantidade de voltas
        public int GetTotalLaps{
            get
            {
                return laps.Count;
            }
        }

        //Realiza a soma dos tempos de todas as voltas
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

        //Retorna a melhor volta
        public int GetBestLap{
            get{
                return laps.OrderBy(l => l.LapTotalTime).First().LapID;
            }
        }

        //Retorna o tempo da melhor volta
        public TimeSpan GetBestLapTime{
            get{
                return laps.OrderBy(l => l.LapTotalTime).First().LapTotalTime;
            }
        }

        //Retorna a velocidade media da corrida
        public float GetAverageVelocity
        {
            get{
                return laps.Sum(s => s.LapAverageVelocity) / laps.Count;
            }
        }

        //referencia das voltas
        public List<Lap> GetLaps
        {
            get{
                return laps;
            }
        }
    }
}