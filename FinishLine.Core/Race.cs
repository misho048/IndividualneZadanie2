
namespace FinishLine.Core
{
    class Race
    {
        #region properties, field and constructor
        /// <summary>
        /// properties and fields
        /// </summary>
        private double _lapLength;
        private int _lapNumber;
        private int _numberOfWinners;
        
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="lapLength"></param>
        /// <param name="lapNumber"></param>
        /// <param name="numberOfWinners"></param>
        public Race(double lapLength, int lapNumber, int numberOfWinners)
        {
            _lapLength = lapLength;
            _lapNumber = lapNumber;
            _numberOfWinners = numberOfWinners;
        }
        #endregion

     



    }
}
