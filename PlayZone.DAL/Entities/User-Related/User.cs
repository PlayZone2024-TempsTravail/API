namespace PlayZone.DAL.Entities.User_Related;

public class User
{
    public int IdUser { get; set; }
    public int RoleId { get; set; }
    public bool IsActive { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int VA { get; set; }
    public int VAEX { get; set; }
    public int RC { get; set; }
}
