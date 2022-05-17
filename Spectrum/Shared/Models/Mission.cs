
namespace Spectrum.Shared.Models
{
    public class Mission
    {
      
        public String Name { get; set; } = "";
        public string ClassName { get; set; } = "";
        public int Id { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Show { get; set; }
        public Status Status { get; set; }
    }
    public enum Status
    {
        Preparing = 0, Done = 1
    }
}
