
// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


// Configure the HTTP request pipeline.
public interface  IUserBase
{
    public int UserID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public GenderEnum Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public UserTypeEnum UserType { get; set; }
}
