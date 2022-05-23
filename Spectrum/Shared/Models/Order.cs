using System.Text.Json.Serialization;

namespace Spectrum.Shared.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string ApplicationUserId { get; set; } = string.Empty;
        public virtual ApplicationUser ApplicationUser { get; set; } = new();
        public int SpectrumMissionId { get; set; }
        [JsonIgnore] public virtual SpectrumMission SpectrumMission { get; set; } = new();
    }
}
