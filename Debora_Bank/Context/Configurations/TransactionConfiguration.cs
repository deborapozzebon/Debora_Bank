using Debora_Bank.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Debora_Bank.Context.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");

            builder.Property(t => t.Id)
                .HasColumnName("TransactionId")
                .IsRequired();

            builder.HasKey(t => t.Id);

            builder.Property(t => t.TransactionType)
                .HasColumnName("TransactionType")
                .IsRequired();

            builder.Property(t => t.Date)
                .HasColumnName("Date")
                .IsRequired();

            builder.Property(t => t.Value)
                .HasColumnName("Value")
                .IsRequired();

            builder.Property(t => t.BalanceBefore)
                .HasColumnName("BalanceBefore")
                .IsRequired();

            builder.Property(t => t.BalanceAfter)
                .HasColumnName("BalanceAfter")
                .IsRequired();

            //one to many
            builder.HasOne(t => t.Account)
                .WithMany(a => a.Historic)
                .HasForeignKey(t => t.Id);
        }
    }
}
