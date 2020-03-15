using Debora_Bank.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Debora_Bank.Context.Configurations
{
    //public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    //{
    //    public void Configure(EntityTypeBuilder<Owner> builder)
    //    {
    //        builder.ToTable("Owner");

    //        builder.Property(t => t.Id)
    //            .HasColumnName("OwnerId")
    //            .IsRequired();

    //        builder.HasKey(t => t.Id);

    //        builder.Property(t => t.Name)
    //            .HasColumnName("Name")
    //            .IsRequired();

    //        builder.Property(t => t.CPF)
    //            .HasColumnName("CPF")
    //            .IsRequired();

    //        builder.Property(t => t.Account)
    //           .HasColumnName("Account")
    //           .IsRequired();

    //        //one to one
    //        builder.HasOne(t => t.Account)
    //            .WithOne(a => a.Owner)
    //            .HasForeignKey<Owner>(t => t.Id);
    //    }
    //}
}
