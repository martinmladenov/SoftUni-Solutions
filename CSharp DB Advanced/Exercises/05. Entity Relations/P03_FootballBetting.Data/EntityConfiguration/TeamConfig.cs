namespace P03_FootballBetting.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class TeamConfig : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(x => x.TeamId);

            builder.HasOne(x => x.PrimaryKitColor);

            builder.HasOne(x => x.SecondaryKitColor);

            builder.HasOne(x => x.Town);

            builder.HasMany(x => x.HomeGames)
                .WithOne(x => x.HomeTeam)
                .HasForeignKey(x => x.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.AwayGames)
                .WithOne(x => x.AwayTeam)
                .HasForeignKey(x => x.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Players)
                .WithOne(x => x.Team)
                .HasForeignKey(x => x.TeamId);
        }
    }
}
