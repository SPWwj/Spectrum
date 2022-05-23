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

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? PortalAddress { get; set; }
        public string? ApplicationUserId { get; set; }


        [JsonIgnore] public virtual ApplicationUser ApplicationUser { get; set; } = new ApplicationUser();
        public virtual ICollection<SpectrumMission> SpectrumMission { get; set; }
        public virtual ICollection<SpectrumProduct> SpectrumProduct { get; set; }
    }
}
