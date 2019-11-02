using Newtonsoft.Json;
using System;
using System.IO;
using WeatherTrends.Infrastructure.Abstract;

namespace WeatherTrends.Infrastructure.Concrete
{
    public class JSONHelper : IJSONHelper
    {
        public string ConvertToJson<T>(T input)
        {
            if (input == null)
                throw new Exception("List input cannot be null or empty");

            return JsonConvert.SerializeObject(input);
        }

        public void SaveJson(string filePath, string content)
        {
            string directoryName  = filePath.Substring(0, filePath.LastIndexOf('\\'));

            if (!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);
                
            File.WriteAllText(filePath, content);                        
        }
    }
}
