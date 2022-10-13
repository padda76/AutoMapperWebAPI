namespace AutoMapperWebAPI.DTO;

public class UserDTO
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FullName {
        get { return $"{FirstName} {LastName}"; }
    }
    public DateTime Birthdate { get; set; }

    public override string ToString()
    {
        return $"{FullName} - {Birthdate:yyyy-MM-dd}";
    }
}
