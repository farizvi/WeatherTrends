using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WeatherTrends.Domain.Entities;
using WeatherTrends.Infrastructure.Abstract;
using WeatherTrends.Infrastructure.Concrete;

namespace WeatherTrends.UnitTests.InfrastructureTests
{
    [TestClass]
    public class JSONHelperTests
    {
        private readonly IJSONHelper _jsonHelper;

        public JSONHelperTests()
        {
            _jsonHelper = new JSONHelper();
        }

        [TestMethod]
        public void ConvertToJson_WithNullInput_ThrowsException()
        {
            try
            {
                var result = _jsonHelper.ConvertToJson<WeatherData>(null);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("List input cannot be null or empty", ex.Message);
            }
        }
    }
}
