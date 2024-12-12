namespace PlayZone.BLL.Models.User_Related;

public class User
{
    public int IdUser { get; set; }
    public bool IsActive { get; set; }
    public string Nom { get; set; } = string.Empty;
    public string Prenom { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public IEnumerable<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public IEnumerable<UserSalaire> UserSalaires { get; set; } = new List<UserSalaire>();
}
