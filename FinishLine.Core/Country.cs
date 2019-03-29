using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishLine.Core
{
     public class Country
    {
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
    }
}
