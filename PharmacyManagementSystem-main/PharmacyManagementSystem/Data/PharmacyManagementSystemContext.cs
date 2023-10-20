using Microsoft.EntityFrameworkCore;

namespace PharmacyManagementSystem.Data
{
    public class PharmacyManagementSystemContext : DbContext
    {
        public PharmacyManagementSystemContext(DbContextOptions<PharmacyManagementSystemContext> options)
            : base(options)
        {
        }

        public DbSet<PharmacyManagementSystem.Models.User> User { get; set; } = default!;

        public DbSet<PharmacyManagementSystem.Models.Drug>? Drug { get; set; }

        public DbSet<PharmacyManagementSystem.Models.Order>? Order { get; set; }

        public DbSet<PharmacyManagementSystem.Models.Sales>? Sale { get; set; }
    }
}
