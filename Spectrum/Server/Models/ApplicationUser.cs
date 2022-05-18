using Microsoft.AspNetCore.Identity;

namespace Spectrum.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int SpectrumPortalLimit { get; set; } = 3;
        public IEnumerable<SpectrumPortal>? SpectrumPortals { get; set; }
        public IEnumerable<Orders>? Orders { get; set; }
    }
}