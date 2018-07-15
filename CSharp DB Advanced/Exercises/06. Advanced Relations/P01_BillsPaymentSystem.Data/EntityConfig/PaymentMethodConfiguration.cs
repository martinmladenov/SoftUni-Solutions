namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasIndex(x => new
            {
                x.UserId,
                x.BankAccountId,
                x.CreditCardId
            })
                .IsUnique();

            builder.Property(x => x.Type)
                .IsRequired();

            builder.HasOne(x => x.BankAccount)
                .WithOne(x => x.PaymentMethod)
                .HasForeignKey<PaymentMethod>(x => x.BankAccountId);

            builder.HasOne(x => x.CreditCard)
                .WithOne(x => x.PaymentMethod)
                .HasForeignKey<PaymentMethod>(x => x.CreditCardId);
        }
    }
}
