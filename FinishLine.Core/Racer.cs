using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishLine.Core
{
     public class Racer
    {
        public int ID { get;}
        public string Name { get; }
        public Country Country { get; }
        public int Age { get; }
        public string Sex { get; }

        public Racer(int Id,string name, Country country, int age, string sex)
        {
            ID = Id;
            Name = name;
            Country = country;
            Age = age;
            Sex = sex;
        }

    }
}
