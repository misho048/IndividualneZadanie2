using System;
using System.Collections.Generic;
namespace FinishLine.Core
{
    public class Racer
    {
        #region properties and constructor
        /// <summary>
        /// properties of Racer
        /// </summary>
        public int ID { get; }
        public string Name { get; }
        public Country Country { get; }
        public int Age { get; }
        public string Sex { get; }
        /// <summary>
        /// this list contains Time for each round
        /// </summary>
        public List<TimeSpan> LapTimeList = new List<TimeSpan>();

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="name"></param>
        /// <param name="country"></param>
        /// <param name="age"></param>
        /// <param name="sex"></param>
        public Racer(int Id, string name, Country country, int age, string sex)
        {
            ID = Id;
            Name = name;
            Country = country;
            Age = age;
            Sex = sex;
            LapTimeList.Add(TimeSpan.Zero);

        }
        #endregion

        /// <summary>
        /// add time to a list of Laps
        /// </summary>
        /// <param name="laptime"></param>
        public void AddLap(TimeSpan laptime)
        {
            LapTimeList.Add(laptime);
        }




    }
}
