using KBCsv;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;


namespace FinishLine.Core
{
    public class CountryFactory
    {
        #region property and constructor
        public Dictionary<string, Country> MapOfCountries { get; } = new Dictionary<string, Country>();

        public CountryFactory()
        {
            LoadCountries();
        }
        #endregion
        /// <summary>
        /// Load Countries
        /// loads countries info from a csv file and saves it to a dictionary        
        /// </summary>
        //TODO:relative path
        public void LoadCountries()
        {
           
            try
            {
                string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Data\countries.csv");
                using (var streamReader = new StreamReader(path)) 
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
