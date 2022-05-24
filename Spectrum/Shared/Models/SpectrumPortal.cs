using System.Text.Json.Serialization;

namespace Spectrum.Shared.Models
{
    public class SpectrumPortal
    {
        public SpectrumPortal()
        {
            SpectrumMission = new HashSet<SpectrumMission>();
            SpectrumProduct = new HashSet<SpectrumProduct>();
        }

        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty ;
        public string PortalAddress { get; set; } = string.Empty;
        public string? ApplicationUserId { get; set; } 


        [JsonIgnore] public virtual ApplicationUser? ApplicationUser { get; set; }
        public virtual ICollection<SpectrumMission> SpectrumMission { get; set; }
        public virtual ICollection<SpectrumProduct> SpectrumProduct { get; set; }
    }
}
