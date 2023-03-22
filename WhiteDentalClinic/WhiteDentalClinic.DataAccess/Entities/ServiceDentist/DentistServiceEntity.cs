using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteDentalClinic.DataAccess.Entities.DentistEntity;
using WhiteDentalClinic.DataAccess.Entities.MedicalServiceEntity;

namespace WhiteDentalClinic.DataAccess.Entities.ServiceDentist
{
    public class DentistServiceEntity
    {
        public Guid Id { get; set; }
        public Guid dentistId { get; set; }
        public Dentist dentist { get; set; }
        public Guid medicalServiceId { get; set; }
        public MedicalService medicalService { get; set; }
    }
}
