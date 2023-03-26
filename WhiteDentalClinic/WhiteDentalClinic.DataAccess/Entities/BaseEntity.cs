namespace WhiteDentalClinic.DataAccess.Entities
{
    public abstract class BaseEntity
    {
        // [EnumDataType(typeof(Role))]
        // public abstract Role Role { get; }

        public Guid Id { get; set; }
    }
}
