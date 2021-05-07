using Newtonsoft.Json;

namespace PushNotApi.Vendors.OneSignal
{
    public class Content
    {
        [JsonProperty("en")]
        public string En { get; set; }
    }
}
