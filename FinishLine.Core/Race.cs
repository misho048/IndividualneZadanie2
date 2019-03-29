using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishLine.Core
{
    class Race
    {
        private double _lapLength;
        private int _lapNumber;
        private int _numberOfWinners;
        private List<Racer> _listOfRacers;

        public Race(double lapLength, int lapNumber, int numberOfWinners)
        {
            _lapLength = lapLength;
            _lapNumber = lapNumber;
            _numberOfWinners = numberOfWinners;
        }

        public void AddRacer(Racer racer)
        {
            _listOfRacers.Add(racer);
        }

        public void Start()
        {
            Debug.WriteLine("Hue HUe");
        }



    }
}
