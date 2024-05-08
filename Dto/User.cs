namespace DiplomApi.Dto;

public class UserDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}