using Debora_Bank.Context.Configurations;
using Debora_Bank.Entities;
using Microsoft.EntityFrameworkCore;

namespace Debora_Bank.Context
{
    public class DeboraBankDbContext : DbContext
    {
        public DeboraBankDbContext(DbContextOptions<DeboraBankDbContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasKey(t => t.Id);
            modelBuilder.Entity<Account>()
                .HasMany(t => t.Historic)
                .WithOne(a => a.Account).HasForeignKey(s => s.Id);

            modelBuilder.Entity<Owner>().HasKey(t => t.Id);
            modelBuilder.Entity<Owner>()
                .HasOne(t => t.Account)
                .WithOne(a => a.Owner)
                .HasForeignKey<Owner>(q => q.AccountId);

            modelBuilder.Entity<Transaction>().HasKey(t => t.Id);
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Account)
                .WithMany(a => a.Historic)
                .HasForeignKey(f => f.Id);
        }
    }
}
