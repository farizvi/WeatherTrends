namespace WeatherTrends.Infrastructure.Abstract
{
    public interface IJSONHelper
    {
        string ConvertToJson<T>(T input);

        void SaveJson(string filePath, string content);
    }
}
