using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PushNotApi.Services;

namespace PushNotApi.Controllers
{
    [Route("api/notifications"),
     ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IPushNotifications _pushNotifications;

        public NotificationsController(IPushNotifications pushNotifications)
        {
            _pushNotifications = pushNotifications;
        }

        public async Task<IActionResult> SendNotification()
            => await _pushNotifications.SendNotification() ? Ok() : Problem();
    }
}
