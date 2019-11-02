using CsvHelper.Configuration;
using WeatherTrends.Domain.Entities;

namespace WeatherTrends.Core.Mappings
{
    public sealed class WeatherDataMap : ClassMap<WeatherData>
    {
        public WeatherDataMap()
        {
            Map(m => m.ProductCode).Name("Product code");
            Map(m => m.StationNumber).Name("Bureau of Meteorology station number");
            Map(m => m.Year).Name("Year");
            Map(m => m.Month).Name("Month");
            Map(m => m.Day).Name("Day");
            Map(m => m.RainfallMM).Name("Rainfall amount (millimetres)");
            Map(m => m.RainfallDays).Name("Period over which rainfall was measured (days)");
            Map(m => m.RainfallQuality).Name("Quality");
        }
    }
}
