using Microsoft.EntityFrameworkCore;
using medical_health_history;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using medical_health_history.Models;

namespace medical_health_history.Data
{
    public class HealthHistoryContext : DbContext
    {
        public HealthHistoryContext(DbContextOptions<HealthHistoryContext> options) : base(options) { }

        public DbSet<HealthHistory> HealthHistories { get; set; }

        public DbSet<UserCredential> Credentials { get; set; }

        public DbSet<HealthHistoryChange> HealthHistoryChanges { get; set; }
    }
}