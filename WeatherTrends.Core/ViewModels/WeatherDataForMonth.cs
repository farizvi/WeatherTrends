using System;

namespace WeatherTrends.Core.ViewModels
{
    public class WeatherDataForMonth
    {
        public string Month { get; set; }

        public DateTime FirstRecordedDate { get; set; }

        public DateTime LastRecordedDate { get; set; }

        public decimal TotalRainfall { get; set; }

        public decimal AverageRainfall { get; set; }

        public decimal MedianRainfall { get; set; }

        public int DaysWithNoRainfall { get; set; }

        public int DaysWithRainfall { get; set; }

    }
}
