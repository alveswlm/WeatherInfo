using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherInfo.Application.Contracts;
using WeatherInfo.Application.Services;

namespace WeatherInfo.API.Controllers
{
    /// <summary>
    /// Weather Controller
    /// </summary>

    [ApiController]
    [Route("weather")]
    public class WeatherController : Controller
    {
        private readonly IWeatherService _weatherService;

        /// <summary>
        /// Controller Constructor
        /// </summary>
        /// <param name="weatherService"></param>
        public WeatherController(IWeatherService weatherService) =>
            _weatherService = weatherService;

        /// <summary>
        /// Collect the measurements for one day, one sensor type, and one unit (Use information: dockan)
        /// </summary>
        /// <param name="measurementRequest"></param>
        /// <returns></returns>
        [HttpGet("measurement")]
        public async Task<IActionResult> GetWeatherMeasurement([FromQuery] MeasurementRequest measurementRequest)
        {
            return Ok(await _weatherService.GetWeatherMeasurement(measurementRequest));
        }

        /// <summary>
        /// Collect the measurements for one day and one unit
        /// </summary>
        /// <param name="unit">Use information: dockan</param>
        /// <param name="date">Date yyyy-MM-ddThh:mm:ss</param>
        /// <returns></returns>
        [HttpGet("allmeasurements")]
        public async Task<IActionResult> GetAllWeatherMeasurements([FromQuery] string unit, string date)
        {
            return Ok(await _weatherService.GetAllWeatherMeasurements(unit, date));
        }
    }
}