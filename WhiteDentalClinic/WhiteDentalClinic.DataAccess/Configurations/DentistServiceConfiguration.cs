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
            builder.HasOne(d => d.Dentist)
            .WithMany(ms => ms.dentistServices)
            .HasForeignKey(ms => ms.DentistId);
            builder.HasOne(s => s.MedicalService)
                .WithMany(ns => ns.DentistServices)
                .HasForeignKey(ns => ns.MedicalServiceId);
        }
    }
}