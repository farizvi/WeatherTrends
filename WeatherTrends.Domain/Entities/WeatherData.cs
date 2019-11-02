namespace WeatherTrends.Domain.Entities
{
    public class WeatherData
    {
        public string ProductCode { get; set; }

        public string StationNumber { get; set; }

        public int? Year { get; set; }

        public int? Month { get; set; }

        public int? Day { get; set; }

        public decimal? RainfallMM { get; set; }

        public int? RainfallDays { get; set; }

        public string RainfallQuality { get; set; }
    }
}
