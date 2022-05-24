using System.Text.Json.Serialization;

namespace Spectrum.Shared.Models
{
    public class SpectrumProduct
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Image { get; set; }
        public string? Description { get; set; }
        public bool Special { get; set; }
        public double Price { get; set; }
        public double Offer { get; set; }
        public int? ProductCategoryId { get; set; }

        [JsonIgnore] public virtual ProductCategory? ProductCategory { get; set; } 
    }
}
