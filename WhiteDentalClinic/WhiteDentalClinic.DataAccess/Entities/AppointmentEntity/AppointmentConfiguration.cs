using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteDentalClinic.DataAccess.Entities.CustomerEntity;
using WhiteDentalClinic.DataAccess.Entities.DentistEntity;

namespace WhiteDentalClinic.DataAccess.Entities.AppointmentEntity
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.dateTime)
                .IsRequired();
            builder.HasOne<Customer>(c => c.Customer)
                .WithMany(ap => ap.Appointments)
                .HasForeignKey(c => c.CustomerId);
            builder.HasOne<Dentist>(d => d.Dentist)
                .WithMany(ap => ap.Appointments)
                .HasForeignKey(d => d.DentistId);
        }
    }
}
