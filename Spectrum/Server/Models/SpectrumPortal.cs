namespace Spectrum.Server.Models
{
    public class SpectrumPortal
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? PortalAddress { get; set; }
        public IEnumerable<SpectrumMission>? Missions { get; set; }
        public IEnumerable<SpectrumProduct>? SpectrumProducts { get; set; }
    }
}
