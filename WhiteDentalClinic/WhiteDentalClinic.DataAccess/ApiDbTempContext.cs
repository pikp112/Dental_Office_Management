using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WhiteDentalClinic.DataAccess.Entities;

namespace WhiteDentalClinic.DataAccess
{
    public class ApiDbTempContext : DbContext
    {
        public ApiDbTempContext(DbContextOptions options) : base(options) { }
        /*        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                {
                    optionsBuilder.UseInMemoryDatabase(databaseName: "CustomerDb");
                }
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Dentist> Dentists { get; set; }
        public DbSet<MedicalService> MedicalServices { get; set; }
        public DbSet<DentistServiceEntity> DentistServices { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}