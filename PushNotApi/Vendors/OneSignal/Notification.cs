using Newtonsoft.Json;
using System.Collections.Generic;

namespace PushNotApi.Vendors.OneSignal
{
    public class Notification
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("contents")]
        public Content Content { get; set; }

        [JsonProperty("headings")]
        public Heading Heading { get; set; }

        [JsonProperty("included_segments")]
        public List<string> Segments { get; set; }

        [JsonProperty("include_player_ids")]
        public List<string> PlayersId { get; set; }
    }
}
