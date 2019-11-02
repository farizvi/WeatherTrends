using System;
using System.Collections.Generic;

namespace WeatherTrends.Core.ViewModels
{
    public class WeatherDataForYear
    {
        public string Year { get; set; }

        public DateTime FirstRecordedDate { get; set; }

        public DateTime LastRecordedDate { get; set; }

        public decimal TotalRainfall { get; set; }

        public decimal AverageRainfall { get; set; }

        public decimal MedianRainfall { get; set; }

        public int DaysWithNoRainfall { get; set; }

        public int DaysWithRainfall { get; set; }

        public int LongestNumberOfDaysRaining { get; set; }

        public List<WeatherDataForMonth> MonthlyAggregates { get; set; }
    }
}
