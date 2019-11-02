using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WeatherTrends.Core.Abstract;
using WeatherTrends.Core.Concrete;
using WeatherTrends.Infrastructure.Abstract;
using WeatherTrends.Infrastructure.Concrete;

namespace WeatherTrends.UnitTests.ServiceTests
{
    [TestClass]
    public class WeatherTrendsServiceTest
    {        
        private readonly IWeatherTrendsService _weatherTrendsService;
        private readonly ICSVHelper _csvHelper;
        private readonly IJSONHelper _jsonHelper;

        public WeatherTrendsServiceTest()
        {
            _csvHelper = new CSVHelper();
            _jsonHelper = new JSONHelper(); ;
            _weatherTrendsService = new WeatherTrendsService(_csvHelper, _jsonHelper);
        }

        [TestMethod]
        public void GenerateWeatherTrendsReport_WithEmptyFilePath_ThrowsException()
        {
            try
            {
                var result = _weatherTrendsService.GenerateWeatherTrendsReport("");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("File path cannot be null or empty", ex.Message);
            }
        }
    }
}
