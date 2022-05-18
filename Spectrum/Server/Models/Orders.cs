namespace Spectrum.Server.Models
{
    public class Orders
    {
        public Guid Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; } = new();
        public SpectrumMission SpectrumMission { get; set; } = new();
    }
}
