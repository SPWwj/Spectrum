using System.Text.Json.Serialization;

namespace Spectrum.Shared.Models
{
    public class Order
    {
        public string Id { get; set; } = string.Empty;
        public string? ApplicationUserId { get; set; } = string.Empty;
        [JsonIgnore] public virtual ApplicationUser? ApplicationUser { get; set; } 
        public string Email { get; set; }
        public string MissionUUID { get; set; }

        public bool Done { get; set; } = false;
    }
}
