using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WeatherInfo.Application.Contracts;
using WeatherInfo.Application.Services;

namespace WeatherInfo.Tests.Services
{
    [TestClass]
    public class WeatherServiceTest : BaseTest
    {
        [TestMethod]
        public async Task GetWeatherMeasurement_Success()
        {
            // Arrange
            var measurementRequest = new MeasurementRequest
            {
                Date = "2019-01-10 00:01:05",
                SensorType = "temperature",
                Unit = "dockan"
            };

            var measurementResponse = new MeasurementResponse("2019-01-10 00:01:05", "temperature", (float)-0.62);

            // Act
            var response = await WeatherService.GetWeatherMeasurement(measurementRequest);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(measurementResponse.Date, response.Date);
            Assert.AreEqual(measurementResponse.SensorType, response.SensorType);
            Assert.AreEqual(measurementResponse.MeasurementValue, response.MeasurementValue);
        }

        [TestMethod]
        public async Task GetAllWeatherMeasurements_Success()
        {
            // Arrange
            var measurementDate = "2019-01-10 00:02:20";
            var unit = "dockan";

            var allMeasurementsResponse = new AllMeasurementsResponse("2019-01-10 00:02:20", (float)-0.63, (float)9.34, (float)0.01);

            // Act
            var response = await WeatherService.GetAllWeatherMeasurements(unit, measurementDate);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(allMeasurementsResponse.Date, response.Date);
            Assert.AreEqual(allMeasurementsResponse.Temperature, response.Temperature);
            Assert.AreEqual(allMeasurementsResponse.Humidity, response.Humidity);
            Assert.AreEqual(allMeasurementsResponse.Rainfall, response.Rainfall);
        }
    }
}