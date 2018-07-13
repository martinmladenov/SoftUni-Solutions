namespace P03_FootballBetting.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class PlayerConfig : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(x => x.PlayerId);

            builder.HasOne(x => x.Team);

            builder.HasOne(x => x.Position);

            builder.HasMany(x => x.PlayerStatistics)
                .WithOne(x => x.Player)
                .HasForeignKey(x => x.PlayerId);
        }
    }
}
