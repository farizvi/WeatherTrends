using CsvHelper.Configuration;
using System.Collections.Generic;

namespace WeatherTrends.Infrastructure.Abstract
{
    public interface ICSVHelper 
    {
        /// <summary>
        /// This method takes filePath as parameter and returns the collection of type passed as type parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        List<T> ParseCSVFile<T>(string filePath, ClassMap map);
    }
}
