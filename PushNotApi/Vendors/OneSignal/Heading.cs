using Newtonsoft.Json;

namespace PushNotApi.Vendors.OneSignal
{
    public class Heading
    {
        [JsonProperty("en")]
        public string En { get; set; }
    }
}
