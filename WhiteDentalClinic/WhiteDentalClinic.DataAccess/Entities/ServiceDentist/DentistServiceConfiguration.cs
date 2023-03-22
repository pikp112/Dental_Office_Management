using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using WhiteDentalClinic.DataAccess.Entities.MedicalServiceEntity;

namespace WhiteDentalClinic.DataAccess.Entities.ServiceDentist
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