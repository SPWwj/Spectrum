using System.Text.Json.Serialization;

namespace Spectrum.Shared.Models;

public class NotificationSubscription
{
    public int NotificationSubscriptionId { get; set; }

    public string? ApplicationUserId { get; set; }

    [JsonIgnore] public virtual ApplicationUser? ApplicationUser { get; set; }

    public string Url { get; set; } = string.Empty;

    public string P256dh { get; set; } = string.Empty;

    public string Auth { get; set; } = string.Empty;
}
