using System;
using System.Collections.Generic;
using System.Linq;
using WeatherTrends.Core.Abstract;
using WeatherTrends.Core.Mappings;
using WeatherTrends.Core.ViewModels;
using WeatherTrends.Domain.Entities;
using WeatherTrends.Infrastructure.Abstract;

namespace WeatherTrends.Core.Concrete
{
    public class WeatherTrendsService : IWeatherTrendsService
    {
        private readonly ICSVHelper _csvHelper;
        private readonly IJSONHelper _jsonHelper;

        public WeatherTrendsService(ICSVHelper csvHelper, IJSONHelper jsonHelper)
        {
            _csvHelper = csvHelper;
            _jsonHelper = jsonHelper;
        }

        public string GenerateWeatherTrendsReport(string filePath)
        {
            // Validate filepath and throw an exception if it is null or empty
            if (string.IsNullOrEmpty(filePath.Trim()))
                throw new Exception("File path cannot be null or empty");

            WeatherDataMap map = new WeatherDataMap();

            var weatherData = _csvHelper.ParseCSVFile<WeatherData>(filePath, map);           

            var reportData = new WeatherDataViewModel
            {
                WeatherDataForYears = GetWeatherDataForYears(weatherData)
            };            

            return _jsonHelper.ConvertToJson(reportData);
        }

        private List<WeatherDataForMonth> GetWeatherDataForMonths(List<WeatherData> weatherData)
        {
            // Validate the weather data list and throw an exception if it is null or empty
            if (weatherData == null || weatherData.Count == 0)
                throw new Exception("Cannot process null or empty list");           

            var result = weatherData
                            .Where(data => data.Year != null && data.Month != null && data.Day != null && data.RainfallDays != null && data.RainfallMM != null)
                            .GroupBy(
                                data => new { data.Month, data.Year },
                                data => data,
                                (key, records) => new WeatherDataForMonth
                                {
                                    Month = records.Select(r => r.Month).FirstOrDefault().ToString(),
                                    FirstRecordedDate = new DateTime(records.Select(r => r.Year.Value).FirstOrDefault(), records.Select(r => r.Month.Value).FirstOrDefault(), records.Min(r => r.Day.Value)),
                                    LastRecordedDate = new DateTime(records.Select(r => r.Year.Value).FirstOrDefault(), records.Select(r => r.Month.Value).FirstOrDefault(), records.Max(r => r.Day.Value)),
                                    TotalRainfall = records.Sum(r => r.RainfallMM.Value),
                                    AverageRainfall = records.Average(r => r.RainfallMM.Value),
                                    MedianRainfall = CalculateMedian(records.ToList(), "Month"),
                                    DaysWithNoRainfall = records.Count(r => r.RainfallMM == 0),
                                    DaysWithRainfall = records.Count(r => r.RainfallMM > 0)
                                }).ToList();

            return result;
        }

        private List<WeatherDataForYear> GetWeatherDataForYears(List<WeatherData> weatherData)
        {
            // Validate the weather data list and throw an exception if it is null or empty
            if (weatherData == null || weatherData.Count == 0)
                throw new Exception("Cannot process null or empty list");

            var result = weatherData
                            .Where(data => data.Year != null && data.Month != null && data.Day != null && data.RainfallDays != null && data.RainfallMM != null)    
                            .GroupBy(
                                data => data.Year,
                                data => data,
                                (key, records) => new WeatherDataForYear
                                {
                                    Year = records.Select(r => r.Year).FirstOrDefault().ToString(),
                                    FirstRecordedDate = new DateTime(records.Select(r => r.Year.Value).FirstOrDefault(), records.Select(r => r.Month.Value).FirstOrDefault(), records.Min(r => r.Day.Value)),
                                    LastRecordedDate = new DateTime(records.Select(r => r.Year.Value).FirstOrDefault(), records.Select(r => r.Month.Value).FirstOrDefault(), records.Max(r => r.Day.Value)),
                                    TotalRainfall = records.Sum(r => r.RainfallMM.Value),
                                    AverageRainfall = records.Average(r => r.RainfallMM.Value),
                                    MedianRainfall = CalculateMedian(records.ToList(), "Year"),
                                    DaysWithNoRainfall = records.Count(r => r.RainfallMM == 0),
                                    DaysWithRainfall = records.Count(r => r.RainfallMM > 0),
                                    LongestNumberOfDaysRaining = records.Max(r => r.RainfallDays.Value),
                                    MonthlyAggregates = GetWeatherDataForMonths(weatherData)
                                }).ToList();

            return result;
        }

        private decimal CalculateMedian(List<WeatherData> weatherData, string option)
        {
            decimal median = 0.0m;
            
            int count = weatherData.Count();

            if (option == "Month") 
            {
                var orderedRecords = weatherData.OrderBy(p => p.Month);
                median = orderedRecords.ElementAt(count/2).RainfallMM.Value + orderedRecords.ElementAt((count-1)/2).RainfallMM.Value;
                median /= 2;
            }

            if (option == "Year") 
            {
                var orderedRecords = weatherData.OrderBy(p => p.Year);
                median = orderedRecords.ElementAt(count/2).RainfallMM.Value + orderedRecords.ElementAt((count-1)/2).RainfallMM.Value;
                median /= 2;
            }

            return median;
        }
    }
}
