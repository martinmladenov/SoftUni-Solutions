namespace P03_FootballBetting.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class GameConfig : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(x => x.GameId);

            builder.HasOne(x => x.HomeTeam);

            builder.HasOne(x => x.AwayTeam);

            builder.HasMany(x => x.PlayerStatistics)
                .WithOne(x => x.Game)
                .HasForeignKey(x => x.GameId);

            builder.HasMany(x => x.Bets)
                .WithOne(x => x.Game)
                .HasForeignKey(x => x.GameId);
        }
    }
}
