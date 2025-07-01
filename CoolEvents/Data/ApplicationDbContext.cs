using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CoolEvents.Models;

namespace CoolEvents.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CoolEvents.Models.Booking> Booking { get; set; } = default!;
        public DbSet<CoolEvents.Models.Package> Package { get; set; } = default!;
        public DbSet<CoolEvents.Models.Traveler> Traveler { get; set; } = default!;
        public DbSet<CoolEvents.Models.Trip> Trip { get; set; } = default!;
    }
}
