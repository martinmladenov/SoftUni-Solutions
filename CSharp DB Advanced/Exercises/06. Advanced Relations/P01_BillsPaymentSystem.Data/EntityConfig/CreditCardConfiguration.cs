namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.Property(x => x.Limit)
                .IsRequired();

            builder.Property(x => x.MoneyOwed)
                .IsRequired();

            builder.Property(x => x.ExpirationDate)
                .IsRequired();
        }
    }
}
