using Microsoft.Extensions.Options;
using PushNotApi.Settings;
using System;
using System.Net.Http;

namespace PushNotApi.Vendors.OneSignal
{
    //Class to build the client
    public class OneSignalClient : IOneSignalClient
    {
        // Settings from appsettings.json
        private readonly OneSignalSettings _settings;
        public HttpClient Client { get; set; }

        public OneSignalClient(HttpClient httpClient, IOptions<OneSignalSettings> settings)
        {
            _settings = settings.Value;
            httpClient.BaseAddress = new Uri(_settings.Endpoint);
            // Add header api key to the header authorization
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {_settings.RestApiKey}");
            Client = httpClient;
        }
    }
}
