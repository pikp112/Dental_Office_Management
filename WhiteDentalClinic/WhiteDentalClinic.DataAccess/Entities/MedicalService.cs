namespace WhiteDentalClinic.DataAccess.Entities
{
    public class MedicalService : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public List<DentistServiceEntity> DentistServices { get; set; }
    }
}
