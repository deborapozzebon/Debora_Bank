using Debora_Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Debora_Bank.Domain.Context
{
    public class DeboraBankDbContext : DbContext
    {
        public DeboraBankDbContext(DbContextOptions<DeboraBankDbContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasKey(t => t.Id);
            modelBuilder.Entity<Account>()
                .HasMany(s => s.Historic)
                .WithOne(a => a.Account);

            modelBuilder.Entity<Transaction>().HasKey(t => t.Id);
        }
    }
}
