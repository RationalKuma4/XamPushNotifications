using Newtonsoft.Json;
using PushNotApi.Vendors.OneSignal;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PushNotApi.Services
{
    public interface IPushNotifications
    {
        Task<bool> SendNotification();
    }

    public class PushNotifications : IPushNotifications
    {
        private readonly IOneSignalClient _oneSignalClient;
        private const string AppId = "71940d90-308a-4408-a2bc-a94ebf4722ad";
        private const string VendorResource = "notifications";

        public PushNotifications(IOneSignalClient oneSignalClient)
        {
            _oneSignalClient = oneSignalClient;
        }

        public async Task<bool> SendNotification()
        {
            var notification = BuildNotification("", "", new List<string>());
            var content = new StringContent(notification, Encoding.UTF8, "application/json");
            var result = await _oneSignalClient.Client.PostAsync(VendorResource, content);
            return result.IsSuccessStatusCode;
        }

        private string BuildNotification(string heading, string content, List<string> playersId)
        {
            var notification = new Notification
            {
                AppId = AppId,
                Heading = new Heading
                {
                    En = heading
                },
                Content = new Content
                {
                    En = content
                },
                Segments = null,
                PlayersId = playersId
            };

            return JsonConvert.SerializeObject(notification);
        }
    }
}
