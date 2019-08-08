using System;

namespace Models
{
    public class Lap
    {
        private int lapID;
        private TimeSpan lapTimeStarted, lapTimeTotal;
        private float lapSpeed;

        public Lap(int id, string timeStarted, string timeTotal, float averageSpeed)
        {
            this.lapID = id;

            TimeSpan.TryParse(timeStarted, out this.lapTimeStarted); //Converte a string Hora em um TimeSpan
            TimeSpan.TryParse(timeTotal, out this.lapTimeTotal); //Converte a string Tempo volta em um TimeSpan

            this.lapSpeed = averageSpeed;
        }

        //ID indicando qual o numero da volta
        public int LapID{
            get{
                return lapID;
            }
        }

        //Tempo que essa volta foi inicializada
        public TimeSpan LapInitialTime{
            get{
                return lapTimeStarted;
            }
        }

        //Tempo da duracao total da volta
        public TimeSpan LapTotalTime{
            get{
                return lapTimeTotal;
            }
        }

        //Velocidade media da volta
        public float LapAverageVelocity{
            get{
                return lapSpeed;
            }
        }
    }
}