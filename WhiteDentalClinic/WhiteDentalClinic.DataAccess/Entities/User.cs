namespace WhiteDentalClinic.DataAccess.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }

    public string Email { get; set; }
}