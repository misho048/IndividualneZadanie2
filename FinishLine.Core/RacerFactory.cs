using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FinishLine.Core
{
    public class RacerFactory
    {
        public int Id { get; private set; } = 0;
        public Dictionary<int, Racer> RacerMap { get; }

        public RacerFactory()
        {
            RacerMap = new Dictionary<int, Racer>();
        }

        public void AddLap(int id,TimeSpan time)
        {
            RacerMap[id].AddLap(time);
        }


        public void CreateRacer(string name, Country country, int age, string sex)
        {
            
           
            while (true)
            {
                Id++;
                
                if (!RacerMap.ContainsKey(Id))
                {
                    
                    break;
                }
            }
            RacerMap[Id] = new Racer(Id, name, country, age, sex);
       

        }

        public void CreateRacerWithID(int id, string name, Country country, int age, string sex)
        {
            RacerMap[id] = new Racer(id, name, country, age, sex);
        }




    }
}
