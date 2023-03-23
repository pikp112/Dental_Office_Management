namespace PizzaApp.Shared.Models.Users;

public class LoginResponseModel
{
    public Guid Id { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public string Token { get; set; }
}