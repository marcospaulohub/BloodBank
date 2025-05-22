using BloodBank.Core.Entities;
using BloodBank.Infra.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infra
{
    public class BloodBankDbContext : DbContext
    {
        public BloodBankDbContext(DbContextOptions<BloodBankDbContext> options)
            : base(options) { }
        
        public DbSet<Doador> Doadores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DoadorMap());

            base.OnModelCreating(builder);
        }
    }
}
