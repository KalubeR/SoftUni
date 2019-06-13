using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillsPaymentSystem.Data.EntityConfigurations
{
    public class BankAccountConfig : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder
                .Property(bn => bn.BankName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder
                .Property(bn => bn.SWIFTCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}