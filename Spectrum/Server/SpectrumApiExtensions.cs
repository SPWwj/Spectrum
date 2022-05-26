using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Spectrum.Server.Data;
using Spectrum.Shared.Models;

namespace Spectrum.Server;

public static class SpectrumApiExtensions
{

    public static WebApplication MapSpectrumApi(this WebApplication app)
    {

        // Subscribe to notifications
        app.MapPut("/notifications/subscribe", [Authorize] async (
            HttpContext context,
            ApplicationDbContext db,
            NotificationSubscription subscription) => {

                // We're storing at most one subscription per user, so delete old ones.
                // Alternatively, you could let the user register multiple subscriptions from different browsers/devices.
                var userId = GetUserId(context);
                var oldSubscriptions = db.NotificationSubscription.Where(e => e.ApplicationUserId == userId);
                db.NotificationSubscription.RemoveRange(oldSubscriptions);

                // Store new subscription
                subscription.ApplicationUserId = userId;
                db.NotificationSubscription.Attach(subscription);

                await db.SaveChangesAsync();
                return Results.Ok(subscription);

            });

    //    // Specials
    //    app.MapGet("/specials", async (PizzaStoreContext db) => {

    //        var specials = await db.Specials.ToListAsync();
    //        return Results.Ok(specials);

    //    });

    //    // Toppings
    //    app.MapGet("/toppings", async (PizzaStoreContext db) => {
    //        var toppings = await db.Toppings.OrderBy(t => t.Name).ToListAsync();
    //        return Results.Ok(toppings);
    //    });

        return app;

    }


    private static string GetUserId(HttpContext context)
    {
        return context.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }

}