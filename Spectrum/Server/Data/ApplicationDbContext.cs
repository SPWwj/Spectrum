using Duende.IdentityServer.EntityFramework.Entities;
using Duende.IdentityServer.EntityFramework.Options;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Spectrum.Shared.Models;

namespace Spectrum.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }


        public virtual DbSet<Order> Order { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategory { get; set; } = null!;
        public virtual DbSet<SpectrumMission> SpectrumMission { get; set; } = null!;
        public virtual DbSet<SpectrumPortal> SpectrumPortal { get; set; } = null!;
        public virtual DbSet<SpectrumProduct> SpectrumProduct { get; set; } = null!;
        public virtual DbSet<ApplicationUser> SpectrumUsers { get; set; } = null!;
        public virtual DbSet<NotificationSubscription> NotificationSubscription { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.ToTable("SpectrumUsers");
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(b =>
            {
                b.ToTable("SpectrumUserClaims");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.ToTable("SpectrumUserLogins");
            });

            modelBuilder.Entity<IdentityUserToken<string>>(b =>
            {
                b.ToTable("SpectrumUserTokens");
            });

            modelBuilder.Entity<IdentityRole>(b =>
            {
                b.ToTable("SpectrumRoles");
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(b =>
            {
                b.ToTable("SpectrumRoleClaims");
            });

            modelBuilder.Entity<IdentityUserRole<string>>(b =>
            {
                b.ToTable("SpectrumUserRoles");
            });



        }
    }
}