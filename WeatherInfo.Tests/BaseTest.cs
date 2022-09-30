﻿using Azure.Storage.Blobs;
using WeatherInfo.Application.Services;

namespace WeatherInfo.Tests
{
    public abstract class BaseTest
    {
        protected WeatherService WeatherService =>
            new WeatherService(BlobServiceClient);

        protected BlobServiceClient BlobServiceClient =>
            new BlobServiceClient("BlobEndpoint=https://sigmaiotexercisetest.blob.core.windows.net/;QueueEndpoint=https://sigmaiotexercisetest.queue.core.windows.net/;FileEndpoint=https://sigmaiotexercisetest.file.core.windows.net/;TableEndpoint=https://sigmaiotexercisetest.table.core.windows.net/;SharedAccessSignature=sv=2017-11-09&ss=bfqt&srt=sco&sp=rl&se=2028-09-27T16:27:24Z&st=2018-09-27T08:27:24Z&spr=https&sig=eYVbQneRuiGn103jUuZvNa6RleEeoCFx1IftVin6wuA%3D");
    }
}