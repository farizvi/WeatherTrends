using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WeatherTrends.Infrastructure.Abstract;

namespace WeatherTrends.Infrastructure.Concrete
{
    public class CSVHelper : ICSVHelper
    {
        public List<T> ParseCSVFile<T>(string filePath, ClassMap map)
        {
            if (string.IsNullOrEmpty(filePath.Trim()))
                throw new Exception("File path cannot be empty");

            if (map == null)
                throw new Exception("ClassMap cannot be null");

            TextReader reader = new StreamReader(filePath);

            var csvReader = new CsvReader(reader);
            csvReader.Configuration.RegisterClassMap(map);
            var records = csvReader.GetRecords<T>();

            return records.ToList<T>();
        }
    }
}
