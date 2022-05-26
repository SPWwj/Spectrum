using Microsoft.AspNetCore.Identity;

namespace Spectrum.Shared.Models
{
    public class ApplicationUser : IdentityUser
    {
       
        public ApplicationUser()
        {
            Order = new HashSet<Order>();
            SpectrumPortal = new HashSet<SpectrumPortal>();
            NotificationSubscription = new HashSet<NotificationSubscription>();
        }

        public int SpectrumPortalLimit { get; set; } = 3;
        public virtual ICollection<SpectrumPortal> SpectrumPortal { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<NotificationSubscription> NotificationSubscription { get; set; }
    }
}