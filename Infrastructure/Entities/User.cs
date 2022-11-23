namespace WebApiForPostman.Infrastructure.Entities;

public class User
{
    public int id { get; set; }
    public string? Name { get; set; }
    public string? Login { get; set; }
    public int? Age { get; set; }
    public string? PhoneNumber { get; set; }
}