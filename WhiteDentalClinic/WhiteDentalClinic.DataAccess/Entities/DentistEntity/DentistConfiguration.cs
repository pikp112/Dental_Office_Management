using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteDentalClinic.DataAccess.Entities.CustomerEntity;
using WhiteDentalClinic.DataAccess.Entities.MedicalServiceEntity;

namespace WhiteDentalClinic.DataAccess.Entities.DentistEntity
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Dentist>
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
