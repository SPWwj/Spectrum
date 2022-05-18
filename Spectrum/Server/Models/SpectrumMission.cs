
namespace Spectrum.Server.Models
{
    public class SpectrumMission
    {

        public int Name { get; set; }
        public Guid UUID { get; set; }
        public int Id { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Remark { get; set; }

        public SpectrumPortal SpectrumPortal { get; set; } = new SpectrumPortal();
    }

}
