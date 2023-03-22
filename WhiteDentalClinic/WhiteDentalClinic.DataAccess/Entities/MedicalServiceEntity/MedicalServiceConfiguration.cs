using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteDentalClinic.DataAccess.Entities.MedicalServiceEntity
{
    public class MedicalServiceConfiguration : IEntityTypeConfiguration<MedicalService>
    {
        public void Configure(EntityTypeBuilder<MedicalService> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired();
            builder.Property(x => x.Price)
                .IsRequired();
        }
    }
}
