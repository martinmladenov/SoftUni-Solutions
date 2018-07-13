namespace P03_FootballBetting.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class BetConfig : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder.HasKey(x => x.BetId);

            builder.HasOne(x => x.Game);

            builder.Property(x => x.Prediction)
                .IsRequired();

            builder.HasOne(x => x.User);
        }
    }
}
