namespace WeatherInfo.Application.Contracts
{
    public class MeasurementResponse
    {
        public MeasurementResponse(string date, string sensorType, float measurementValue)
        {
            Date = date;
            SensorType = sensorType;
            MeasurementValue = measurementValue;
        }

        public string Date { get; set; }
        public string SensorType { get; set; }
        public float MeasurementValue { get; set; }
    }
}