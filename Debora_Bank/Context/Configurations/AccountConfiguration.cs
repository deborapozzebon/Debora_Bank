using Debora_Bank.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Debora_Bank.Context.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");

            builder.Property(t => t.Id)
                .HasColumnName("AccountId")
                .IsRequired();

            builder.HasKey(t => t.Id);

            builder.Property(t => t.CurrentBalance)
                .HasColumnName("CurrentBalance")
                .IsRequired();

            //many to one
            builder.HasMany(a => a.Historic)
                .WithOne(s => s.Account)
                .HasForeignKey(b => b.Id);
        }
    }
}
