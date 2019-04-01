using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace FinishLine.Core
{
    public class Logic
    {
        #region fields, properties and constructor

        /// <summary>
        /// Fields and Properties
        /// </summary>
        public CountryFactory CountryFac { get; }
        public RacerFactory RacerFac { get; private set; }
        public int NumberOfLaps { get; private set; } = 5;
        public double LengthOfLap { get; private set; } = 1.0;
        public int NumberOfWinners { get; set; } = 3;
        public List<int> _results { get; private set; } = new List<int>();
        private int _currentNumberOfWinners = 0;
        private TimeSpan _time=TimeSpan.Zero;

        /// <summary>
        /// Constructor, creating CountryFactory and RacerFactory
        /// </summary>
        public Logic()
        {
            CountryFac = new CountryFactory();
            RacerFac = new RacerFactory();

        }
        #endregion
        /// <summary>
        /// set Race properties
        /// </summary>
        /// <param name="laps"></param>
        /// <param name="length"></param>
        /// <param name="winPlace"></param>
        
        public void RaceSetProperties(int laps, double length, int winPlace)
        {
            NumberOfLaps = laps;
            LengthOfLap = length;
            NumberOfWinners = winPlace;
        }

        #region time methods
        /// <summary>
        /// returns time difference for a lap
        /// </summary>
        /// <returns></returns>
        public DateTime GetTime()
        {           
            return DateTime.Now - _time;
        }

        /// <summary>
        /// method for getting current race time form a file
        /// </summary>
        /// <returns></returns>
        public void SetTime(string time)
        {
            TimeSpan.TryParse(time, out TimeSpan curentTime);
            
            _time = curentTime;
        }

        #endregion
        /// <summary>
        /// Add Time of the lap as TimeSpan to a Racer
        /// </summary>
        /// <param name="runnerID"></param>
        /// <param name="time"></param>
        /// <returns></returns>
#region laps methods
        public void DoLap(int runnerID, DateTime time)
        {
            TimeSpan t;
            if (RacerFac.RacerMap[runnerID].LapTimeList.Count == 0)
            {
                t = DateTime.Now - time;
            }
            else
            {
                TimeSpan sum = TimeSpan.Zero;
                t = DateTime.Now - time;

                foreach (var lapTime in RacerFac.RacerMap[runnerID].LapTimeList)
                {
                    sum += lapTime;
                }
                t = t - sum;
            }
            CheckLaps(runnerID, t);


        }
                        
        /// <summary>
        /// Checks if the runner finished the race
        /// </summary>
        /// <param name="runnerID"></param>
        /// <param name="t"></param>
        public void CheckLaps(int runnerID, TimeSpan t)
        {
            if (RacerFac.RacerMap[runnerID].LapTimeList.Count - 1 == NumberOfLaps)
            {

                _results.Add(runnerID);
                _currentNumberOfWinners++;


            }
            else if (RacerFac.RacerMap[runnerID].LapTimeList.Count - 1 < NumberOfLaps)
            {
                RacerFac.AddLap(runnerID, t);
            }
        }

        /// <summary>
        /// Overloading, checking if runner finished race, without time
        /// </summary>
        /// <param name="runnerID"></param>
        private void CheckLaps(int runnerID)
        {
            if (RacerFac.RacerMap[runnerID].LapTimeList.Count - 1 == NumberOfLaps)
            {
                _results.Add(runnerID);
                _currentNumberOfWinners++;
            }

        }
        #endregion
        /// <summary>
        /// Remove runner from dictionary
        /// </summary>
        /// <param name="runnerID"></param>
        public void RemoveRunner(int runnerID)
        {
            RacerFac.RacerMap.Remove(runnerID);
        }

        /// <summary>
        /// Print Runners which succesfully finished race
        /// </summary>
        /// <param name="runnerID"></param>
        /// <returns></returns>
        public string PrintAttendants(int runnerID)
        {
            string result = "";
            CheckLaps(runnerID);
            if (_currentNumberOfWinners > 0)

            {
                result += $"Leaderboard: \n";
                for (int i = 0; i < _currentNumberOfWinners; i++)
                {
                    TimeSpan totalTime = TimeSpan.Zero;
                    foreach (TimeSpan time in RacerFac.RacerMap[_results[i]].LapTimeList)
                    {
                        totalTime += time;
                    }


                    result += $" {i + 1}: {RacerFac.RacerMap[_results[i]].Name} " +
                        $"Total Time:{totalTime} Best Lap: {GetTimes(_results[i]).bestRun} \n" +
                        $"Avg Lap: {GetTimes(_results[i]).avgRun}\n";
                }
            }
            return result;
        }

        /// <summary>
        /// Removing finished or disqualified racers from combobox options
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, Racer> ComboMap()
        {
            Dictionary<int, Racer> myDict = new Dictionary<int, Racer>(RacerFac.RacerMap);
            foreach (var key in _results)
            {
                myDict.Remove(key);
            }
            return myDict;

        }

        /// <summary>
        /// Checking status of the race, returns false if race is over
        /// </summary>
        /// <returns></returns>
        public bool RaceStatus()
        {
           
            if (_results.Count == RacerFac.RacerMap.Count)
            {
                return false;

            }
            else return true;
        }

        /// <summary>
        /// returns best and average time of the finished racers
        /// </summary>
        /// <param name="runnerID"></param>
        /// <returns></returns>
        private (TimeSpan bestRun, TimeSpan avgRun) GetTimes(int runnerID)
        {
            TimeSpan bestRun = TimeSpan.MaxValue;
            TimeSpan avgRun = TimeSpan.Zero;
            int count = 0;

            for (int i = 0; i < RacerFac.RacerMap[runnerID].LapTimeList.Count(); i++)
            {
                count++;
                if ((bestRun > RacerFac.RacerMap[runnerID].LapTimeList[i])&&(RacerFac.RacerMap[runnerID].LapTimeList[i]>TimeSpan.Zero))
                {
                    bestRun = RacerFac.RacerMap[runnerID].LapTimeList[i];
                }
                avgRun += RacerFac.RacerMap[runnerID].LapTimeList[i];

            }

            long avgTime = Convert.ToInt64(avgRun.TotalMilliseconds) / count;
            TimeSpan ts = TimeSpan.FromMilliseconds(avgTime);
            return (bestRun, ts);
        }

        /// <summary>
        /// reseting all properties to default, except runnermap and country map
        /// </summary>
        public void Reset()
        {
            foreach (var runner in RacerFac.RacerMap)
            {
                _results = new List<int>();
                _currentNumberOfWinners = 0;
                runner.Value.LapTimeList.Clear();
                runner.Value.LapTimeList.Add(TimeSpan.Zero);
                _time = TimeSpan.Zero;

            }

        }

    }
}
