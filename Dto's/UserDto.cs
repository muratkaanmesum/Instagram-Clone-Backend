namespace Instagram_Clone_Backend.Dto_s;

public class UserDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string? Bio { get; set; }
    public string? Email { get; set; }
    public string? Gender { get; set; }
}