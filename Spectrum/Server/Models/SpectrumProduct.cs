namespace Spectrum.Server.Models
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
        public ProductCategory ProductCategory { get; set; } = new ProductCategory();
    }
}
