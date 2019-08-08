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

            TimeSpan.TryParse(timeStarted, out this.lapTimeStarted);
            TimeSpan.TryParse(timeTotal, out this.lapTimeTotal);

            this.lapSpeed = averageSpeed;
        }

        public int LapID{
            get{
                return lapID;
            }
        }

        public TimeSpan LapInitialTime{
            get{
                return lapTimeStarted;
            }
        }

        public TimeSpan LapTotalTime{
            get{
                return lapTimeTotal;
            }
        }

        public float LapAverageSpeed{
            get{
                return lapSpeed;
            }
        }
    }
}