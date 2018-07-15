namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.Property(x => x.Balance)
                .IsRequired();

            builder.Property(x => x.BankName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.SwiftCode)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
