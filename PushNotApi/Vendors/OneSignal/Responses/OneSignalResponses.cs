using Newtonsoft.Json;
using System.Collections.Generic;

namespace PushNotApi.Vendors.OneSignal.Responses
{
    public class OneSignalBadRequest
    {
        [JsonProperty("errors")]
        public List<string> Errors { get; set; }
    }

    public class OneSignalOk
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("recipients")]
        public int Recipients { get; set; }
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }
    }
}
