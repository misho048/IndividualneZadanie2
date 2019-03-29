using KBCsv;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FinishLine.Core
{
    public class CountryFactory
    {
        public Dictionary<string, Country> MapOfCountries { get; } = new Dictionary<string, Country>();

        public CountryFactory()
        {
            LoadCountries();
        }

        /// <summary>
        /// Load Countries
        /// loads countries info from a csv file and saves it to a dictionary
        /// </summary>
        public  void LoadCountries()
        {
           
            try
            {
                using (var streamReader = new StreamReader(@"C:\Users\transformer1\source\repos\IndividualneZadanie2\Data\countries.csv")) 
                using (var reader = new CsvReader(streamReader))
                {
                    
                    reader.ReadHeaderRecord();
                    reader.ValueSeparator = ';';
                    while (reader.HasMoreRecords)
                    {
                        var dataRecord = reader.ReadDataRecord();                        
                        
                        MapOfCountries[dataRecord[0]] = new Country(dataRecord[1], dataRecord[2], dataRecord[3], dataRecord[4]);

                    }
                }

            }
            catch (Exception e )
            {
                Debug.WriteLine(e.Message);
            }
        }

    }

  
}
