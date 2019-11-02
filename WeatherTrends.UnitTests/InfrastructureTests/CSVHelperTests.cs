using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WeatherTrends.Domain.Entities;
using WeatherTrends.Infrastructure.Abstract;
using WeatherTrends.Infrastructure.Concrete;

namespace WeatherTrends.UnitTests.InfrastructureTests
{
    [TestClass]
    public class CSVHelperTests
    {
        private readonly ICSVHelper _csvHelper;

        public CSVHelperTests()
        {
            _csvHelper = new CSVHelper();
        }

        [TestMethod]
        public void ParseCSV_WithEmptyPath_ThrowsException()
        {
            try
            {
                var result = _csvHelper.ParseCSVFile<WeatherData>("", null);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("File path cannot be empty", ex.Message);
            }                       
        }

        [TestMethod]
        public void ParseCSV_WithNullClassMap_ThrowsException()
        {
            try
            {
                // using fake path here as the only purpose is to test the scenario where ClassMap is null
                var result = _csvHelper.ParseCSVFile<WeatherData>("C:\\Temp\\dummyfile.csv", null);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("ClassMap cannot be null", ex.Message);
            }
        }
    }
}
