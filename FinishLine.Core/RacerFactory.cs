using System;
using System.Collections.Generic;


namespace FinishLine.Core
{/// <summary>
/// Class is creating racers and holding them in dictionary
/// 
/// </summary>
    public class RacerFactory
    {
        #region properties and constructor
        public int Id { get; private set; } = 0;
        public Dictionary<int, Racer> RacerMap { get; }

        public RacerFactory()
        {
            RacerMap = new Dictionary<int, Racer>();
        }
        #endregion
        /// <summary>
        /// Add time for lap to Racer LapTimeList
        /// </summary>
        /// <param name="id"></param>
        /// <param name="time"></param>
        public void AddLap(int id, TimeSpan time)
        {
            RacerMap[id].AddLap(time);
        }


        /// <summary>
        /// Create Racer with random still UNIQUEid
        /// </summary>
        /// <param name="name"></param>
        /// <param name="country"></param>
        /// <param name="age"></param>
        /// <param name="sex"></param>
        public void CreateRacer(string name, Country country, int age, string sex)
        {
            if (RacerMap.Keys.Count<=999)
            {
                while (true)
                {
                    Id++;

                    if (!RacerMap.ContainsKey(Id))
                    {
                        break;
                    }

                    if (Id == 999)
                    {
                        Id = 0;
                    }

                }
                RacerMap[Id] = new Racer(Id, name, country, age, sex);
            }

        }

        /// <summary>
        /// create Racer with speciffic ID, 
        /// if during loading from file there is a ID confrontation
        /// another random is created
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="country"></param>
        /// <param name="age"></param>
        /// <param name="sex"></param>
        public void CreateRacerWithID(int id, string name, Country country, int age, string sex)
        {
            if (RacerMap.Keys.Count <= 999)
            {
                if (RacerMap.ContainsKey(id))
                {
                    while (true)
                    {
                        id++;

                        if (!RacerMap.ContainsKey(id))
                        {
                            break;
                        }

                        if (id == 999)
                        {
                            id = 0;
                        }

                    }
                    RacerMap[id] = new Racer(id, name, country, age, sex);
                }
                else
                {
                    RacerMap[id] = new Racer(id, name, country, age, sex);
                }
            }
            
        }




    }
}
