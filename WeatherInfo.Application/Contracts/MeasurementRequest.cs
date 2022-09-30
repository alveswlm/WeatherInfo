namespace WeatherInfo.Application.Contracts
{
    public class MeasurementRequest
    {
        /// <summary>
        /// Measurement date - yyyy-MM-ddThh:mm:ss
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Temperature, Humidity or Rainfall
        /// </summary>
        public string SensorType { get; set; }

        /// <summary>
        /// Unit inside the storage
        /// </summary>
        public string Unit { get; set; }
    }
}