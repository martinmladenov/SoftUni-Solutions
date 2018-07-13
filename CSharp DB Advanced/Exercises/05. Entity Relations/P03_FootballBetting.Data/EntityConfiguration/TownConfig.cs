namespace P03_FootballBetting.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class TownConfig : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.HasKey(x => x.TownId);

            builder.HasMany(x => x.Teams)
                .WithOne(x => x.Town)
                .HasForeignKey(x => x.TownId);

            builder.HasOne(x => x.Country);
        }
    }
}
