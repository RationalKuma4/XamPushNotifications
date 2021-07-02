using System.Net;
using System.Threading.Tasks;

namespace PushNotApi.Services
{
    public interface IPushNotifications
    {
        Task<(HttpStatusCode StatusCode, string Message)> SendNotification(string contentNotification);
    }
}