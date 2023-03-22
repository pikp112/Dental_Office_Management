using WhiteDentalClinic.DataAccess.Entities.ServiceDentist;

namespace WhiteDentalClinic.DataAccess.Entities.MedicalServiceEntity
{
    public class MedicalService
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public List<DentistServiceEntity> dentistServices { get; set; }
    }
}
