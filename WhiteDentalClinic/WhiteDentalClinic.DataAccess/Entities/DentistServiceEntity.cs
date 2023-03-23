﻿namespace WhiteDentalClinic.DataAccess.Entities
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
