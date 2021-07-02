using System.Net.Http;

namespace PushNotApi.Vendors.OneSignal
{
    public interface IOneSignalClient
    {
        HttpClient Client { get; set; }
    }
}