namespace WeatherTrends.Core.Abstract
{
    public interface IWeatherTrendsService
    {
        /// <summary>
        /// Generates weather trends report in json format based on csv file provided as input
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        string GenerateWeatherTrendsReport(string filePath);
    }
}
