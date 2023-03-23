using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhiteDentalClinic.DataAccess.Entities;

namespace WhiteDentalClinic.DataAccess.Configurations
{
    public class DentistServiceConfiguration : IEntityTypeConfiguration<DentistServiceEntity>
    {
        public void Configure(EntityTypeBuilder<DentistServiceEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(d => d.dentist)
            .WithMany(ms => ms.dentistServices)
            .HasForeignKey(ms => ms.dentistId);
            builder.HasOne(s => s.medicalService)
                .WithMany(ns => ns.dentistServices)
                .HasForeignKey(ns => ns.medicalServiceId);
        }
    }
}