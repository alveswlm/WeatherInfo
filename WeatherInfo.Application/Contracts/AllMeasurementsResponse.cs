namespace WeatherInfo.Application.Contracts
{
    public class AllMeasurementsResponse
    {
        public AllMeasurementsResponse(string date, float temperature, float humidity, float rainfall)
        {
            Date = date;
            Temperature = temperature;
            Humidity = humidity;
            Rainfall = rainfall;
        }

        public string Date { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public float Rainfall { get; set; }
    }
}