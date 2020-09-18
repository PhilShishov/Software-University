
namespace BillsPaymentSystem.Data.EntityConfiguration
{
    using BillsPaymentSystem.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BankAccountConfig : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.Property(b => b.BankName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(s => s.SWIFT)
                 .HasMaxLength(20)
                 .IsUnicode(false)
                 .IsRequired();
        }
    }
}

//o BankAccountId
//o Balance
//o BankName(up to 50 characters, unicode)
//o SWIFT Code(up to 20 characters, non-unicode)
