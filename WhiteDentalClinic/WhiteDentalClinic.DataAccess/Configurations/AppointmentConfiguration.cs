using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhiteDentalClinic.DataAccess.Entities;

namespace WhiteDentalClinic.DataAccess.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.DateTime)
                .IsRequired();
            builder.HasOne<Customer>(c => c.Customer)
                .WithMany(ap => ap.Appointments)
                .HasForeignKey(c => c.CustomerId);
            builder.HasOne<Dentist>(d => d.Dentist)
                .WithMany(ap => ap.Appointments)
                .HasForeignKey(d => d.DentistId);
            builder.HasOne<MedicalService>(a => a.MedicalService)
                .WithMany(ms => ms.Appointments)
                .HasForeignKey(a => a.MedicalServiceId);
        }
    }
}
