using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.Threading.Tasks;
using WeatherInfo.Application.Contracts;

namespace WeatherInfo.Application.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public WeatherService(BlobServiceClient blobServiceClient) =>
            _blobServiceClient = blobServiceClient;

        public async Task<MeasurementResponse> GetWeatherMeasurement(MeasurementRequest measurementRequest)
        {
            var path = string.Format("{0}/{1}", measurementRequest.Unit.ToLower(), measurementRequest.SensorType.ToLower());
            var containerClient = _blobServiceClient.GetBlobContainerClient("iotbackend");
            var blobClient = containerClient.GetBlobClient(string.Format("{0}/{1}.{2}", path, measurementRequest.Date.Split(" ")[0], "csv"));

            BlobDownloadResult downloadResult = await blobClient.DownloadContentAsync();
            string downloadedData = downloadResult.Content.ToString();

            var formatedDate = string.Format("{0}T{1}", measurementRequest.Date.Split(" ")[0], measurementRequest.Date.Split(" ")[1]);

            var dateList = downloadedData.Split("\r\n");
            float measurementValue = 0;

            foreach (string date in dateList)
            {
                if (date.Contains(formatedDate))
                {
                    measurementValue = float.Parse(date.Split(";")[1]);

                    break;
                }
            }

            return new MeasurementResponse(measurementRequest.Date, measurementRequest.SensorType, measurementValue);
        }

        public async Task<AllMeasurementsResponse> GetAllWeatherMeasurements(string unit, string measurementDate)
        {
            string[] sensorTypeList = { "temperature", "humidity", "rainfall" };
            float temperature = 0;
            float humidity = 0;
            float rainfall = 0;

            foreach (var sensorType in sensorTypeList)
            {
                var path = string.Format("{0}/{1}", unit.ToLower(), sensorType.ToLower());
                var containerClient = _blobServiceClient.GetBlobContainerClient("iotbackend");
                var blobClient = containerClient.GetBlobClient(string.Format("{0}/{1}.{2}", path, measurementDate.Split(" ")[0], "csv"));

                BlobDownloadResult downloadResult = await blobClient.DownloadContentAsync();
                string downloadedData = downloadResult.Content.ToString();

                var formatedDate = string.Format("{0}T{1}", measurementDate.Split(" ")[0], measurementDate.Split(" ")[1]);

                var dateList = downloadedData.Split("\r\n");

                foreach (string date in dateList)
                {
                    if (date.Contains(formatedDate))
                    {
                        if (sensorType == "temperature")
                            temperature = float.Parse(date.Split(";")[1]);
                        else if (sensorType == "humidity")
                            humidity = float.Parse(date.Split(";")[1]);
                        else if (sensorType == "rainfall")
                            rainfall = float.Parse(date.Split(";")[1]);

                        break;
                    }
                }
            }

            return new AllMeasurementsResponse(measurementDate, temperature, humidity, rainfall);
        }
    }
}