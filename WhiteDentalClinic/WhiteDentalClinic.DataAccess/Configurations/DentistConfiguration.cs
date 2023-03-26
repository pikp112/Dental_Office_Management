using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhiteDentalClinic.DataAccess.Entities;

namespace WhiteDentalClinic.DataAccess.Configurations
{
    public class DentistConfiguration : IEntityTypeConfiguration<Dentist>
    {
        public void Configure(EntityTypeBuilder<Dentist> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.FirstName)
                .IsRequired();
            builder.Property(c => c.LastName)
                .IsRequired();
            builder.Property(c => c.Age)
                .IsRequired();
            builder.Property(c => c.Email)
                .IsRequired();
        }
    }
}
