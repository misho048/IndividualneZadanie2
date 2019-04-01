

namespace FinishLine.Core
{/// <summary>
/// class is used just for manipulaitng and saving countries
/// </summary>
     public class Country
    {
        #region properties and constructor
        public string SlovakName { get; }
        public string EnglishShortName { get; }
        public string OfficialShortName { get; }
        public string DependencyOf { get; }

        public Country(string slovakName, string englishShortName, string officialShortName, string dependencyOf)
        {
            SlovakName = slovakName;
            EnglishShortName = englishShortName;
            OfficialShortName = officialShortName;
            DependencyOf = dependencyOf;
        }
        #endregion  
    }
}
