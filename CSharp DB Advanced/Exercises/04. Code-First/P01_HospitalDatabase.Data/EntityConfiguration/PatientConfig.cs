namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(x => x.PatientId);

            builder.Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(x => x.LastName)
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(x => x.Address)
                .HasMaxLength(250)
                .IsUnicode();

            builder.Property(x => x.Email)
                .HasMaxLength(80)
                .IsUnicode(false);
        }
    }
}
