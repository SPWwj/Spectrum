using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spectrum.Server.Data;
using Spectrum.Shared.Models;
using Spectrum.Shared.Services.Email;
using System.Security.Claims;
using System.Text.Json;
using WebPush;

namespace Spectrum.Server.Controllers
{
    [Authorize]
    [ApiController]
    public class NotificationController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<NotificationController> _logger;
        private readonly IEmailService _Email;

        //constructor then

        public NotificationController(ILogger<NotificationController> logger,
            ApplicationDbContext db, IEmailService email)
        {
            _db = db;
            _logger = logger;
            _Email = email;
        }



        //[HttpPut("/notifications/subscribe")]
        ////[Route("/notifications/subscribe")]
        //public async Task<IActionResult> Subscribe()
        //{


        //    // We're storing at most one subscription per user, so delete old ones.
        //    // Alternatively, you could let the user register multiple subscriptions from different browsers/devices.
        //    var userId = GetUserId();
        //    var oldSubscriptions = _db.NotificationSubscription.Where(e => e.UserId == userId);
        //    _db.NotificationSubscription.RemoveRange(oldSubscriptions);

        //    // Store new subscription
        //    NotificationSubscription notificationSubscription = new NotificationSubscription() { UserId = userId };
        //    _db.NotificationSubscription.Attach(notificationSubscription);

        //    await _db.SaveChangesAsync();
        //    return Ok(notificationSubscription);

        //}
        [HttpGet("/notifications/send/{missionId}")]
        public async Task Trigger(string missionId)
        {
            // In the background, send push notifications if possible
            var orders = _db.Order.Where(id => id.MissionUUID == missionId).ToList();
            foreach (var order in orders)
            {
                if (_Email.IsValidEmail(order.Email))
                {
                    await _Email.SendEmailAsync(order.Email, "Hello From Spectrum",
                    new EventModel { Id = 1, Subject = "Testing", StartTime = DateTime.Now, EndTime = DateTime.Now, EmployeeId = 1 });
                }
            }



            var subscription = await _db.NotificationSubscription.Where(e => e.ApplicationUserId == GetUserId()).SingleOrDefaultAsync();
            if (subscription != null)
            {
                //Change Order Type
                _ = TrackAndSendNotificationsAsync(new Order(), subscription);
            }
        }

        [HttpPost("/notifications/email")]
        public async Task SubEmail(Order order)
        {
            await _db.Order.AddAsync(order);
            await _db.SaveChangesAsync();
        }


        //To take out this method, can it service to reduce code duplication
        private string GetUserId()
        {
            return HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        private static async Task TrackAndSendNotificationsAsync(Order order, NotificationSubscription subscription)
        {
            // In a realistic case, some other backend process would track
            // order delivery progress and send us notifications when it
            // changes. Since we don't have any such process here, fake it.
            //await SendNotificationAsync(order, subscription, "Your order has been dispatched!");

            await SendNotificationAsync(order, subscription, "Your order is now delivered. Enjoy!");
        }

        private static async Task SendNotificationAsync(Order order, NotificationSubscription subscription, string message)
        {
            // For a real application, generate your own
            var publicKey = "BLC8GOevpcpjQiLkO7JmVClQjycvTCYWm6Cq_a7wJZlstGTVZvwGFFHMYfXt6Njyvgx_GlXJeo5cSiZ1y4JOx1o";
            var privateKey = "OrubzSz3yWACscZXjFQrrtDwCKg-TGFuWhluQ2wLXDo";

            var pushSubscription = new PushSubscription(subscription.Url, subscription.P256dh, subscription.Auth);
            var vapidDetails = new VapidDetails("mailto:<someone@example.com>", publicKey, privateKey);
            var webPushClient = new WebPushClient();
            try
            {
                var payload = JsonSerializer.Serialize(new
                {
                    message,
                    url = $"myorders/{"123"}",
                });
                await webPushClient.SendNotificationAsync(pushSubscription, payload, vapidDetails);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error sending push notification: " + ex.Message);
            }
        }
    }
}
