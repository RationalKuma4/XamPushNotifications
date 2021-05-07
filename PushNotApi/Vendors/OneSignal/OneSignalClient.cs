using System;
using System.Net.Http;

namespace PushNotApi.Vendors.OneSignal
{
    public interface IOneSignalClient
    {
        HttpClient Client { get; set; }
    }

    public class OneSignalClient : IOneSignalClient
    {
        public HttpClient Client { get; set; }

        public OneSignalClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://onesignal.com/api/v1/");
            httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json; charset=utf-8");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic MmFmNGZlYmUtNDQxMy00ODY3LWE2N2ItZmYxNGYyMTBlMjEz");
            Client = httpClient;
        }
    }
}
