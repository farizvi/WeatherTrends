using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using WeatherTrends.Core.Abstract;
using WeatherTrends.Core.Concrete;
using WeatherTrends.Infrastructure.Abstract;
using WeatherTrends.Infrastructure.Concrete;

namespace WeatherTrends.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup DI
            var serviceProvider = new ServiceCollection()
                                        .AddTransient<ICSVHelper, CSVHelper>()
                                        .AddTransient<IJSONHelper, JSONHelper>()
                                        .AddTransient<IWeatherTrendsService, WeatherTrendsService>()
                                        .BuildServiceProvider();

            var reportGenerator = serviceProvider.GetService<IWeatherTrendsService>();

            // Setup configuration builder
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);                      
            IConfigurationRoot configuration = builder.Build();

            // Setup configuration
            var mySettingsConfig = new MySettingsConfig();
            configuration.GetSection("MySettings").Bind(mySettingsConfig);
           
            Console.WriteLine("Please enter the path for CSV file");
            string path = Console.ReadLine();

            // Generate json file based on the csv file provided
            var jsonResult = reportGenerator.GenerateWeatherTrendsReport(path);

            // Set the output path based on appSettings
            string outputPath = string.Format(mySettingsConfig.OutputDirectory, arg0: Directory.GetCurrentDirectory());

            var jsonHelper = serviceProvider.GetService<IJSONHelper>();
            
            // Write json result to file
            jsonHelper.SaveJson(outputPath, jsonResult);

            Console.WriteLine("Data exported to " + outputPath);
        }
    }
}
