using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishLine.Core
{
    public static class DataLayer

    {
       /// <summary>
       /// Save current progress into txt file located in debug folder
       /// </summary>
       /// <param name="logic"></param>
       /// <param name="timeRightNow"></param>
       public static void SaveProgress(Logic logic, TimeSpan timeRightNow)
        {
            string save = $"Save.txt";
            try
            {
                if (!File.Exists(save))
                {
                    File.Create(save).Close();
                }
                TextWriter writer = new StreamWriter(save);
                writer.WriteLine($"{logic.LengthOfLap}\t{logic.NumberOfLaps}\t{logic.NumberOfWinners}\t{timeRightNow}");
                foreach (var runner in logic.RacerFac.RacerMap)
                {
                    writer.WriteLine($"{runner.Key.ToString()}\t{runner.Value.Name}\t{runner.Value.Country.OfficialShortName}" +
                        $"\t{runner.Value.Age}\t{runner.Value.Sex}");
                    foreach (var time in runner.Value.LapTimeList)
                    {
                        writer.WriteLine($"{time.TotalMilliseconds}");
                    }
                    writer.WriteLine("__________");//10 podjebovnikov
                }


                writer.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Unexpected Error Happend\n" +
                    $"Error Info:{e.Message}");
            }
        }

        /// <summary>
        /// Load Race from a file 
        /// Create fills and return instance of Logic
        /// </summary>
        /// <returns></returns>
        public static Logic LoadProgress()
        {
            Logic logic = new Logic();
            string save = "Save.txt";
            try
            {
                if (!File.Exists(save))
                {
                    File.Create(save).Close();
                }

                string[] splitLine;
                string[] lines = File.ReadAllLines(save);

                splitLine = lines[0].Split('\t');
                logic.RaceSetProperties(Convert.ToInt32(splitLine[1]), Convert.ToDouble(splitLine[0]),
                    Convert.ToInt32(splitLine[2]));
                logic.SetTime(splitLine[3]);

                for (int i = 1; i < lines.Length; i++)
                {
                    splitLine = lines[i].Split('\t');
                    string countryKey = "SK";
                    
                    
                
                    foreach (var country in logic.CountryFac.MapOfCountries)
                    {
                        if (country.Value.OfficialShortName.Equals(splitLine[2]))
                        {
                            countryKey = country.Key;
                        }                       

                    }
                    int id = Convert.ToInt32(splitLine[0]);
                    logic.RacerFac.CreateRacerWithID(id, splitLine[1],
                       logic.CountryFac.MapOfCountries[countryKey], Convert.ToInt32(splitLine[3]), splitLine[4]);

                    while (lines[i] != "__________")
                    {
                        if(double.TryParse(lines[i],out double timeMilisec))
                        {
                            logic.CheckLaps(id,TimeSpan.FromMilliseconds(timeMilisec));
                        }
                        i++;

                    }
                }
                return logic;



            }
            catch (Exception e)
            {

                Debug.Write($"Unexpected Error Happend\n" +
                                    $"Error Info:{e.Message}");
                return null;
            }

        }


    }

}
