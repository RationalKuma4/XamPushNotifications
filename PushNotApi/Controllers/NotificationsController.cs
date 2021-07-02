using Microsoft.AspNetCore.Mvc;
using PushNotApi.Services;
using System.Net;
using System.Threading.Tasks;

namespace PushNotApi.Controllers
{
    [Route("api/notification"),
     ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IPushNotifications _pushNotifications;

        public NotificationsController(IPushNotifications pushNotifications)
        {
            _pushNotifications = pushNotifications;
        }

        [HttpPost]
        public async Task<IActionResult> Post(string contentNotification)
        {
            var (statusCode, message) = await _pushNotifications.SendNotification(contentNotification);
            // Handle notification service responses to give more information
            // to the consumer
            switch (statusCode)
            {
                case HttpStatusCode.OK:
                    return Ok(new { Message = $"Notifications sent: {message}" });
                case HttpStatusCode.BadRequest:
                    return BadRequest(new { Error = message });
                default:
                    return Problem("Unknown error");
            }
        }
    }
}
