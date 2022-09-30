using System.Threading.Tasks;
using WeatherInfo.Application.Contracts;

namespace WeatherInfo.Application.Services
{
    public interface IWeatherService
    {
        public Task<MeasurementResponse> GetWeatherMeasurement(MeasurementRequest measurementRequest);
        public Task<AllMeasurementsResponse> GetAllWeatherMeasurements(string unit, string date);
    }
}