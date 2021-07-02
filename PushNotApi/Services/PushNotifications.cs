using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PushNotApi.Settings;
using PushNotApi.Vendors.OneSignal;
using PushNotApi.Vendors.OneSignal.Responses;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PushNotApi.Services
{
    public class PushNotifications : IPushNotifications
    {
        private readonly IOneSignalClient _oneSignalClient;
        private readonly OneSignalSettings _settings;

        public PushNotifications(IOneSignalClient oneSignalClient, IOptions<OneSignalSettings> settings)
        {
            _oneSignalClient = oneSignalClient;
            _settings = settings.Value;
        }

        public async Task<(HttpStatusCode, string)> SendNotification(string contentNotification)
        {
            // Build the notification payload
            var notification = BuildNotification("", contentNotification, new List<string>());
            var content = new StringContent(notification, Encoding.UTF8, "application/json");
            // Request the service to send the notification
            var result = await _oneSignalClient.Client.PostAsync(_settings.VendorResourceNotifications, content);
            // Check the status result code
            // depending of the result we will send different information
            if (result.IsSuccessStatusCode)
            {
                var resultMessage = JsonConvert
                    .DeserializeObject<OneSignalOk>(await result.Content.ReadAsStringAsync())?
                    .Recipients;
                return (result.StatusCode, resultMessage.ToString());
            }
            else
            {
                var resultMessage = JsonConvert
                    .DeserializeObject<OneSignalBadRequest>(await result.Content.ReadAsStringAsync())?
                    .Errors;
                return (result.StatusCode, resultMessage?[0]);
            }
        }

        //Method to build the notification json payload
        private string BuildNotification(string heading, string content, List<string> playersId)
        {
            var notification = new Notification
            {
                // OneSignal AppId
                AppId = _settings.OneSignalAppId,
                Heading = new Heading
                {
                    En = heading
                },
                Content = new Content
                {
                    En = content
                },
                // If we want to send notifications to segments or
                // all the subscribers
                Segments = null,
                // If we want to send notifications to one subscriber
                PlayersId = new List<string> { "1d7b916b-89be-49b8-914c-ca85e29e1d11" } // Get value from storage
            };
            return JsonConvert.SerializeObject(notification);
        }
    }
}
