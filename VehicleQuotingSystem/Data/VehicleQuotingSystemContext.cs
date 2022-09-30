using Microsoft.EntityFrameworkCore;
using VehicleQuotingSystem.Models;

namespace VehicleQuotingSystem.Data
{
    public class VehicleQuotingSystemContext : DbContext
    {
        public VehicleQuotingSystemContext(DbContextOptions<VehicleQuotingSystemContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleQuote>()
                .HasOne(b => b.Vehicle)
                .WithMany(ba => ba.VehicleQuotes)
                .HasForeignKey(bi => bi.VehicleId);

            modelBuilder.Entity<VehicleQuote>()
                .HasOne(a => a.Quote)
                .WithMany(ba => ba.VehicleQuotes)
                .HasForeignKey(ai => ai.QuoteId);
        }

        //Db tables
        public DbSet<Quote> Quotes { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<PolicyHolder> PolicyHolders { get; set; } = null!;
        public DbSet<VehicleQuote> VehicleQuotes { get; set; } = null!;
    }
}
